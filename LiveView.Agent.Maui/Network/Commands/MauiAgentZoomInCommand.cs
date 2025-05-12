using LiveView.Agent.Maui.Interfaces;

namespace Sequence.Network.Commands
{
    public class MauiAgentZoomInCommand : IAsyncCommand
    {
        public async void ExecuteAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Information", "Zoom in", "OK");
        }
    }
}
