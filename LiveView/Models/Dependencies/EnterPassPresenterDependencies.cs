using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class EnterPassPresenterDependencies : BasePresenterDependencies
    {
        public EnterPassPresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IUserRepository<User> userRepository,
            ILogger<EnterPass> logger)
            : base(generalOptionsRepository)
        {
            UserRepository = userRepository;
            Logger = logger;
        }

        public IUserRepository<User> UserRepository { get; private set; }

        public ILogger<EnterPass> Logger { get; private set; }
    }
}
