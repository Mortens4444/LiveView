using LiveView.Core.Interfaces;

namespace LiveView.Network.Commands
{
    public class UnregisterAgentCommand : ICommand
    {
        private readonly string hostInfo;

        public UnregisterAgentCommand(string hostInfo)
        {
            this.hostInfo = hostInfo;
        }

        public void Execute()
        {
            Globals.RemoveAgent(hostInfo);
        }
    }
}
