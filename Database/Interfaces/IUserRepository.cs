using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User Login(string encryptedUsername, string encryptedPassword);

        User SecondaryLogin(string encryptedUsername, string encryptedPassword);
    }
}
