using LiveView.Agent.Maui.Interfaces;

namespace LiveView.Agent.Maui.Network.Commands
{
    public class MauiAgentPanToWestCommand : IAsyncCommand
    {
        public Task ExecuteAsync()
        {
            return Application.Current.MainPage.DisplayAlert("Information", "Pan to west", "OK");
        }
    }
}
