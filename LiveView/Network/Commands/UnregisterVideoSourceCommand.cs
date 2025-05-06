using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using LiveView.Presenters;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class UnregisterVideoSourceCommand : ICommand
    {
        private readonly Socket agentSocket;

        public UnregisterVideoSourceCommand(Socket agentSocket)
        {
            this.agentSocket = agentSocket;
        }

        public void Execute()
        {
            Globals.CameraProcessInfo.TryRemove(agentSocket, out var process);
            var key = agentSocket.RemoteEndPoint.ToString();
            if (Globals.CameraProcesses.ContainsKey(key))
            {
                MainPresenter.SentToClient(key, NetworkCommand.Kill, Core.Constants.CameraAppExe, process.ProcessId);
                Globals.CameraProcesses.Remove(key);
            }
        }
    }
}
