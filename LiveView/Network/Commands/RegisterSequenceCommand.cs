using LiveView.Core.Interfaces;
using LiveView.Core.Services;
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

            var myAgentId = Parser.ToInt64(agentId);
            if (myAgentId != 0)
            {
                agent = dependencies.AgentRepository.Select(myAgentId);
            }
            this.userId = Parser.ToInt64(userId);
            this.sequenceId = Parser.ToInt64(sequenceId);
            this.displayId = Parser.ToInt64(displayId);
            bool.TryParse(isMdi, out this.isMdi);
            this.processId = Parser.ToInt32(processId);
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
