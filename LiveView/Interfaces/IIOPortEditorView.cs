using Database.Models;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IIOPortEditorView : IView
    {
        IOPort IOPort { get; }

        TextBox TbFriendlyName { get; }

        NumericUpDown NudMinTriggerTime { get; }

        NumericUpDown NudMaxSignalPerDay { get; }
    }
}
