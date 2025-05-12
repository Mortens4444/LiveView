using LiveView.Agent.Maui.Interfaces;

namespace Sequence.Network.Commands
{
    public class MauiAgentPanToEastCommand : IAsyncCommand
    {
        public async void ExecuteAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Information", "Pan to east", "OK");
        }
    }
}
