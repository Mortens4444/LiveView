using LiveView.Core.Interfaces;
using System.Linq;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class VideoCaptureSourcesResponseReceivedCommand : ICommand
    {
        private readonly string cameraServers;
        private readonly Socket agentSocket;

        public VideoCaptureSourcesResponseReceivedCommand(string cameraServers, Socket agentSocket)
        {
            this.cameraServers = cameraServers;
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            var videoCaptureSources = cameraServers.Split(';')
                        .Select(vcs => vcs.Split('='))
                        .ToDictionary(vcs => vcs[0], vcs => vcs[1]);
            Globals.VideoCaptureSources.Add(agentSocket, videoCaptureSources);
        }
    }
}
