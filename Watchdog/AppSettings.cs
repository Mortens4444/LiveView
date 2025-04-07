using System;

namespace Watchdog
{
    class AppSettings
    {
        public string ProcessPath { get; private set; } = String.Empty;

        public double? MinCpuUsage { get; private set; }

        public TimeSpan CheckInterval { get; private set; } = TimeSpan.FromSeconds(5);

        public static AppSettings Parse(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new ArgumentException($"Missing process path. {Environment.NewLine}Usage: {AppDomain.CurrentDomain.FriendlyName} ProcessPath MinimumCpuUsage");
            }

            var settings = new AppSettings
            {
                ProcessPath = args[0],
                MinCpuUsage = null
            };

            if (args.Length > 1)
            {
                if (Double.TryParse(args[1], out var cpu))
                {
                    settings.MinCpuUsage = cpu;
                }
            }

            return settings;
        }
    }
}
