using Database.Models;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface ILogViewerView : IView
    {
        void AddLogEntry(ListViewItem item);
        void ClearLogItems();
        LogEntryFilter GetLogEntryFilter();
    }
}
