using Database.Enums;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using LiveView.Dto;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class RegisterVideoSourceCommand : ICommand
    {
        private readonly string hostInfo;
        private readonly long userId;
        private readonly string serverIp;
        private readonly string videoCaptureSource;
        private readonly long? displayId;
        private readonly int processId;
        private readonly CameraMode cameraMode;
        private readonly Socket agentSocket;

        public RegisterVideoSourceCommand(string hostInfo, string userId, string serverIp, string videoCaptureSource, string displayId, string processId, string cameraMode, Socket agentSocket)
        {
            this.hostInfo = hostInfo;
            this.agentSocket = agentSocket;
            this.serverIp = serverIp;
            this.videoCaptureSource = videoCaptureSource;

            this.userId = Parser.ToInt64(userId);
            this.displayId = Parser.ToNullableInt64(displayId);
            this.processId = Parser.ToInt32(processId);
            this.cameraMode = Parser.ToCameraMode(cameraMode);
        }

        public void Execute()
        {
            Globals.CameraProcessInfo.TryAdd(agentSocket, new CameraProcessInfo
            {
                LocalEndPoint = hostInfo,
                UserId = userId,
                ServerIp = serverIp,
                VideoCaptureSource = videoCaptureSource,
                DisplayId = displayId,
                ProcessId = processId,
                CameraMode = cameraMode
            });
        }
    }
}
