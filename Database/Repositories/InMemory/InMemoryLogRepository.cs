using Database.Interfaces;
using Database.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Database.Repositories.InMemory;

public sealed class InMemoryLogRepository : InMemoryRepository<LogEntry, long>, ILogRepository
{
    /// <summary>Same as SelectWhereLogEntry.sql: newest first, paged with Offset and MaxRows.</summary>
    public ReadOnlyCollection<LogEntry> FilterLogs(LogEntryFilter logEntryFilter)
    {
        if (logEntryFilter == null)
        {
            throw new ArgumentNullException(nameof(logEntryFilter));
        }

        lock (SyncRoot)
        {
            var entries = Items
                .Where(entry => entry.Date >= logEntryFilter.From && entry.Date <= logEntryFilter.To)
                .Where(entry => MatchesLogType(entry, logEntryFilter.LogType))
                .Where(entry => logEntryFilter.OtherInformationPart == null
                    || (entry.OtherInformation != null && entry.OtherInformation.IndexOf(logEntryFilter.OtherInformationPart, StringComparison.OrdinalIgnoreCase) >= 0))
                .Where(entry => logEntryFilter.UserId == 0 || entry.UserId == logEntryFilter.UserId)
                .OrderByDescending(entry => entry.Date)
                .Skip((int)Math.Max(0, logEntryFilter.Offset));

            if (logEntryFilter.MaxRows > 0)
            {
                entries = entries.Take(logEntryFilter.MaxRows);
            }

            return Copy(entries);
        }
    }

    public override ReadOnlyCollection<LogEntry> SelectWhere(object param)
    {
        return param is LogEntryFilter logEntryFilter ? FilterLogs(logEntryFilter) : base.SelectWhere(param);
    }

    public void DeleteAll()
    {
        lock (SyncRoot)
        {
            Items.Clear();
        }
    }

    private static bool MatchesLogType(LogEntry entry, int logType)
    {
        switch (logType)
        {
            case 1:
                return entry.OperationId.HasValue;
            case 2:
                return entry.UserEventId.HasValue;
            case 3:
                return !entry.OperationId.HasValue && !entry.UserEventId.HasValue;
            default:
                return true;
        }
    }
}
