using LiveView.Core.Interfaces;
using System;

namespace LiveView.Network.Commands
{
    public class PingReceivedCommand : ICommand
    {
        private readonly string hostInfo;

        public PingReceivedCommand(string hostInfo)
        {
            this.hostInfo = hostInfo;
        }

        public void Execute()
        {
            Globals.AgentPingTimes[hostInfo] = DateTimeOffset.UtcNow;
        }
    }
}
