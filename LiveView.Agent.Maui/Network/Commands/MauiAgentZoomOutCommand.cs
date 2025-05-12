using LiveView.Agent.Maui.Interfaces;

namespace Sequence.Network.Commands
{
    public class MauiAgentZoomOutCommand : IAsyncCommand
    {
        public async void ExecuteAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Information", "Zoom out", "OK");
        }
    }
}
