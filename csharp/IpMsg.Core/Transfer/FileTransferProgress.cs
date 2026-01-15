namespace IpMsg.Core.Transfer;

public sealed record FileTransferProgress(
    string TransferId,
    long BytesTransferred,
    long TotalBytes)
{
    public double Percentage => TotalBytes == 0 ? 0 : (double)BytesTransferred / TotalBytes * 100;
}
