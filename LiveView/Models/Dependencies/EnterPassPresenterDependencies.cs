using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class EnterPassPresenterDependencies : BasePresenterDependencies
    {
        public EnterPassPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IUserRepository userRepository,
            ILogger<EnterPass> logger)
            : base(generalOptionsRepository)
        {
            UserRepository = userRepository;
            Logger = logger;
        }

        public IUserRepository UserRepository { get; private set; }

        public ILogger<EnterPass> Logger { get; private set; }
    }
}
