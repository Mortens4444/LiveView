using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IDisplaySettingsView : IView
    {
        Panel FullScreenDisplay { get; }

        Panel FunctionChooser { get; }
    }
}
