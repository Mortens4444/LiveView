using CameraForms.Network.Commands;
using LiveView.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CameraForms.Services
{
    public abstract class BaseCommandFactory
    {
        protected Dictionary<string, Func<ICommand>> CommandMap { get; private set; }
        
        protected BaseCommandFactory(Dictionary<string, Func<ICommand>> commandMap)
        {
            CommandMap = commandMap;
        }

        public ReadOnlyCollection<ICommand> CreateCommands(string messages)
        {
            if (String.IsNullOrEmpty(messages))
            {
                return new ReadOnlyCollection<ICommand>(new List<ICommand>());
            }

            var result = new List<ICommand>();
            var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var message in allMessages)
            {
                var match = CommandMap.FirstOrDefault(x => message.StartsWith(x.Key, StringComparison.InvariantCulture));
                if (!String.IsNullOrEmpty(match.Key))
                {
                    result.Add(match.Value());
                }
                else
                {
                    result.Add(new ShowErrorCommand(message));
                }
            }
            return new ReadOnlyCollection<ICommand>(result);
        }
    }
}
