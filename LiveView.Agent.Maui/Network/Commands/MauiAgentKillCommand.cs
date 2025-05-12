using LiveView.Agent.Maui.Interfaces;

namespace Sequence.Network.Commands
{
    public class MauiAgentKillCommand : IAsyncCommand
    {
        public async void ExecuteAsync()
        {
            Environment.Exit(0);
        }
    }
}
