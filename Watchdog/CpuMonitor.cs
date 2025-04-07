using System;
using System.Collections.Generic;
using System.Linq;

namespace Watchdog
{
    using System.Diagnostics;

    class CpuMonitor
    {
        private readonly AppSettings settings;
        private readonly Queue<double> lastUsages = new Queue<double>(3);

        public CpuMonitor(AppSettings settings) => this.settings = settings;

        public bool ShouldRestart(int? processId)
        {
            if (processId is null || settings.MinCpuUsage is null)
            {
                return false;
            }

            using (var counter = new PerformanceCounter("Process", "% Processor Time", GetInstanceName(processId.Value)))
            {
                var usage = counter.NextValue() / Environment.ProcessorCount;
                lastUsages.Enqueue(usage);

                if (lastUsages.Count > 3)
                {
                    lastUsages.Dequeue();
                }

                return lastUsages.Count == 3 && lastUsages.All(x => x < settings.MinCpuUsage);
            }
        }

        private static string GetInstanceName(int pid)
        {
            var processes = Process.GetProcesses();
            foreach (var proc in processes)
            {
                if (proc.Id == pid)
                {
                    return proc.ProcessName;
                }
            }
            throw new InvalidOperationException("Process not found");
        }
    }
}
