using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class LogRepository <TModel> : BaseRepository<TModel>, ILogRepository<TModel>
    {
    }
}
