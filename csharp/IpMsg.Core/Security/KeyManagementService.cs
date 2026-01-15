namespace IpMsg.Core.Security;

public sealed class KeyManagementService
{
    private readonly CryptoService _cryptoService = new();
    private readonly KeyStore _keyStore = new();

    public async Task<KeyMaterial> EnsureKeysAsync(string path, int keySize, CancellationToken cancellationToken = default)
    {
        var existing = await _keyStore.LoadAsync(path, cancellationToken);
        if (existing is not null)
        {
            return existing;
        }

        using var rsa = _cryptoService.CreateRsa(keySize);
        var material = new KeyMaterial(
            _cryptoService.ExportPublicKeyBase64(rsa),
            _cryptoService.ExportPrivateKeyBase64(rsa),
            keySize);

        await _keyStore.SaveAsync(path, material, cancellationToken);
        return material;
    }
}
