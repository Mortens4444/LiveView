using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IUserEventRepository : IRepository<UserEvent>
    {
        UserEvent GetByName(string name);
    }
}
