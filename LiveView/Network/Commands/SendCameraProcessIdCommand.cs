using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using LiveView.Presenters;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class SendCameraProcessIdCommand : ICommand
    {
        private readonly int cameraProcessId;
        private readonly Socket agentSocket;

        public SendCameraProcessIdCommand(string cameraProcessId, Socket agentSocket)
        {
            int.TryParse(cameraProcessId, out this.cameraProcessId);
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            var key = agentSocket.RemoteEndPoint.ToString();
            if (Globals.CameraProcesses.ContainsKey(key))
            {
                MainPresenter.SentToClient(key, NetworkCommand.Kill, Core.Constants.CameraAppExe, cameraProcessId);
                Globals.CameraProcesses.Remove(key);
            }
            Globals.CameraProcesses.Add(key, cameraProcessId);
        }
    }
}
