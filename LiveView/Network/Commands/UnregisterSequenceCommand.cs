using LiveView.Core.Interfaces;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class UnregisterSequenceCommand : ICommand
    {
        private readonly string hostInfo;
        private readonly long sequenceId;
        private readonly long processId;
        private readonly Socket agentSocket;

        public UnregisterSequenceCommand(string hostInfo, string sequenceId, string processId, Socket agentSocket)
        {
            this.hostInfo = hostInfo;
            long.TryParse(sequenceId, out this.sequenceId);
            long.TryParse(processId, out this.processId);
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            Globals.SequenceProcesses.TryRemove(hostInfo, out _);
        }
    }
}
