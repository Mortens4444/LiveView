using LiveView.Core.Services;
using System;
using System.Runtime.InteropServices;

namespace LiveView.Agent.Services
{
    public static class ConsoleWindow
    {
        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("User32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void Hide()
        {
            if (AppConfig.GetBoolean(Core.Constants.LiveViewAgentHideConsoleWindow))
            {
                const int SW_HIDE = 0;
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_HIDE);
            }
        }
    }
}
