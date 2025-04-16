using LiveView.Core.Interfaces;
using LiveView.Models.Dependencies;
using SharpDX.DirectInput;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class UnregisterAgentCommand : ICommand
    {
        private readonly string hostInfo;
        private readonly string hostName;
        private readonly Socket agentSocket;
        private readonly MainPresenterDependencies dependencies;

        public UnregisterAgentCommand(string hostInfo, string hostName, Socket agentSocket, MainPresenterDependencies dependencies)
        {
            this.hostInfo = hostInfo;
            this.hostName = hostName;
            this.agentSocket = agentSocket;
            this.dependencies = dependencies;
        }

        public void Execute()
        {
            Globals.Agents.Remove(hostInfo);
            Globals.AgentPingTimes.Remove(hostInfo);
            Globals.VideoCaptureSources.Remove(agentSocket);
        }
    }
}
