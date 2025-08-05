using Database.Interfaces;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LiveView.Services.Template
{
    public class TemplateStarter
    {
        private readonly IAgentRepository agentRepository;
        private readonly ITemplateProcessRepository templateProcessRepository;
        private readonly ILogger logger;
        private readonly PermissionManager<Database.Models.User> permissionManager;

        public TemplateStarter(PermissionManager<Database.Models.User> permissionManager, IAgentRepository agentRepository, ITemplateProcessRepository templateProcessRepository, ILogger logger)
        {
            this.permissionManager = permissionManager;
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
                        var userId = permissionManager.CurrentUser?.Tag.Id ?? 0;
                        var updatedParameters = ReplaceProcessParameter(templateProcess.ProcessParameters, 1, userId.ToString());
                        var process = AppStarter.Start(templateProcess.ProcessName, updatedParameters, logger);
                        if (templateProcess.ProcessName == Database.Constants.CameraAppExe)
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
                            MainPresenter.SentToClient(agent.ToString(), NetworkCommand.KillOnDisplay, Database.Constants.SequenceExe, displayId);
                            MainPresenter.SentToClient(agent.ToString(), Database.Constants.SequenceExe, agentId, userId, sequenceId, displayId, isMdi);
                        }
                    }
                }
            });
        }

        private static string ReplaceProcessParameter(string parameters, int index, string newValue)
        {
            if (String.IsNullOrWhiteSpace(parameters))
            {
                return newValue;
            }

            var parts = parameters.Split(' ').ToList();
            while (parts.Count <= index)
            {
                parts.Add(String.Empty);
            }

            parts[index] = newValue;
            return String.Join(" ", parts);
        }
    }
}
