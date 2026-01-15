using System.Globalization;
using IpMsg.Protocol;

namespace IpMsg.Network.Messaging;

public static class PacketSerializer
{
    private const char Separator = ':';

    public static string Serialize(IpMsgPacket packet)
    {
        return string.Join(Separator,
            packet.Version,
            packet.PacketNo,
            packet.UserName,
            packet.HostName,
            packet.Command.ToString(CultureInfo.InvariantCulture),
            packet.Body);
    }

    public static IpMsgPacket Parse(string message)
    {
        var parts = message.Split(Separator, 6, StringSplitOptions.None);
        if (parts.Length < 5)
        {
            throw new FormatException("IPメッセージの形式が不正です。");
        }

        var version = parts[0];
        var packetNo = parts[1];
        var userName = parts[2];
        var hostName = parts[3];
        var command = uint.Parse(parts[4], CultureInfo.InvariantCulture);
        var body = parts.Length > 5 ? parts[5] : string.Empty;

        return new IpMsgPacket(version, packetNo, userName, hostName, command, body);
    }

    public static IpMsgDetailedPacket ParseDetailed(string message)
    {
        var packet = Parse(message);
        var body = PacketBody.FromRaw(packet.Body);
        var dict = packet.Body.StartsWith("IP2:", StringComparison.Ordinal) ? IpDictDocument.Parse(packet.Body) : null;
        return new IpMsgDetailedPacket(packet, body, dict);
    }

    public static string SerializeDetailed(IpMsgDetailedPacket packet)
    {
        var rawBody = packet.DictionaryPayload is null ? packet.Body.ToRaw() : packet.DictionaryPayload.Serialize();
        var basePacket = packet.Packet with { Body = rawBody };
        return Serialize(basePacket);
    }

    public static IpMsgPacket CreatePacket(string userName, string hostName, uint command, string body)
    {
        var packetNo = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(CultureInfo.InvariantCulture);
        return new IpMsgPacket(ProtocolConstants.NewVersion.ToString(CultureInfo.InvariantCulture), packetNo, userName, hostName, command, body);
    }
}
