using LiveView.Agent.Maui.Interfaces;

namespace LiveView.Agent.Maui.Network.Commands
{
    public class MauiAgentStopVideoCaptureCommand : IAsyncCommand
    {
        private readonly CancellationTokenSource cancellationTokenSource;

        public MauiAgentStopVideoCaptureCommand(CancellationTokenSource cancellationTokenSource)
        {
            this.cancellationTokenSource = cancellationTokenSource;
        }

        public Task ExecuteAsync()
        {
            return cancellationTokenSource.CancelAsync();
        }
    }
}
