using LiveView.Core.Interfaces;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class UnregisterAgentCommand : ICommand
    {
        private readonly string hostInfo;
        private readonly Socket agentSocket;

        public UnregisterAgentCommand(string hostInfo, Socket agentSocket)
        {
            this.hostInfo = hostInfo;
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            Globals.RemoveAgent(hostInfo, agentSocket);
        }
    }
}
