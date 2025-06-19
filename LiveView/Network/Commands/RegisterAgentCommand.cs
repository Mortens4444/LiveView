using LiveView.Core.Interfaces;
using LiveView.Models.Dependencies;
using Mtf.Extensions;
using System;
using System.Linq;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class RegisterAgentCommand : ICommand
    {
        private readonly string hostInfo;
        private readonly string hostName;
        private readonly ushort vncServerPort;
        private readonly Socket agentSocket;
        private readonly MainPresenterDependencies dependencies;

        public RegisterAgentCommand(string hostInfo, string hostName, string vncServerPort, Socket agentSocket, MainPresenterDependencies dependencies)
        {
            this.hostInfo = hostInfo;
            this.hostName = hostName;
            _ = UInt16.TryParse(vncServerPort, out this.vncServerPort);
            this.agentSocket = agentSocket;
            this.dependencies = dependencies;
        }

        public void Execute()
        {
            Globals.Agents.Add(hostInfo, agentSocket);
            var serverIp = hostInfo.GetIpAddressFromEndPoint();
            var agent = dependencies.AgentRepository.SelectWhere(new { ServerIp = serverIp }).FirstOrDefault();
            var newAgent = new Database.Models.Agent
            {
                Id = agent?.Id ?? 0,
                ServerIp = serverIp,
                VncServerPort = vncServerPort,
                AgentPort = hostInfo.GetPortFromEndPoint()
            };
            if (agent == null)
            {
                dependencies.AgentRepository.Insert(newAgent);
            }
            else
            {
                dependencies.AgentRepository.Update(newAgent);
            }
        }
    }
}
