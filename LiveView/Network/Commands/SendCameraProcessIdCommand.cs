using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class SendCameraProcessIdCommand : ICommand
    {
        private readonly int cameraProcessId;
        private readonly Socket agentSocket;

        public SendCameraProcessIdCommand(string cameraProcessId, Socket agentSocket)
        {
            this.cameraProcessId = Parser.ToInt32(cameraProcessId);
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            var key = agentSocket.RemoteEndPoint.ToString();
            Globals.CameraProcesses[key] = cameraProcessId;
        }
    }
}
