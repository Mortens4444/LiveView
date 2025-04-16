using LiveView.Core.Interfaces;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class RegisterAgentCommand : ICommand
    {
        private readonly string hostInfo;
        private readonly string hostName;
        private readonly Socket agentSocket;

        public RegisterAgentCommand(string hostInfo, string hostName, Socket agentSocket)
        {
            this.hostInfo = hostInfo;
            this.hostName = hostName;
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            Globals.Agents.Add(hostInfo, agentSocket);
            Globals.ControlCenter?.RefreshAgents();
        }
    }
}
