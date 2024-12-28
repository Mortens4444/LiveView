using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class GroupRepository<TModel> : BaseRepository<TModel>, IGroupRepository<TModel>
    {
        public TModel GetByName(string name)
        {
            return QuerySingleOrDefault("SelectGroupByName", new { Name = name });
        }
    }
}
