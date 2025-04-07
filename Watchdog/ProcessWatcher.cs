using System.Diagnostics;

namespace Watchdog
{
    class ProcessWatcher
    {
        private readonly AppSettings settings;
        private Process process;

        public ProcessWatcher(AppSettings settings) => this.settings = settings;

        public void EnsureRunning()
        {
            if (process?.HasExited != false)
            {
                StartProcess();
            }
        }

        public void Kill() => process?.Kill();

        private void StartProcess()
        {
            process = new Process
            {
                StartInfo = new ProcessStartInfo(settings.ProcessPath)
                {
                    UseShellExecute = true
                }
            };

            process.Start();
        }

        public int? ProcessId => process?.Id;
    }
}
