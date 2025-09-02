using LiveView.Agent.Maui.Interfaces;

namespace LiveView.Agent.Maui.Network.Commands
{
    public class MauiAgentKillAllCommand : IAsyncCommand
    {
        public Task ExecuteAsync()
        {
            return Application.Current.MainPage.DisplayAlert("Information", "Kill all", "OK");
        }
    }
}
