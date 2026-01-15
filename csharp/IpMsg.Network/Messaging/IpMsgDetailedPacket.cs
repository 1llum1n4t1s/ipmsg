namespace IpMsg.Network.Messaging;

public sealed record IpMsgDetailedPacket(
    IpMsgPacket Packet,
    PacketBody Body,
    IpDictDocument? DictionaryPayload);
