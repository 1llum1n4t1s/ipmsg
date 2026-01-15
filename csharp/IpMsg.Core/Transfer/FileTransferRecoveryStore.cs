using System.Text.Json;

namespace IpMsg.Core.Transfer;

public sealed class FileTransferRecoveryStore
{
    public async Task SaveAsync(string path, FileTransferMetadata metadata, CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path) ?? ".");
        await using var stream = File.Create(path);
        await JsonSerializer.SerializeAsync(stream, metadata, cancellationToken: cancellationToken);
    }

    public async Task<FileTransferMetadata?> LoadAsync(string path, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        await using var stream = File.OpenRead(path);
        return await JsonSerializer.DeserializeAsync<FileTransferMetadata>(stream, cancellationToken: cancellationToken);
    }
}
