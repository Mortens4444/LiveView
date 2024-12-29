using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class LogViewerPresenterDependencies : BasePresenterDependencies
    {
        public LogViewerPresenterDependencies(
            PermissionManager permissionManager,
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            ILogRepository<LogEntry> logRepository,
            IUserRepository<User> userRepository,
            ILogger<LogViewer> logger)
            : base(generalOptionsRepository)
        {
            PermissionManager = permissionManager;
            LogRepository = logRepository;
            UserRepository = userRepository;
            Logger = logger;
        }

        public PermissionManager PermissionManager { get; private set; }

        public ILogRepository<LogEntry> LogRepository { get; private set; }

        public IUserRepository<User> UserRepository { get; private set; }
        
        public ILogger<LogViewer> Logger { get; private set; }
    }
}
