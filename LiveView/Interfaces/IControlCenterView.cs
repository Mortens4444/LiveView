using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IControlCenterView : IView
    {
        Point HomeLocation { get; }

        Panel PDisplayDevices { get; }

        void InitializeMouseUpdateTimer(Panel panel);
    }
}
