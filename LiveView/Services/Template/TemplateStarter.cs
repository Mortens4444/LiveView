using Database.Interfaces;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LiveView.Services.Template
{
    public class TemplateStarter
    {
        private readonly ITemplateProcessRepository templateProcessRepository;

        public TemplateStarter(ITemplateProcessRepository templateProcessRepository)
        {
            this.templateProcessRepository = templateProcessRepository;
        }

        public void StartTemplate(Database.Models.Template template, ILogger logger)
        {
            Task.Run(() =>
            {
                foreach (var sequenceProcess in Globals.SequenceProcesses)
                {
                    Globals.Server.SendMessageToClient(sequenceProcess.Value.SequenceSocket, NetworkCommand.Close.ToString(), true);
                }

                var processes = templateProcessRepository.SelectWhere(new { TemplateId = template.Id });
                foreach (var process in processes)
                {
                    if (process.ProcessName == Core.Constants.CameraAppExe)
                    {
                        ControlCenterPresenter.CameraProcess = AppStarter.Start(process.ProcessName, process.ProcessParameters, logger);
                    }
                    else
                    {
                        ControlCenterPresenter.SequenceProcesses.Add(AppStarter.Start(process.ProcessName, process.ProcessParameters, logger));
                    }
                }
            });
        }
    }
}
