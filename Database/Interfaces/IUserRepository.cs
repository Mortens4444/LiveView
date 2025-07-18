using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User Login(string username, string encryptedPassword);

        User SecondaryLogin(string username, string encryptedPassword);
    }
}
