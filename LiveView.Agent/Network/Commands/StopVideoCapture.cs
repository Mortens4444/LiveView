using LiveView.Core.Interfaces;
using System.Collections.Generic;
using System.Threading;

namespace LiveView.Agent.Network.Commands
{
    public class StopVideoCapture : ICommand
    {
        private readonly Dictionary<string, CancellationTokenSource> cancellationTokenSources;
        private readonly string videoCaptureId;

        public StopVideoCapture(Dictionary<string, CancellationTokenSource> cancellationTokenSources, string videoCaptureId)
        {
            this.cancellationTokenSources = cancellationTokenSources;
            this.videoCaptureId = videoCaptureId;
        }

        public void Execute()
        {
            if (cancellationTokenSources.TryGetValue(videoCaptureId, out var value))
            {
                value.Cancel();
                value.Dispose();
                cancellationTokenSources.Remove(videoCaptureId);
            }
        }
    }
}
