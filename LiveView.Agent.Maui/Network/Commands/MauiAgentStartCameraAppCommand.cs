using LiveView.Agent.Maui.Interfaces;

namespace LiveView.Agent.Maui.Network.Commands
{
    public class MauiAgentStartCameraAppCommand : IAsyncCommand
    {
        public Task ExecuteAsync()
        {
            return Application.Current.MainPage.DisplayAlert("Information", "Start CameraApp.exe", "OK");
        }
    }
}
