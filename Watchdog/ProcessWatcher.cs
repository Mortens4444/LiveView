using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Watchdog
{
    class ProcessWatcher
    {
        private readonly string processPath;
        private Process process;

        public ProcessWatcher(string processPath) => this.processPath = processPath;

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
            var exeName = Path.GetFileNameWithoutExtension(processPath);
            return Process.GetProcessesByName(exeName).FirstOrDefault();
        }

        private Process StartProcess()
        {
            var newProcess = new Process
            {
                StartInfo = new ProcessStartInfo(processPath)
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
