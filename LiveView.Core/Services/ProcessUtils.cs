using LiveView.Core.Enums.Window;
using System.Collections.Generic;
using System.Diagnostics;

namespace LiveView.Core.Services
{
    public static class ProcessUtils
    {
        public static void ChangeExternalProcessesVisibility(List<Process> processes, CmdShow cmdShow)
        {
            var handles = WinAPI.FindMainWindows(processes);
            foreach (var process in processes)
            {
                if (!process.HasExited)
                {
                    var handle = handles[process];
                    WinAPI.ShowWindow(handle, cmdShow);
                }
            }
        }

        public static void KillExternalProcesses(List<Process> processes)
        {
            foreach (var process in processes)
            {
                process.CloseMainWindow();
                if (!process.HasExited)
                {
                    process.Kill();
                }
            }
        }
    }
}
