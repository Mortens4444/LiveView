using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IIOPortSettingsView : IView
    {
        CheckBox ChkZeroSignalled { get; }

        ComboBox CbIODevice { get; }

        ComboBox CbOperationOrEvent { get; }

        ComboBox CbOutputIOPort { get; }

        ListView LvIODevices  { get; }

        ListView LvIOPortRules { get; }
    }
}
