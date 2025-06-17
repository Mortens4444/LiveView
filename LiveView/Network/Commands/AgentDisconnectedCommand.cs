using LiveView.Core.Interfaces;
using LiveView.Models.Dependencies;
using System.Linq;

namespace LiveView.Network.Commands
{
    public class AgentDisconnectedCommand : ICommand
    {
        private readonly string serverIp;
        private readonly string videoSourceName;
        private readonly MainPresenterDependencies mainPresenterDependencies;

        public AgentDisconnectedCommand(string serverIp, string videoSourceName, MainPresenterDependencies mainPresenterDependencies)
        {
            this.serverIp = serverIp;
            this.videoSourceName = videoSourceName;
            this.mainPresenterDependencies = mainPresenterDependencies;
        }

        public void Execute()
        {
            var agent = mainPresenterDependencies.AgentRepository.SelectWhere(new { ServerIp = serverIp }).FirstOrDefault();
            var videoSources = mainPresenterDependencies.VideoSourceRepository.SelectWhere(new { AgentId = agent.Id, Name = videoSourceName });
            foreach (var videoSource in videoSources)
            {
                mainPresenterDependencies.AgentRepository.DeleteWhere(new { VideoSourceId = videoSource.Id });
            }
        }
    }
}
