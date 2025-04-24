using LiveView.Core.Interfaces;
using LiveView.Dto;
using LiveView.Models.Dependencies;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class RegisterSequenceCommand : ICommand
    {
        private readonly string hostInfo;
        private readonly Socket sequenceSocket;
        private readonly long userId;
        private readonly Database.Models.Agent agent;
        private readonly long sequenceId;
        private readonly long displayId;
        private readonly bool isMdi;
        private readonly int processId;

        public RegisterSequenceCommand(string hostInfo, string userId, string sequenceId, string displayId, string isMdi, string processId, string agentId, Socket sequenceSocket, MainPresenterDependencies dependencies)
        {
            this.hostInfo = hostInfo;
            this.sequenceSocket = sequenceSocket;

            if (long.TryParse(agentId, out var myAgentId) && myAgentId != 0)
            {
                agent = dependencies.AgentRepository.Select(myAgentId);
            }
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
                Agent = agent,
                SequenceSocket = sequenceSocket,
                UserId = userId,
                SequenceId = sequenceId,
                DisplayId = displayId,
                IsMdi = isMdi,
                ProcessId = processId
            });
        }
    }
}
