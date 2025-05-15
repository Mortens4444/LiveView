using LiveView.Core.Interfaces;
using LiveView.Core.Services;
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
            this.sequenceId = Parser.ToInt32(sequenceId);
            this.processId = Parser.ToInt32(processId);
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            if (Globals.SequenceProcesses.ContainsKey(hostInfo))
            {
                Globals.SequenceProcesses.TryRemove(hostInfo, out var _);
            }
        }
    }
}
