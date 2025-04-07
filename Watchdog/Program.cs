using System;

namespace Watchdog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var settings = AppSettings.Parse(args);

                var watcher = new ProcessWatcher(settings);
                var cpuMonitor = new CpuMonitor(settings);
                var serviceRunner = new ServiceRunner(watcher, cpuMonitor);

                serviceRunner.RunAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
