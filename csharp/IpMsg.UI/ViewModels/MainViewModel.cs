using IpMsg.Core.Settings;
using IpMsg.Network.Messaging;

namespace IpMsg.UI.ViewModels;

public sealed class MainViewModel
{
    public AppSettings Settings { get; private set; }
    public UdpMessenger UdpMessenger { get; private set; }
    public TcpMessenger TcpMessenger { get; private set; }

    public MainViewModel(AppSettings settings)
    {
        Settings = settings;
        UdpMessenger = new UdpMessenger(settings);
        TcpMessenger = new TcpMessenger(settings);
    }

    public void ApplySettings(AppSettings settings)
    {
        Settings = settings;
        UdpMessenger.Dispose();
        UdpMessenger = new UdpMessenger(settings);
        TcpMessenger = new TcpMessenger(settings);
    }
}
