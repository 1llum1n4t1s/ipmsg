using System.Security.Cryptography;

namespace IpMsg.Core.Security;

public sealed class CryptoService
{
    public Aes CreateAes() => Aes.Create();

    public RSA CreateRsa(int keySize = 2048)
    {
        var rsa = RSA.Create();
        rsa.KeySize = keySize;
        return rsa;
    }

    public (byte[] Key, byte[] Iv) GenerateAesKey()
    {
        using var aes = CreateAes();
        aes.GenerateKey();
        aes.GenerateIV();
        return (aes.Key, aes.IV);
    }

    public RSAParameters ExportPublicKey(RSA rsa) => rsa.ExportParameters(false);

    public RSAParameters ExportPrivateKey(RSA rsa) => rsa.ExportParameters(true);

    public RSA ImportPublicKey(RSAParameters parameters)
    {
        var rsa = RSA.Create();
        rsa.ImportParameters(parameters);
        return rsa;
    }

    public string ExportPublicKeyBase64(RSA rsa)
    {
        var data = rsa.ExportRSAPublicKey();
        return Convert.ToBase64String(data);
    }

    public string ExportPrivateKeyBase64(RSA rsa)
    {
        var data = rsa.ExportRSAPrivateKey();
        return Convert.ToBase64String(data);
    }

    public RSA ImportPublicKeyBase64(string base64)
    {
        var data = Convert.FromBase64String(base64);
        var rsa = RSA.Create();
        rsa.ImportRSAPublicKey(data, out _);
        return rsa;
    }

    public RSA ImportPrivateKeyBase64(string base64)
    {
        var data = Convert.FromBase64String(base64);
        var rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(data, out _);
        return rsa;
    }

    public byte[] EncryptAes(byte[] plainBytes, byte[] key, byte[] iv)
    {
        using var aes = CreateAes();
        aes.Key = key;
        aes.IV = iv;
        using var encryptor = aes.CreateEncryptor();
        return encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
    }

    public byte[] DecryptAes(byte[] cipherBytes, byte[] key, byte[] iv)
    {
        using var aes = CreateAes();
        aes.Key = key;
        aes.IV = iv;
        using var decryptor = aes.CreateDecryptor();
        return decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
    }

    public byte[] EncryptKeyWithRsa(byte[] key, RSAParameters publicKey)
    {
        using var rsa = ImportPublicKey(publicKey);
        return rsa.Encrypt(key, RSAEncryptionPadding.OaepSHA256);
    }

    public byte[] DecryptKeyWithRsa(byte[] encryptedKey, RSAParameters privateKey)
    {
        using var rsa = RSA.Create();
        rsa.ImportParameters(privateKey);
        return rsa.Decrypt(encryptedKey, RSAEncryptionPadding.OaepSHA256);
    }

    public byte[] SignData(byte[] data, RSAParameters privateKey)
    {
        using var rsa = RSA.Create();
        rsa.ImportParameters(privateKey);
        return rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }

    public bool VerifyData(byte[] data, byte[] signature, RSAParameters publicKey)
    {
        using var rsa = RSA.Create();
        rsa.ImportParameters(publicKey);
        return rsa.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }
}
