using System.Security.Cryptography;

namespace IpMsg.Core.Transfer;

public sealed class FileTransferSession
{
    public FileTransferMetadata Metadata { get; private set; }

    public FileTransferSession(FileTransferMetadata metadata)
    {
        Metadata = metadata;
    }

    public async Task SendAsync(Stream source, Stream destination, TransferControl? control = null, TransferOptions? options = null, IProgress<FileTransferProgress>? progress = null, CancellationToken cancellationToken = default)
    {
        await ExecuteWithRetryAsync(() => TransferAsync(source, destination, control, progress, cancellationToken), options, cancellationToken);
    }

    public async Task ReceiveAsync(Stream source, string destinationPath, TransferControl? control = null, TransferOptions? options = null, IProgress<FileTransferProgress>? progress = null, CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath) ?? ".");
        await using var destination = File.Create(destinationPath);
        await ExecuteWithRetryAsync(() => TransferAsync(source, destination, control, progress, cancellationToken), options, cancellationToken);
    }

    public async Task ResumeAsync(Stream source, Stream destination, long offset, TransferControl? control = null, TransferOptions? options = null, IProgress<FileTransferProgress>? progress = null, CancellationToken cancellationToken = default)
    {
        if (source.CanSeek)
        {
            source.Seek(offset, SeekOrigin.Begin);
        }

        if (destination.CanSeek)
        {
            destination.Seek(offset, SeekOrigin.Begin);
        }

        Metadata = Metadata with { ResumeOffset = offset, Status = TransferStatus.InProgress };
        await ExecuteWithRetryAsync(() => TransferAsync(source, destination, control, progress, cancellationToken, offset), options, cancellationToken);
    }

    public async Task<string> ComputeChecksumAsync(Stream source, CancellationToken cancellationToken = default)
    {
        using var sha256 = SHA256.Create();
        var hash = await sha256.ComputeHashAsync(source, cancellationToken);
        return Convert.ToHexString(hash).ToLowerInvariant();
    }

    private async Task ExecuteWithRetryAsync(Func<Task> action, TransferOptions? options, CancellationToken cancellationToken)
    {
        var retryOptions = options ?? TransferOptions.Default;
        var attempts = 0;
        while (true)
        {
            try
            {
                Metadata = Metadata with { Status = TransferStatus.InProgress };
                await action();
                Metadata = Metadata with { Status = TransferStatus.Completed };
                return;
            }
            catch (OperationCanceledException)
            {
                Metadata = Metadata with { Status = TransferStatus.Paused };
                throw;
            }
            catch
            {
                attempts++;
                Metadata = Metadata with { Status = TransferStatus.Failed };
                if (attempts > retryOptions.MaxRetries)
                {
                    throw;
                }

                await Task.Delay(retryOptions.RetryDelay, cancellationToken);
            }
        }
    }

    private async Task TransferAsync(Stream source, Stream destination, TransferControl? control, IProgress<FileTransferProgress>? progress, CancellationToken cancellationToken, long initialOffset = 0)
    {
        var buffer = new byte[81920];
        long totalTransferred = initialOffset;
        int read;
        while ((read = await source.ReadAsync(buffer, cancellationToken)) > 0)
        {
            control?.WaitIfPaused(cancellationToken);
            await destination.WriteAsync(buffer.AsMemory(0, read), cancellationToken);
            totalTransferred += read;
            progress?.Report(new FileTransferProgress(Metadata.TransferId, totalTransferred, Metadata.FileSize));
        }
    }
}
