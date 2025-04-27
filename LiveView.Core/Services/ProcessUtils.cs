using LiveView.Core.Enums.Window;
using Mtf.MessageBoxes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            var actualProcesses = processes.ToList();
            var handles = WinAPI.FindMainWindows(actualProcesses);
            foreach (var process in actualProcesses)
            {
                Task.Run(() =>
                {
                    if (!process.HasExited && handles.TryGetValue(process, out var handle))
                    {
                        WinAPI.ShowWindow(handle, cmdShow);
                    }
                });
            }
        }

        public static void Kill(IEnumerable<Process> processes)
        {
            var actualProcesses = processes.ToList();
            foreach (var process in actualProcesses)
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
            try
            {
                if (process.HasExited)
                {
                    return;
                }
            }
            catch (InvalidOperationException ex)
            {
                // Process already exited or not available.
                DebugErrorBox.Show(ex);
                return;
            }

            try
            {
                process.CloseMainWindow();
                process.WaitForExit(300);
            }
            catch (Exception ex)
            {
                // Ignore any error while closing window.
                DebugErrorBox.Show(ex);
            }

            try
            {
                if (!process.HasExited)
                {
#if NET5_0_OR_GREATER
                    process.Kill(true);
#else
                    process.Kill();
#endif
                }
            }
            catch (Exception ex)
            {
                // Ignore any error while killing process.
                DebugErrorBox.Show(ex);
            }
        }
    }
}
