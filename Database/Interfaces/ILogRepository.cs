using Database.Models;
using Mtf.Database.Interfaces;
using System.Collections.ObjectModel;

namespace Database.Interfaces
{
    public interface ILogRepository : IRepository<LogEntry>
    {
        ReadOnlyCollection<LogEntry> FilterLogs(LogEntryFilter logEntryFilter);

        void DeleteAll();
    }
}
