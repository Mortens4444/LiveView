using Database.Services;
using LiveView.Agent.Dto;
using LiveView.Core.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using System;
using System.Collections.Generic;
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

        public int StartProcess(string[] messageParts, Dictionary<long, ProcessInfo> processes)
        {
            if (messageParts == null || messageParts.Length == 0)
            {
                return -1;
            }

            var application = messageParts[0];
            var processArgs = messageParts.Skip(1);
            var redirect = AppConfig.GetBoolean(Database.Constants.StartAppsWithRedirectedOutput);
            var process = redirect ? AppStarter.StartWithRedirect(application, String.Join(" ", processArgs), logger) :
                AppStarter.Start(application, String.Join(" ", processArgs), logger);

            if (process == null)
            {
                ErrorBox.Show(Lng.Elem("General error"), Lng.FormattedElem("Unable to start process: {0}.", args: application));
                return -2;
            }

            if (redirect)
            {
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
            }

            var display = processArgs.ElementAt(processArgs.Count() - 2);
            Console.WriteLine($"StartProcess registering process... {String.Join(", ", processArgs)}, Display: {display}");
            if (Int64.TryParse(display, out var displayId))
            {
                processes?.Add(process.Id, new ProcessInfo { Process = process, DisplayId = displayId });
            }
            Console.WriteLine($"StartProcess process registered {process.Id}.");

            return process.Id;
        }
    }
}
