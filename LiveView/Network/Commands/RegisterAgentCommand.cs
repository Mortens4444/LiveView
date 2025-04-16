using LiveView.Core.Interfaces;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class RegisterAgentCommand : ICommand
    {
        private readonly string hostInfo;
        private readonly Socket agentSocket;

        public RegisterAgentCommand(string hostInfo, Socket agentSocket)
        {
            this.hostInfo = hostInfo;
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            Globals.Agents.Add(hostInfo, agentSocket);
        }
    }
}
