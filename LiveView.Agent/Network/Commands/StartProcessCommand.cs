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
            if (messageParts == null || messageParts.Length == 0)
            {
                return -1;
            }

            var application = messageParts[0];
            var process = AppStarter.StartWithRedirect(application, String.Join(" ", messageParts.Skip(1)), logger);

            if (process == null)
            {
                ErrorBox.Show(Lng.Elem("General error"), String.Format(Lng.Elem("Unable to start process: {0}."), application));
                return -2;
            }

            process.ErrorDataReceived += (sender, args) =>
            {
                if (!String.IsNullOrEmpty(args.Data))
                {
                    ErrorBox.Show(Lng.Elem("General error"), args.Data);
                }
            };
            process.BeginErrorReadLine();

            process.OutputDataReceived += (sender, args) =>
            {
                if (!String.IsNullOrEmpty(args.Data))
                {
                    InfoBox.Show(Lng.Elem("Information"), args.Data);
                }
            };
            process.BeginOutputReadLine();

            Console.WriteLine("StartProcess registering process...");
            processes?.Add(process.Id, process);
            Console.WriteLine($"StartProcess process registered {process.Id}.");

            return process.Id;
        }
    }
}
