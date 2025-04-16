using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LiveView.Agent.Network.Commands
{
    public class KillAllProcessCommand : ICommand
    {
        private readonly string application;
        private readonly Dictionary<long, Process> processes;

        public KillAllProcessCommand(string application, Dictionary<long, Process> processes)
        {
            this.processes = processes;
            this.application = application;
        }

        public void Execute()
        {
            Console.WriteLine($"Killing all processes of {application}.");
            ProcessUtils.Kill(processes.Values);
            processes.Clear();
        }
    }
}
