namespace IpMsg.Network.Messaging;

public sealed record IpMsgPacket(
    string Version,
    string PacketNo,
    string UserName,
    string HostName,
    uint Command,
    string Body);
