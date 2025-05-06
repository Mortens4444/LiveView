using LiveView.Agent.Dto;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveView.Agent.Network.Commands
{
    public class KillAllProcessCommand : ICommand
    {
        private readonly string application;
        private readonly Dictionary<long, ProcessInfo> processes;

        public KillAllProcessCommand(string application, Dictionary<long, ProcessInfo> processes)
        {
            this.processes = processes;
            this.application = application;
        }

        public void Execute()
        {
            Console.WriteLine($"Killing all processes of {application}.");
            ProcessUtils.Kill(processes.Values.Select(p => p.Process));
            processes.Clear();
        }
    }
}
