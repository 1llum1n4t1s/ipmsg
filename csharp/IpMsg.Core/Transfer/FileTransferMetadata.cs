namespace IpMsg.Core.Transfer;

public sealed record FileTransferMetadata(
    string FileName,
    long FileSize,
    string ContentType,
    DateTimeOffset LastModified,
    string TransferId,
    string ChecksumSha256,
    long ChunkSize,
    long ResumeOffset,
    TransferStatus Status);

public enum TransferStatus
{
    Pending,
    InProgress,
    Completed,
    Failed,
    Paused
}
