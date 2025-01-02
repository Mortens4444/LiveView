using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IDisplaySettingsView : IBaseDisplayView
    {
        Panel FullScreenDisplay { get; }

        Panel FunctionChooser { get; }

        RadioButton RbShowOnControlCentersSelectedDisplay { get; }

        RadioButton RbShowOnFullscreenDisplay { get; }

        RadioButton RbShowOnControlCentersSelectedDisplay2 { get; }

        RadioButton RbShowOnFullscreenDisplay2 { get; }
    }
}
