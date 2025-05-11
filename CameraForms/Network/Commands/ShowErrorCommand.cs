using LiveView.Core.Interfaces;
using Mtf.MessageBoxes;

namespace CameraForms.Network.Commands
{
    public class ShowErrorCommand : ICommand
    {
        private readonly string message;

        public ShowErrorCommand(string message)
        {
            this.message = message;
        }

        public void Execute()
        {
            ErrorBox.Show("General error", $"Unexpected message arrived: {message}");
        }
    }
}
