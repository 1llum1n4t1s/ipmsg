using System.Windows;
using IpMsg.Core.Settings;

namespace IpMsg.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnOpenSend(object sender, RoutedEventArgs e)
    {
        var settings = AppSettings.CreateDefault();
        var window = new SendWindow(settings)
        {
            Owner = this
        };
        window.Show();
    }

    private void OnOpenReceive(object sender, RoutedEventArgs e)
    {
        var window = new ReceiveWindow
        {
            Owner = this
        };
        window.Show();
    }

    private void OnOpenSettings(object sender, RoutedEventArgs e)
    {
        var window = new SettingsWindow
        {
            Owner = this
        };
        window.Show();
    }

    private void OnOpenHistory(object sender, RoutedEventArgs e)
    {
        var window = new HistoryWindow
        {
            Owner = this
        };
        window.Show();
    }

    private void OnOpenLog(object sender, RoutedEventArgs e)
    {
        var window = new LogWindow
        {
            Owner = this
        };
        window.Show();
    }

    private void OnOpenLogin(object sender, RoutedEventArgs e)
    {
        var window = new LoginWindow
        {
            Owner = this
        };
        window.Show();
    }

    private void OnOpenPlugin(object sender, RoutedEventArgs e)
    {
        var window = new PluginWindow
        {
            Owner = this
        };
        window.Show();
    }
}
