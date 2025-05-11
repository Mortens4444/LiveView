using LiveView.Core.Dto;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;

namespace LiveView.Network.Commands
{
    public class UnregisterDisplayCommand : ICommand
    {
        private readonly string displayJson;

        public UnregisterDisplayCommand(string displayJson)
        {
            this.displayJson = displayJson;
        }

        public void Execute()
        {
            var display = DisplayDto.GetFromJsonText(displayJson);
            DisplayManager.RemoteDisplays.Remove(display);
        }
    }
}
