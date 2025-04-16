using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LiveView.Agent.Network.Commands
{
    public class KillProcessCommand : ICommand
    {
        private readonly string application;
        private readonly long processId;
        private readonly Dictionary<long, Process> processes;

        public KillProcessCommand(string application, string processId, Dictionary<long, Process> processes)
        {
            this.application = application;
            this.processes = processes;
            Int64.TryParse(processId, out this.processId);
        }

        public void Execute()
        {
            Console.WriteLine($"Killing process {application} ({processId}).");
            ProcessUtils.Kill(processes[processId]);
            processes.Remove(processId);
        }
    }
}
