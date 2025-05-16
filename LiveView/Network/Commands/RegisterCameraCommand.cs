using Database.Enums;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using LiveView.Dto;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class RegisterCameraCommand : ICommand
    {
        private readonly string hostInfo;
        private readonly long userId;
        private readonly long cameraId;
        private readonly long? displayId;
        private readonly int processId;
        private readonly CameraMode cameraMode;
        private readonly Socket agentSocket;

        public RegisterCameraCommand(string hostInfo, string userId, string cameraId, string displayId, string processId, string cameraMode, Socket agentSocket)
        {
            this.hostInfo = hostInfo;
            this.agentSocket = agentSocket;
            this.userId = Parser.ToInt32(userId);
            this.cameraId = Parser.ToInt32(cameraId); 
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
                CameraId = cameraId,
                DisplayId = displayId,
                ProcessId = processId,
                CameraMode = cameraMode
            });
        }
    }
}
