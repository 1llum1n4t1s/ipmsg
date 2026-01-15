namespace IpMsg.Core.Transfer;

public sealed class TransferControl
{
    private readonly ManualResetEventSlim _pauseEvent = new(true);
    private bool _isCanceled;

    public void Pause()
    {
        _pauseEvent.Reset();
    }

    public void Resume()
    {
        _pauseEvent.Set();
    }

    public void Cancel()
    {
        _isCanceled = true;
        _pauseEvent.Set();
    }

    public void WaitIfPaused(CancellationToken cancellationToken)
    {
        _pauseEvent.Wait(cancellationToken);
        if (_isCanceled)
        {
            throw new OperationCanceledException();
        }
    }
}
