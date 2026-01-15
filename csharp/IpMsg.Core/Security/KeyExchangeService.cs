using System.Security.Cryptography;

namespace IpMsg.Core.Security;

public sealed class KeyExchangeService
{
    private readonly CryptoService _cryptoService = new();

    public RSAParameters CreateLocalKeyPair(int keySize = 2048)
    {
        using var rsa = _cryptoService.CreateRsa(keySize);
        return _cryptoService.ExportPrivateKey(rsa);
    }

    public RSAParameters ExtractPublicKey(RSAParameters privateKey)
    {
        using var rsa = RSA.Create();
        rsa.ImportParameters(privateKey);
        return _cryptoService.ExportPublicKey(rsa);
    }

    public (byte[] EncryptedKey, byte[] EncryptedIv) CreateEncryptedSessionKey(RSAParameters remotePublicKey)
    {
        var (key, iv) = _cryptoService.GenerateAesKey();
        var encryptedKey = _cryptoService.EncryptKeyWithRsa(key, remotePublicKey);
        var encryptedIv = _cryptoService.EncryptKeyWithRsa(iv, remotePublicKey);
        return (encryptedKey, encryptedIv);
    }

    public (byte[] Key, byte[] Iv) DecryptSessionKey(byte[] encryptedKey, byte[] encryptedIv, RSAParameters localPrivateKey)
    {
        var key = _cryptoService.DecryptKeyWithRsa(encryptedKey, localPrivateKey);
        var iv = _cryptoService.DecryptKeyWithRsa(encryptedIv, localPrivateKey);
        return (key, iv);
    }
}
