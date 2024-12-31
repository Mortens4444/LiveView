using Database.Interfaces;
using Database.Models;
using Mtf.Database;
using System.Collections.ObjectModel;

namespace Database.Repositories
{
    public sealed class LogRepository : BaseRepository<LogEntry>, ILogRepository
    {
        public ReadOnlyCollection<LogEntry> FilterLogs(LogEntryFilter logEntryFilter)
        {
            return Query("SelectLogEntry", logEntryFilter);
        }

        public void DeleteAll()
        {
            Execute("DeleteAllLogEntry");
        }
    }
}
