using LiveView.Agent.Maui.Interfaces;

namespace LiveView.Agent.Maui.Network.Commands
{
    public class MauiAgentPanToWestAndTiltToSouthCommand : IAsyncCommand
    {
        public Task ExecuteAsync()
        {
            return Application.Current.MainPage.DisplayAlert("Information", "Pan to west and tilt to south", "OK");
        }
    }
}
