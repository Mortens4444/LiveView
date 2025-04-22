using LiveView.Core.Interfaces;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class UnregisterVideoSourceCommand : ICommand
    {
        private readonly Socket agentSocket;

        public UnregisterVideoSourceCommand(Socket agentSocket)
        {
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            Globals.CameraProcessInfo.TryRemove(agentSocket, out _);
        }
    }
}
