using Database.Interfaces;
using Database.Models;
using Mtf.Database;
using System.Collections.ObjectModel;

namespace Database.Repositories
{
    public sealed class LogRepository <TModel> : BaseRepository<TModel>, ILogRepository<TModel>
    {
        public ReadOnlyCollection<TModel> FilterLogs(LogEntryFilter logEntryFilter)
        {
            return Query("SelectLogEntry", logEntryFilter);
        }

        public void DeleteAll()
        {
            Execute("DeleteAllLogEntry");
        }
    }
}
