using Database.Models;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IInputOutputPortEditorView : IView
    {
        InputOutputPort InputOutputPort { get; }

        TextBox TbFriendlyName { get; }

        NumericUpDown NudMinTriggerTime { get; }

        NumericUpDown NudMaxSignalPerDay { get; }
    }
}
