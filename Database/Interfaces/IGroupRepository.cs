using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IGroupRepository<TModel> : IRepository<TModel>
    {
        Group GetByName(string name);
    }
}
