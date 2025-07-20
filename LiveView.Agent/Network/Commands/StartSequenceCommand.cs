using LiveView.Agent.Dto;
using LiveView.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace LiveView.Agent.Network.Commands
{
    public class StartSequenceCommand : StartProcessCommand, ICommand
    {
        private readonly Dictionary<long, ProcessInfo> sequenceProcesses;
        private readonly string message;
        private readonly string[] messageParts;

        public StartSequenceCommand(Dictionary<long, ProcessInfo> sequenceProcesses, string message, string[] messageParts, ILogger<LiveViewConnector> logger) : base(logger)
        {
            this.sequenceProcesses = sequenceProcesses;
            this.message = message;
            this.messageParts = messageParts;
        }

        public void Execute()
        {
            Console.WriteLine($"Starting process {Database.Constants.SequenceExe} ({message}).");
            var sequenceProcessId = StartProcess(messageParts, sequenceProcesses);
            Console.WriteLine($"Process started with PID: {sequenceProcessId}.");
        }
    }
}
