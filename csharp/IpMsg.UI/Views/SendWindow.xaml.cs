using System.Windows;
using IpMsg.Core.Settings;

namespace IpMsg.UI.Views;

public partial class SendWindow : Window
{
    public AppSettings Settings { get; }

    public SendWindow(AppSettings settings)
    {
        Settings = settings;
        InitializeComponent();
    }
}
