using System;
using System.Threading.Tasks;

namespace Watchdog
{
    class ServiceRunner
    {
        private readonly ProcessWatcher watcher;
        private readonly CpuMonitor cpuMonitor;

        public ServiceRunner(ProcessWatcher watcher, CpuMonitor cpuMonitor)
        {
            this.watcher = watcher;
            this.cpuMonitor = cpuMonitor;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                watcher.EnsureRunning();

                if (cpuMonitor.ShouldRestart(watcher.ProcessId))
                {
                    watcher.Kill();
                }

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
