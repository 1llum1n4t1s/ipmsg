using IpMsg.Protocol;

namespace IpMsg.Core.Security;

public sealed class CompatibilityValidator
{
    public bool SupportsIpDict(uint capabilityFlags) => (capabilityFlags & ProtocolConstants.CapIpDictOpt) != 0;

    public bool SupportsEncryption(uint capabilityFlags) => (capabilityFlags & ProtocolConstants.EncryptOpt) != 0;

    public bool SupportsSignature(uint capabilityFlags) => (capabilityFlags & ProtocolConstants.SignSha256) != 0;

    public bool ValidateCapabilities(uint localFlags, uint remoteFlags)
    {
        var requiresEncryption = (localFlags & ProtocolConstants.EncryptOpt) != 0;
        if (requiresEncryption && (remoteFlags & ProtocolConstants.EncryptOpt) == 0)
        {
            return false;
        }

        var requiresIpDict = (localFlags & ProtocolConstants.CapIpDictOpt) != 0;
        if (requiresIpDict && (remoteFlags & ProtocolConstants.CapIpDictOpt) == 0)
        {
            return false;
        }

        return true;
    }

    public bool ValidateKeyMaterial(KeyMaterial material, int minimumKeySize)
    {
        if (material.KeySize < minimumKeySize)
        {
            return false;
        }

        return !string.IsNullOrWhiteSpace(material.PublicKeyBase64) && !string.IsNullOrWhiteSpace(material.PrivateKeyBase64);
    }
}
