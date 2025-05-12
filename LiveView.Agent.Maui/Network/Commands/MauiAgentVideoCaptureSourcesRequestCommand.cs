using LiveView.Agent.Maui;
using LiveView.Agent.Maui.Interfaces;

namespace Sequence.Network.Commands
{
    public class MauiAgentVideoCaptureSourcesRequestCommand : IAsyncCommand
    {
        private readonly LiveViewConnector liveViewConnector;

        public MauiAgentVideoCaptureSourcesRequestCommand(LiveViewConnector liveViewConnector)
        {
            this.liveViewConnector = liveViewConnector;
        }

        public async void ExecuteAsync()
        {
            liveViewConnector.SendVideoCaptureSourcesToLiveView();
        }
    }
}
