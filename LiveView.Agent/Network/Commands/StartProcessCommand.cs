using LiveView.Core.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            var process = AppStarter.Start(messageParts[0], String.Join(" ", messageParts.Skip(1)), logger);
            //var error = process.StandardError.ReadToEnd();
            //if (!String.IsNullOrEmpty(error))
            //{
            //    ErrorBox.Show(Lng.Elem("General error"), error);
            //}
            processes.Add(process.Id, process);
            return process.Id;
        }
    }
}
