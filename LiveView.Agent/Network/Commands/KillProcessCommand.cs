using LiveView.Agent.Dto;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using System;
using System.Collections.Generic;

namespace LiveView.Agent.Network.Commands
{
    public class KillProcessCommand : ICommand
    {
        private readonly string application;
        private readonly long processId;
        private readonly Dictionary<long, ProcessInfo> processes;

        public KillProcessCommand(string application, string processId, Dictionary<long, ProcessInfo> processes)
        {
            this.application = application;
            this.processes = processes;
            _ = Int64.TryParse(processId, out this.processId);
        }

        public void Execute()
        {
            Console.WriteLine($"Killing process {application} ({processId}).");
            if (processes.TryGetValue(processId, out var processInfo))
            {
                ProcessUtils.Kill(processInfo.Process);
                Console.WriteLine($"Process killed ({processInfo.Process.Id}).");
            }
            processes.Remove(processId);
        }
    }
}
