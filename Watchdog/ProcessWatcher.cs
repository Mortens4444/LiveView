using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Watchdog
{
    class ProcessWatcher
    {
        private readonly AppSettings settings;
        private Process process;

        public ProcessWatcher(AppSettings settings) => this.settings = settings;

        public void EnsureRunning()
        {
            if (process == null || process.HasExited)
            {
                process = FindProcess() ?? StartProcess();
            }
        }

        public void Kill()
        {
            if (process != null && !process.HasExited)
            {
                process.Kill();
                process.WaitForExit();
            }
        }

        private Process FindProcess()
        {
            var exeName = Path.GetFileNameWithoutExtension(settings.ProcessPath);
            return Process.GetProcessesByName(exeName).FirstOrDefault();
        }

        private Process StartProcess()
        {
            var newProcess = new Process
            {
                StartInfo = new ProcessStartInfo(settings.ProcessPath)
                {
                    UseShellExecute = true
                }
            };

            newProcess.Start();
            return newProcess;
        }

        public int? ProcessId => process?.Id;
    }
}
