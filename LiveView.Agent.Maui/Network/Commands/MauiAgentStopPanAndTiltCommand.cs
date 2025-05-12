using LiveView.Agent.Maui.Interfaces;

namespace Sequence.Network.Commands
{
    public class MauiAgentStopPanAndTiltCommand : IAsyncCommand
    {
        public async void ExecuteAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Information", "Stop pan and tilt", "OK");
        }
    }
}
