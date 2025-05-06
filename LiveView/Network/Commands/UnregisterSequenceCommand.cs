using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using LiveView.Presenters;
using System;
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
            Int64.TryParse(sequenceId, out this.sequenceId);
            Int64.TryParse(processId, out this.processId);
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            if (Globals.SequenceProcesses.ContainsKey(hostInfo))
            {
                MainPresenter.SentToClient(hostInfo, NetworkCommand.Kill, Core.Constants.SequenceExe, processId);
                Globals.SequenceProcesses.TryRemove(hostInfo, out var process);
            }
        }
    }
}
