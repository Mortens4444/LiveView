using Database.Enums;
using LiveView.Core.Interfaces;
using LiveView.Dto;
using System;
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
            Int64.TryParse(userId, out this.userId);
            Int64.TryParse(cameraId, out this.cameraId);


            this.displayId = !String.IsNullOrEmpty(displayId) ? (long?)Convert.ToInt64(displayId) : null;

            Int32.TryParse(processId, out this.processId);
            if (Int32.TryParse(cameraMode, out var cameraModeNumber))
            {
                this.cameraMode = (CameraMode)cameraModeNumber;
            }
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
