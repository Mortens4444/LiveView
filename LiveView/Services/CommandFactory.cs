using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Network.Commands;
using Mtf.MessageBoxes;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace LiveView.Services
{
    public static class CommandFactory
    {
        public static List<ICommand> Create(byte[] data, Socket socket, MainPresenterDependencies dependencies)
        {
            var result = new List<ICommand>();
            var messages = $"{Globals.Server?.Encoding.GetString(data)}";
            var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var message in allMessages)
            {
                var messageParts = message.Split('|');

                if (message.StartsWith($"{NetworkCommand.RegisterAgent}|"))
                {
                    result.Add(new RegisterAgentCommand(messageParts[1], messageParts[2], messageParts[3], socket, dependencies));
                }
                else if (message.StartsWith($"{NetworkCommand.UnregisterAgent}|"))
                {
                    result.Add(new UnregisterAgentCommand(messageParts[1], socket));
                }
                else if (message.StartsWith($"{NetworkCommand.RegisterDisplay}|"))
                {
                    result.Add(new RegisterDisplayCommand(messageParts[1], messageParts[2], socket, dependencies));
                }
                else if (message.StartsWith($"{NetworkCommand.UnregisterDisplay}|"))
                {
                    result.Add(new UnregisterDisplayCommand(messageParts[1]));
                }
                else if (message.StartsWith($"{NetworkCommand.SendCameraProcessId}|"))
                {
                    result.Add(new SendCameraProcessIdCommand(messageParts[1], socket));
                }
                else if (message.StartsWith($"{NetworkCommand.RegisterSequence}|"))
                {
                    result.Add(new RegisterSequenceCommand(messageParts[1], messageParts[2], messageParts[3], messageParts[4], messageParts[5], messageParts[6], socket));
                }
                else if (message.StartsWith($"{NetworkCommand. UnregisterSequence}|"))
                {
                    result.Add(new UnregisterSequenceCommand(messageParts[1], messageParts[2], messageParts[3], socket));
                }
                else if (message.StartsWith($"{NetworkCommand.AgentDisconnected}|"))
                {
                    result.Add(new AgentDisconnectedCommand(messageParts[1], messageParts[2], socket, dependencies));
                }
                else if (message.StartsWith($"{NetworkCommand.VideoCaptureSourcesResponse}|"))
                {
                    result.Add(new VideoCaptureSourcesResponseReceivedCommand(messageParts[1], socket));
                }
                else if (message.StartsWith($"{NetworkCommand.RegisterCamera}"))
                {
                    result.Add(new RegisterCameraCommand(messageParts[1], messageParts[2], messageParts[3], messageParts[4], messageParts[5], messageParts[6], socket));
                }
                else if (message.StartsWith($"{NetworkCommand.UnregisterCamera}"))
                {
                    result.Add(new UnregisterCameraCommand(socket));
                }
                else if (message.StartsWith($"{NetworkCommand.SecondsLeftFromGrid}|"))
                {
                    result.Add(new SecondsLeftFromGridCommand(messageParts[1], messageParts[2]));
                }
                else if (message.StartsWith($"{NetworkCommand.RegisterVideoSource}"))
                {
                    result.Add(new RegisterVideoSourceCommand(messageParts[1], messageParts[2], messageParts[3], messageParts[4], messageParts[5], messageParts[6], messageParts[7], socket));
                }
                else if (message.StartsWith(NetworkCommand.UnregisterVideoSource.ToString()))
                {
                    result.Add(new UnregisterVideoSourceCommand(messageParts[1], messageParts[2], socket));
                }
                else if (message.StartsWith($"{NetworkCommand.Ping}|"))
                {
                    result.Add(new PingReceivedCommand(messageParts[1]));
                }
                else
                {
                    DebugErrorBox.Show("Unknown message arrived", message);
                }
            }
            return result;
        }
    }
}
