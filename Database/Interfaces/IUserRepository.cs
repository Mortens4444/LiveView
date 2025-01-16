using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User Login(string username, string password);

        User SecondaryLogin(string text1, string text2);
    }
}
