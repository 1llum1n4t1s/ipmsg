using IpMsg.Core.Settings;

namespace IpMsg.UI.ViewModels;

public sealed class SettingsViewModel
{
    public AppSettings Settings { get; private set; }

    public SettingsViewModel(AppSettings settings)
    {
        Settings = settings;
    }

    public void Update(AppSettings settings)
    {
        Settings = settings;
    }
}
