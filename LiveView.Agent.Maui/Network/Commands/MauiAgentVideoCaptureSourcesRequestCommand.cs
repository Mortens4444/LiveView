using LiveView.Agent.Maui;
using LiveView.Agent.Maui.Interfaces;

namespace LiveView.Agent.Maui.Network.Commands
{
    public class MauiAgentVideoCaptureSourcesRequestCommand : IAsyncCommand
    {
        private readonly LiveViewConnector liveViewConnector;

        public MauiAgentVideoCaptureSourcesRequestCommand(LiveViewConnector liveViewConnector)
        {
            this.liveViewConnector = liveViewConnector;
        }

        public Task ExecuteAsync()
        {
            liveViewConnector.SendVideoCaptureSourcesToLiveView();
            return Task.CompletedTask;
        }
    }
}
