using LiveView.Agent.Maui.Interfaces;

namespace Sequence.Network.Commands
{
    public class MauiAgentPanToWestAndTiltToNorthCommand : IAsyncCommand
    {
        public async void ExecuteAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Information", "Pan to west and tilt to north", "OK");
        }
    }
}
