using LiveView.Agent.Dto;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveView.Agent.Network.Commands
{
    public class KillOnDisplayProcessCommand : ICommand
    {
        private readonly string application;
        private readonly long displayId;
        private readonly Dictionary<long, ProcessInfo> processes;

        public KillOnDisplayProcessCommand(string application, string displayId, Dictionary<long, ProcessInfo> processes)
        {
            this.application = application;
            this.processes = processes;
            _ = Int64.TryParse(displayId, out this.displayId);
        }

        public void Execute()
        {
            Console.WriteLine($"Killing process {application} on display with ID: {displayId}.");

            var keysToRemove = processes
                .Where(p => p.Value.DisplayId == displayId)
                .Select(p => p.Key)
                .ToList();

            foreach (var key in keysToRemove)
            {
                var proc = processes[key];
                ProcessUtils.Kill(proc.Process);
                Console.WriteLine($"Process killed ({proc.Process.Id}).");
                processes.Remove(key);
            }
        }
    }
}
