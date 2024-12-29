using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class GeneralOptionsPresenterDependencies : BasePresenterDependencies
    {
        public GeneralOptionsPresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IUserRepository<User> userRepository,
            ILogger<GeneralOptionsForm> logger)
            : base(generalOptionsRepository)
        {
            UserRepository = userRepository;
            Logger = logger;
        }

        public IUserRepository<User> UserRepository { get; private set; }

        public ILogger<GeneralOptionsForm> Logger { get; private set; }
    }
}
