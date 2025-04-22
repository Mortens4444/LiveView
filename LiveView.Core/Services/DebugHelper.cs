using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;

namespace LiveView.Core.Services
{
    public static class DebugHelper
    {
        public static void Initialize()
        {
            if (Boolean.TryParse(ConfigurationManager.AppSettings[Constants.AttachDebugger], out var attach) && attach)
            {
                Debugger.Launch();
            }
            if (Int32.TryParse(ConfigurationManager.AppSettings[Constants.WaitAtStartup], out var waitTime))
            {
                Thread.Sleep(waitTime);
            }
        }
    }
}
