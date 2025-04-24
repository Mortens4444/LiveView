using LiveView.Core.Enums.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LiveView.Core.Services
{
    public static class ProcessUtils
    {
        public static int GetProcessId()
        {
#if NET6_0_OR_GREATER
            return Environment.ProcessId;
#else
            return Process.GetCurrentProcess().Id;
#endif
        }

        public static void ChangeExternalProcessesVisibility(List<Process> processes, CmdShow cmdShow)
        {
            var handles = WinAPI.FindMainWindows(processes);
            foreach (var process in processes)
            {
                Task.Run(() =>
                {
                    if (!process.HasExited)
                    {
                        var handle = handles[process];
                        WinAPI.ShowWindow(handle, cmdShow);
                    }
                });
            }
        }

        public static void Kill(IEnumerable<Process> processes)
        {
            foreach (var process in processes)
            {
                Kill(process);
            }
        }

        public static void Kill(Process process)
        {
            if (process == null)
            {
                return;
            }
            if (process.HasExited)
            {
                return;
            }

            process.CloseMainWindow();
            process.WaitForExit(300);
            if (!process.HasExited)
            {
#if NET5_0_OR_GREATER
                process.Kill(true);
#else
                process.Kill();
#endif
            }
        }
    }
}
