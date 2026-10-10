using Database.Interfaces;
using Database.Models;
using Mtf.Database;
using System.Collections.ObjectModel;

namespace Database.Repositories;

public sealed class LogRepository : BaseRepository<LogEntry, long>, ILogRepository
{
    public LogRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
    public ReadOnlyCollection<LogEntry> FilterLogs(LogEntryFilter logEntryFilter)
    {
        return Query("SelectWhereLogEntry", logEntryFilter);
    }

    public void DeleteAll()
    {
        Execute("DeleteAllLogEntry");
    }
}
