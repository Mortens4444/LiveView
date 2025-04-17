using LiveView.Core.Interfaces;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class UnregisterCameraCommand : ICommand
    {
        private readonly Socket agentSocket;

        public UnregisterCameraCommand(Socket agentSocket)
        {
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            Globals.CameraProcessInfo.TryRemove(agentSocket, out _);
        }
    }
}
