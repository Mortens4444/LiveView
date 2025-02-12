using Database.Models;
using Mtf.Controls;

namespace LiveView.Interfaces
{
    public interface ILogViewerView : IView
    {
        MtfListView LvOperationsEventsAndErrors { get; }

        LogEntryFilter GetLogEntryFilter();
    }
}
