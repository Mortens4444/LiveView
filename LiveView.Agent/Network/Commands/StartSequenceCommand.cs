using LiveView.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LiveView.Agent.Network.Commands
{
    public class StartSequenceCommand : StartProcessCommand, ICommand
    {
        private readonly Dictionary<long, Process> sequenceProcesses;
        private readonly string message;
        private readonly string[] messageParts;

        public StartSequenceCommand(Dictionary<long, Process> sequenceProcesses, string message, string[] messageParts, ILogger<LiveViewConnector> logger) : base(logger)
        {
            this.sequenceProcesses = sequenceProcesses;
            this.message = message;
            this.messageParts = messageParts;
        }

        public void Execute()
        {
            Console.WriteLine($"Starting process {Core.Constants.SequenceExe} ({message}).");
            var sequenceProcessId = StartProcess(messageParts, sequenceProcesses);
            Console.WriteLine($"Process started with PID: {sequenceProcessId}.");
        }
    }
}
