using LiveView.Core.Interfaces;
using LiveView.Models.Dependencies;
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
            var serverIp = hostInfo.Split(':')[0];
            //var videoSources = dependencies.VideoSourceRepository.SelectWhere(new { ServerIp = serverIp, VideoSourceName = hostName }); /// VideoSourceName = hostName <- This is a bug, it never worked, but I think it should not delete them
            //foreach (var videoSource in videoSources)
            //{
            //    dependencies.AgentRepository.DeleteWhere(new { VideoSourceId = videoSource.Id });
            //}
            Globals.ControlCenter?.RefreshAgents();
        }
    }
}
