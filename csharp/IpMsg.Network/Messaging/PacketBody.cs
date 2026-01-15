namespace IpMsg.Network.Messaging;

public sealed record PacketBody(
    string Message,
    string? NickName,
    string? GroupName)
{
    public static PacketBody FromRaw(string body)
    {
        if (string.IsNullOrEmpty(body))
        {
            return new PacketBody(string.Empty, null, null);
        }

        var parts = body.Split('\0');
        var message = parts.Length > 0 ? parts[0] : string.Empty;
        var nickname = parts.Length > 1 ? parts[1] : null;
        var groupName = parts.Length > 2 ? parts[2] : null;
        return new PacketBody(message, nickname, groupName);
    }

    public string ToRaw()
    {
        if (NickName is null && GroupName is null)
        {
            return Message;
        }

        if (GroupName is null)
        {
            return string.Join("\0", Message, NickName ?? string.Empty);
        }

        return string.Join("\0", Message, NickName ?? string.Empty, GroupName);
    }
}
