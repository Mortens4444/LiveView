using LiveView.Core.Interfaces;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class UnregisterCameraCommand : ICommand
    {
        private readonly string hostInfo;
        private readonly string hostName;
        private readonly Socket agentSocket;

        public UnregisterCameraCommand(string hostInfo, string hostName, Socket agentSocket)
        {
            this.hostInfo = hostInfo;
            this.hostName = hostName;
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            Globals.CameraProcessInfo.TryRemove(agentSocket, out _);
        }
    }
}
