using CameraForms.Network.Commands;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using Mtf.Permissions.Services;
using Sequence.Network.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sequence.Services
{
    public static class SequenceCommandFactory
    {
        public static List<ICommand> Create(Form form, GridSequenceManager gridSequenceManager,
            PermissionManager<User> permissionManager, IUserRepository userRepository, string messages)
        {
            var result = new List<ICommand>();
            var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var message in allMessages)
            {
                var messageParts = message.Split('|');

                if (message.StartsWith(NetworkCommand.Close.ToString(), StringComparison.InvariantCulture) ||
                    (message.StartsWith(NetworkCommand.Kill.ToString(), StringComparison.InvariantCulture)))
                {
                    result.Add(new CloseCommand(form));
                }
                else if (message.StartsWith(NetworkCommand.PlayOrPauseSequence.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new ChangeIsPausedStateCommand(gridSequenceManager));
                }
                else if (message.StartsWith(NetworkCommand.RearrangeGrids.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new RearrangeGridsCommand(gridSequenceManager));
                }
                else if (message.StartsWith(NetworkCommand.ShowNextGrid.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new ShowNextGridCommand(gridSequenceManager));
                }
                else if (message.StartsWith(NetworkCommand.ShowPreviousGrid.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new ShowPreviousGridCommand(gridSequenceManager));
                }
                else if (message.StartsWith(NetworkCommand.UserLoggedIn.ToString(), StringComparison.InvariantCulture))
                {
                    var user = userRepository.Select(Convert.ToInt32(messageParts[1]));
                    result.Add(new UserLoggedInCommand(permissionManager, user));
                }
                else if (message.StartsWith(NetworkCommand.UserLoggedOut.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new UserLoggedOutCommand(permissionManager));
                }
                else
                {
                    result.Add(new ShowErrorCommand(message));
                }
            }

            return result;
        }
    }
}
