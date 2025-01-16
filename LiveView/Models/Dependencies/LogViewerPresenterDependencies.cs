using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class LogViewerPresenterDependencies : BasePresenterDependencies
    {
        public LogViewerPresenterDependencies(
            PermissionManager<Database.Models.User> permissionManager,
            IGeneralOptionsRepository generalOptionsRepository,
            ILogRepository logRepository,
            IUserRepository userRepository,
            ILogger<LogViewer> logger)
            : base(generalOptionsRepository)
        {
            PermissionManager = permissionManager;
            LogRepository = logRepository;
            UserRepository = userRepository;
            Logger = logger;
        }

        public PermissionManager<Database.Models.User> PermissionManager { get; private set; }

        public ILogRepository LogRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }
        
        public ILogger<LogViewer> Logger { get; private set; }
    }
}
