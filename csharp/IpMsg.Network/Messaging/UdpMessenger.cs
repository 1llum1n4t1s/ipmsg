using System.Net;
using System.Net.Sockets;
using System.Text;
using IpMsg.Core.Settings;

namespace IpMsg.Network.Messaging;

public sealed class UdpMessenger : IDisposable
{
    private readonly UdpClient _client;

    public UdpMessenger(AppSettings settings)
    {
        _client = new UdpClient(settings.UdpPort);
    }

    public async Task SendAsync(string message, IPEndPoint endpoint, CancellationToken cancellationToken = default)
    {
        var bytes = Encoding.UTF8.GetBytes(message);
        await _client.SendAsync(bytes, bytes.Length, endpoint, cancellationToken);
    }

    public async Task<UdpReceiveResult> ReceiveAsync(CancellationToken cancellationToken = default)
    {
        return await _client.ReceiveAsync(cancellationToken);
    }

    public void Dispose() => _client.Dispose();
}
