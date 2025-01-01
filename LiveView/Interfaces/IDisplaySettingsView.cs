using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IDisplaySettingsView : IBaseDisplayView
    {
        Panel FullScreenDisplay { get; }

        Panel FunctionChooser { get; }
    }
}
