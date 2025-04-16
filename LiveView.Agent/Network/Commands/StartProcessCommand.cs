using LiveView.Core.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace LiveView.Agent.Network.Commands
{
    public class StartProcessCommand
    {
        private readonly ILogger<LiveViewConnector> logger;

        public StartProcessCommand(ILogger<LiveViewConnector> logger)
        {
            this.logger = logger;
        }

        public int StartProcess(string[] messageParts, Dictionary<long, Process> processes)
        {
            var process = AppStarter.Start(messageParts[0], messageParts[1], logger);
            processes.Add(process.Id, process);
            return process.Id;
        }
    }
}
