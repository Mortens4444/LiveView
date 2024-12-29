using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class ProfilePresenterDependencies : BasePresenterDependencies
    {
        public ProfilePresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IUserRepository<User> userRepository,
            ILogger<Profile> logger)
            : base(generalOptionsRepository)
        {
            UserRepository = userRepository;
            Logger = logger;
        }

        public IUserRepository<User> UserRepository { get; private set; }

        public ILogger<Profile> Logger { get; private set; }
    }
}
