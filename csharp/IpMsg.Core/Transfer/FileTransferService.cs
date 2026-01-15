namespace IpMsg.Core.Transfer;

public sealed class FileTransferService
{
    public async Task SendFileAsync(Stream source, Stream destination, CancellationToken cancellationToken = default)
    {
        await source.CopyToAsync(destination, cancellationToken);
    }

    public async Task ReceiveFileAsync(Stream source, string destinationPath, CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath) ?? ".");
        await using var destination = File.Create(destinationPath);
        await source.CopyToAsync(destination, cancellationToken);
    }
}
