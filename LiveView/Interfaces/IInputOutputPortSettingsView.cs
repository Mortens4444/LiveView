using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IInputOutputPortSettingsView : IView
    {
        CheckBox ChkZeroSignalled { get; }

        ComboBox CbInputOutputDevice { get; }

        ComboBox CbOperationOrEvent { get; }

        ComboBox CbOutputInputOutputPort { get; }

        ListView LvInputOutputDevices  { get; }

        ListView LvInputOutputPortRules { get; }
    }
}
