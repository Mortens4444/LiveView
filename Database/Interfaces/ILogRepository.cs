using Database.Models;
using Mtf.Database.Interfaces;
using System.Collections.ObjectModel;

namespace Database.Interfaces
{
    public interface ILogRepository<TModel> : IRepository<TModel>
    {
        ReadOnlyCollection<TModel> FilterLogs(LogEntryFilter logEntryFilter);

        void DeleteAll();
    }
}
