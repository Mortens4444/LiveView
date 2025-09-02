using LiveView.Agent.Maui.Interfaces;

namespace LiveView.Agent.Maui.Network.Commands
{
    public class MauiAgentZoomInCommand : IAsyncCommand
    {
        public Task ExecuteAsync()
        {
            return Application.Current.MainPage.DisplayAlert("Information", "Zoom in", "OK");
        }
    }
}
