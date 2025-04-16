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
#if NET462
            var display = Newtonsoft.Json.JsonConvert.DeserializeObject<DisplayDto>(displayJson);
#else
            var display = System.Text.Json.JsonSerializer.Deserialize<DisplayDto>(displayJson);
#endif
            DisplayManager.RemoteDisplays.Remove(display);
            if (Globals.ControlCenter != null)
            {
                Globals.ControlCenter.CachedDisplays = null;
            }
        }
    }
}
