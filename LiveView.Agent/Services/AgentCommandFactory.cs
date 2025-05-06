using LiveView.Agent.Dto;
using LiveView.Agent.Network.Commands;
using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Mtf.Network;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace LiveView.Agent.Services
{
    public static class AgentCommandFactory
    {
        public static List<ICommand> Create(ILogger<LiveViewConnector> logger, Dictionary<string, Server> cameraServers, Dictionary<long, ProcessInfo> cameraProcesses, Dictionary<long, ProcessInfo> sequenceProcesses, Client client, byte[] data, Socket socket, Dictionary<string, VideoCapture> videoCaptures, Dictionary<string, CancellationTokenSource> cancellationTokenSources)
        {
            var result = new List<ICommand>();
            var messages = $"{client.Encoding.GetString(data)}";
            var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var message in allMessages)
            {
                var messageParts = message.Split('|');

                if (message.StartsWith($"{Core.Constants.CameraAppExe}|", StringComparison.InvariantCulture))
                {
                    result.Add(new StartCameraProcessCommand(cameraProcesses, client, message, messageParts, logger));
                }
                else if (message.StartsWith($"{Core.Constants.SequenceExe}|", StringComparison.InvariantCulture))
                {
                    result.Add(new StartSequenceCommand(sequenceProcesses, message, messageParts, logger));
                }
                else if (message.StartsWith($"{NetworkCommand.KillOnDisplay}|", StringComparison.InvariantCulture))
                {
                    var dict = messageParts[1] == Core.Constants.CameraAppExe ? cameraProcesses : sequenceProcesses;
                    result.Add(new KillOnDisplayProcessCommand(messageParts[1], messageParts[2], dict));
                }
                else if (message.StartsWith($"{NetworkCommand.Kill}|", StringComparison.InvariantCulture))
                {
                    var dict = messageParts[1] == Core.Constants.CameraAppExe ? cameraProcesses : sequenceProcesses;
                    result.Add(new KillProcessCommand(messageParts[1], messageParts[2], dict));
                }
                else if (message.StartsWith($"{NetworkCommand.KillAll}|", StringComparison.InvariantCulture))
                {
                    var dict = messageParts[1] == Core.Constants.CameraAppExe ? cameraProcesses : sequenceProcesses;
                    result.Add(new KillAllProcessCommand(messageParts[1], dict));
                }
                else if (message.StartsWith($"{NetworkCommand.VideoCaptureSourcesRequest}|", StringComparison.InvariantCulture))
                {
                    result.Add(new RequestVideoCaptureSourcesCommand(client, cameraServers));
                }
                else if (message.StartsWith($"{NetworkCommand.StopVideoCapture}|", StringComparison.InvariantCulture))
                {
                    result.Add(new StopVideoCapture(cancellationTokenSources, messageParts[1]));
                }
                else if (message.StartsWith($"{NetworkCommand.PanToEast}|", StringComparison.InvariantCulture))
                {
                    result.Add(new PanToEastCommand(videoCaptures, messageParts[1], messageParts[2]));
                }
                else if (message.StartsWith($"{NetworkCommand.TiltToNorth}|", StringComparison.InvariantCulture))
                {
                    result.Add(new TiltToNorthCommand(videoCaptures, messageParts[1], messageParts[2]));
                }
                else if (message.StartsWith($"{NetworkCommand.PanToEastAndTiltToNorth}|", StringComparison.InvariantCulture))
                {
                    result.Add(new PanToEastAndTiltToNorthCommand(videoCaptures, messageParts[1], messageParts[2]));
                }
                else if (message.StartsWith($"{NetworkCommand.PanToWestAndTiltToNorth}|", StringComparison.InvariantCulture))
                {
                    result.Add(new PanToWestAndTiltToNorthCommand(videoCaptures, messageParts[1], messageParts[2]));
                }
                else if (message.StartsWith($"{NetworkCommand.MoveToPresetZero}|", StringComparison.InvariantCulture))
                {
                }
                else if (message.StartsWith($"{NetworkCommand.TiltToSouth}|", StringComparison.InvariantCulture))
                {
                    result.Add(new TiltToSouthCommand(videoCaptures, messageParts[1], messageParts[2]));
                }
                else if (message.StartsWith($"{NetworkCommand.PanToEastAndTiltToSouth}|", StringComparison.InvariantCulture))
                {
                    result.Add(new PanToEastAndTiltToSouthCommand(videoCaptures, messageParts[1], messageParts[2]));
                }
                else if (message.StartsWith($"{NetworkCommand.PanToWestAndTiltToSouth}|", StringComparison.InvariantCulture))
                {
                    result.Add(new PanToWestAndTiltToSouthCommand(videoCaptures, messageParts[1], messageParts[2]));
                }
                else if (message.StartsWith($"{NetworkCommand.PanToWest}|", StringComparison.InvariantCulture))
                {
                    result.Add(new PanToWestCommand(videoCaptures, messageParts[1], messageParts[2]));
                }
                else if (message.StartsWith($"{NetworkCommand.StopPanAndTilt}|", StringComparison.InvariantCulture))
                {
                    result.Add(new StopPanAndTiltCommand(videoCaptures, messageParts[1]));
                }
                else if (message.StartsWith($"{NetworkCommand.StopZoom}|", StringComparison.InvariantCulture))
                {
                    result.Add(new StopZoomCommand(videoCaptures, messageParts[1]));
                }
                else if (message.StartsWith($"{NetworkCommand.ZoomIn}|", StringComparison.InvariantCulture))
                {
                    result.Add(new ZoomInCommand(videoCaptures, messageParts[1], messageParts[2]));
                }
                else if (message.StartsWith($"{NetworkCommand.ZoomOut}|", StringComparison.InvariantCulture))
                {
                    result.Add(new ZoomOutCommand(videoCaptures, messageParts[1], messageParts[2]));
                }
            }
            return result;
        }
    }
}
