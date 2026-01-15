using System.Text.Json;

namespace IpMsg.Core.Security;

public sealed class KeyStore
{
    public async Task SaveAsync(string path, KeyMaterial material, CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path) ?? ".");
        await using var stream = File.Create(path);
        await JsonSerializer.SerializeAsync(stream, material, cancellationToken: cancellationToken);
    }

    public async Task<KeyMaterial?> LoadAsync(string path, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        await using var stream = File.OpenRead(path);
        return await JsonSerializer.DeserializeAsync<KeyMaterial>(stream, cancellationToken: cancellationToken);
    }
}

public sealed record KeyMaterial(
    string PublicKeyBase64,
    string PrivateKeyBase64,
    int KeySize);
