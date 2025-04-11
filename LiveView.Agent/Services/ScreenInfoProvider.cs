using Mtf.Network.Interfaces;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Agent.Services
{
    public class ScreenInfoProvider : IScreenInfoProvider
    {
        public string Id => Screen.PrimaryScreen.DeviceName;

        public Rectangle GetBounds()
        {
            return Screen.PrimaryScreen.Bounds;
        }

        public Size GetPrimaryScreenSize()
        {
            return Screen.PrimaryScreen.Bounds.Size;
        }
    }
}
