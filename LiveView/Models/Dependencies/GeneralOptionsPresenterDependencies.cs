using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class GeneralOptionsPresenterDependencies : BasePresenterDependencies
    {
        public GeneralOptionsPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IUserRepository userRepository,
            ILogger<GeneralOptionsForm> logger)
            : base(generalOptionsRepository)
        {
            UserRepository = userRepository;
            Logger = logger;
        }

        public IUserRepository UserRepository { get; private set; }

        public ILogger<GeneralOptionsForm> Logger { get; private set; }
    }
}
