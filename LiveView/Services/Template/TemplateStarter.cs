using Database.Interfaces;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System.Globalization;
using System;
using System.Threading.Tasks;

namespace LiveView.Services.Template
{
    public class TemplateStarter
    {
        private readonly IAgentRepository agentRepository;
        private readonly ITemplateProcessRepository templateProcessRepository;
        private readonly ILogger logger;

        public TemplateStarter(IAgentRepository agentRepository, ITemplateProcessRepository templateProcessRepository, ILogger logger)
        {
            this.logger = logger;
            this.agentRepository = agentRepository;
            this.templateProcessRepository = templateProcessRepository;
        }

        public void StartTemplate(Database.Models.Template template)
        {
            Task.Run(() =>
            {
                foreach (var sequenceProcess in Globals.SequenceProcesses)
                {
                    Globals.Server.SendMessageToClient(sequenceProcess.Value.SequenceSocket, NetworkCommand.Close.ToString(), true);
                }

                var templateProcesses = templateProcessRepository.SelectWhere(new { TemplateId = template.Id });
                foreach (var templateProcess in templateProcesses)
                {
                    if (templateProcess.AgentId == null)
                    {
                        var process = AppStarter.Start(templateProcess.ProcessName, templateProcess.ProcessParameters, logger);
                        if (templateProcess.ProcessName == Core.Constants.CameraAppExe)
                        {
                            ControlCenterPresenter.CameraProcess = process;
                        }
                        else
                        {
                            ControlCenterPresenter.SequenceProcesses.Add(process);
                        }
                    }
                    else
                    {
                        var args = templateProcess.ProcessParameters.Split(' ');
                        var agentId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
                        var userId = Convert.ToInt64(args[1], CultureInfo.InvariantCulture);
                        var sequenceId = Convert.ToInt64(args[2], CultureInfo.InvariantCulture);
                        var displayId = Convert.ToInt64(args[3], CultureInfo.InvariantCulture);
                        var isMdi = Convert.ToBoolean(args[4], CultureInfo.InvariantCulture);
                        var agent = agentRepository.Select(agentId);
                        if (agent != null)
                        {
                            MainPresenter.SentToClient($"{agent}", NetworkCommand.KillOnDisplay, Core.Constants.SequenceExe, displayId);
                            MainPresenter.SentToClient($"{agent}", Core.Constants.SequenceExe, agentId, userId, sequenceId, displayId, isMdi);
                        }
                    }
                }
            });
        }
    }
}
