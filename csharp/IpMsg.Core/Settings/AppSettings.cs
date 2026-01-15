using System.Text.Json;

namespace IpMsg.Core.Settings;

public sealed record AppSettings(
    string UserName,
    string HostName,
    int UdpPort,
    int TcpPort,
    bool EnableEncryption,
    string DataDirectory)
{
    public static AppSettings CreateDefault() => new(
        UserName: Environment.UserName,
        HostName: Environment.MachineName,
        UdpPort: 0x0979,
        TcpPort: 0x0979,
        EnableEncryption: true,
        DataDirectory: Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "IpMsg"));

    public static async Task<AppSettings> LoadAsync(string path, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(path))
        {
            return CreateDefault();
        }

        await using var stream = File.OpenRead(path);
        var settings = await JsonSerializer.DeserializeAsync<AppSettings>(stream, cancellationToken: cancellationToken);
        return settings ?? CreateDefault();
    }

    public async Task SaveAsync(string path, CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path) ?? ".");
        await using var stream = File.Create(path);
        await JsonSerializer.SerializeAsync(stream, this, cancellationToken: cancellationToken);
    }
}
