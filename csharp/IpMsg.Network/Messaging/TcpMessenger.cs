using System.Net;
using System.Net.Sockets;
using System.Text;
using IpMsg.Core.Settings;

namespace IpMsg.Network.Messaging;

public sealed class TcpMessenger
{
    private readonly TcpListener _listener;

    public TcpMessenger(AppSettings settings)
    {
        _listener = new TcpListener(IPAddress.Any, settings.TcpPort);
    }

    public void Start() => _listener.Start();

    public void Stop() => _listener.Stop();

    public async Task<TcpClient> AcceptAsync(CancellationToken cancellationToken = default)
    {
        return await _listener.AcceptTcpClientAsync(cancellationToken);
    }

    public async Task SendAsync(string message, IPEndPoint endpoint, CancellationToken cancellationToken = default)
    {
        using var client = new TcpClient();
        await client.ConnectAsync(endpoint, cancellationToken);
        await using var stream = client.GetStream();
        var bytes = Encoding.UTF8.GetBytes(message);
        await stream.WriteAsync(bytes, cancellationToken);
    }
}
