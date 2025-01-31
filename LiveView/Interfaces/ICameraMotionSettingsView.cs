using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface ICameraMotionSettingsView : IView
    {
        NumericUpDown NudMotionTrigger { get; }

        NumericUpDown NudMotionTriggerMinimumLength { get; }

        ComboBox CbPartnerVideoServer { get; }

        ComboBox CbPartnerCamera { get; }

        ListView LvCameras { get; }
    }
}
