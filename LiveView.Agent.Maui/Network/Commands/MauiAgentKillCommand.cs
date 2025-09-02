using LiveView.Agent.Maui.Interfaces;

namespace LiveView.Agent.Maui.Network.Commands
{
    public class MauiAgentKillCommand : IAsyncCommand
    {
        public Task ExecuteAsync()
        {
            Environment.Exit(0);
            return Task.CompletedTask;
        }
    }
}
