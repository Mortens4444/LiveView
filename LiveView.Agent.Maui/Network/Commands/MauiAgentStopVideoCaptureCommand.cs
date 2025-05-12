using LiveView.Agent.Maui.Interfaces;

namespace Sequence.Network.Commands
{
    public class MauiAgentStopVideoCaptureCommand : IAsyncCommand
    {
        private readonly CancellationTokenSource cancellationTokenSource;

        public MauiAgentStopVideoCaptureCommand(CancellationTokenSource cancellationTokenSource)
        {
            this.cancellationTokenSource = cancellationTokenSource;
        }

        public async void ExecuteAsync()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
