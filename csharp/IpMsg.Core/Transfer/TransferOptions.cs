namespace IpMsg.Core.Transfer;

public sealed record TransferOptions(int MaxRetries, TimeSpan RetryDelay)
{
    public static TransferOptions Default => new(3, TimeSpan.FromSeconds(2));
}
