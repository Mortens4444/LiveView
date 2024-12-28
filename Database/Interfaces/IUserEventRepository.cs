using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IUserEventRepository<TModel> : IRepository<TModel>
    {
        TModel GetByName(string name);
    }
}
