using LiveView.Core.Interfaces;
using LiveView.Dto;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class RegisterSequenceCommand : ICommand
    {
        private readonly string hostInfo;
        private readonly Socket agentSocket;
        private readonly long userId;
        private readonly long sequenceId;
        private readonly long displayId;
        private readonly bool isMdi;
        private readonly int processId;

        public RegisterSequenceCommand(string hostInfo, string userId, string sequenceId, string displayId, string isMdi, string processId, Socket agentSocket)
        {
            this.hostInfo = hostInfo;
            this.agentSocket = agentSocket;

            long.TryParse(userId, out this.userId);
            long.TryParse(sequenceId, out this.sequenceId);
            long.TryParse(displayId, out this.displayId);
            bool.TryParse(isMdi, out this.isMdi);
            int.TryParse(processId, out this.processId);
        }

        public void Execute()
        {
            Globals.SequenceProcesses.TryAdd(hostInfo, new SequenceProcessInfo
            {
                Socket = agentSocket,
                UserId = userId,
                SequenceId = sequenceId,
                DisplayId = displayId,
                IsMdi = isMdi,
                ProcessId = processId
            });
        }
    }
}
