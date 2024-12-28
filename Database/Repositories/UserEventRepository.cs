using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class UserEventRepository<TModel> : BaseRepository<TModel>, IUserEventRepository<TModel>
    {
        public TModel GetByName(string name)
        {
            return QuerySingleOrDefault("SelectUserEventByName", new { Name = name });
        }
    }
}
