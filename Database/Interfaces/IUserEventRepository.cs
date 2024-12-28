using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IUserEventRepository<TModel> : IRepository<TModel>
    {
        UserEvent GetByName(string name);
    }
}
