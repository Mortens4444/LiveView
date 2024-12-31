using LiveView.Core.Services;
using System;

namespace LiveView.Services
{
    public class Uptime
    {
        private static ulong startTick;

        static Uptime()
        {
            startTick = WinAPI.GetTickCount64();
        }

        public TimeSpan GetOs()
        {
            var uptimeMillis = WinAPI.GetTickCount64();
            return TimeSpan.FromMilliseconds(uptimeMillis);
        }

        public TimeSpan GetApp()
        {
            var uptimeMillis = WinAPI.GetTickCount64() - startTick;
            return TimeSpan.FromMilliseconds(uptimeMillis);
        }
    }
}
