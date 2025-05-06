using LiveView.Core.Interfaces;
using System;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class SendCameraProcessIdCommand : ICommand
    {
        private readonly int cameraProcessId;
        private readonly Socket agentSocket;

        public SendCameraProcessIdCommand(string cameraProcessId, Socket agentSocket)
        {
            Int32.TryParse(cameraProcessId, out this.cameraProcessId);
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            var key = agentSocket.RemoteEndPoint.ToString();
            Globals.CameraProcesses[key] = cameraProcessId;
        }
    }
}
