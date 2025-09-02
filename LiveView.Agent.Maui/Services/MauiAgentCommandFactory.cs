using LiveView.Agent.Maui.Enums.Network;
using LiveView.Agent.Maui.Interfaces;
using LiveView.Agent.Maui.Network.Commands;

namespace LiveView.Agent.Maui.Services
{
    public static class MauiAgentCommandFactory
    {
        public static List<IAsyncCommand> Create(LiveViewConnector liveViewConnector, CancellationTokenSource cancellationTokenSource, string messages)
        {
            var result = new List<IAsyncCommand>();
            var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var message in allMessages)
            {
                var messageParts = message.Split('|');

                if (message.StartsWith("CameraApp.exe|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentStartCameraAppCommand());
                }
                else if (message.StartsWith("Sequence.exe|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentStartSequenceCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.Kill}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentKillCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.KillAll}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentKillAllCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.VideoCaptureSourcesRequest}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentVideoCaptureSourcesRequestCommand(liveViewConnector));
                }
                else if (message.StartsWith($"{NetworkCommand.StopVideoCapture}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentStopVideoCaptureCommand(cancellationTokenSource));
                }
                else if (message.StartsWith($"{NetworkCommand.PanToEast}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentPanToEastCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.TiltToNorth}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentTiltToNorthCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.PanToEastAndTiltToNorth}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentPanToEastAndTiltToNorthCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.PanToWestAndTiltToNorth}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentPanToWestAndTiltToNorthCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.MoveToPresetZero}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentMoveToPresetZeroCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.TiltToSouth}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentTiltToSouthCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.PanToEastAndTiltToSouth}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentPanToEastAndTiltToSouthCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.PanToWestAndTiltToSouth}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentPanToWestAndTiltToSouthCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.PanToWest}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentPanToWestCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.StopPanAndTilt}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentStopPanAndTiltCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.StopZoom}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentStopZoomCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.ZoomIn}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentZoomInCommand());
                }
                else if (message.StartsWith($"{NetworkCommand.ZoomOut}|", StringComparison.InvariantCulture))
                {
                    result.Add(new MauiAgentZoomOutCommand());
                }
            }

            return result;
        }
    }
}
