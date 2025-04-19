using LiveView.Core.Dto;
using LiveView.Core.Extensions;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using LiveView.Models.Dependencies;
using System.Linq;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class RegisterDisplayCommand : ICommand
    {
        private readonly string hostInfo;
        private readonly string displayJson;
        private readonly Socket agentSocket;
        private readonly MainPresenterDependencies mainPresenterDependencies;

        public RegisterDisplayCommand(string hostInfo, string displayJson, Socket agentSocket, MainPresenterDependencies mainPresenterDependencies)
        {
            this.hostInfo = hostInfo;
            this.displayJson = displayJson;
            this.agentSocket = agentSocket;
            this.mainPresenterDependencies = mainPresenterDependencies;
        }

        public void Execute()
        {
#if NET462
            var display = Newtonsoft.Json.JsonConvert.DeserializeObject<DisplayDto>(displayJson);
#else
            var display = System.Text.Json.JsonSerializer.Deserialize<DisplayDto>(displayJson);
#endif
            var agent = mainPresenterDependencies.AgentRepository.SelectWhere(new { ServerIp = hostInfo.GetIpAddessFromEndPoint() }).FirstOrDefault();
            if (agent != null)
            {
                display.AgentId = agent.Id;
                display.AgentHostInfo = hostInfo;
            }

            display.Socket = agentSocket;
            DisplayManager.RemoteDisplays.Add(display);
        }
    }
}
