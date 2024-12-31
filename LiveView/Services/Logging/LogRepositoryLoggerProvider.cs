using Database.Interfaces;
using Database.Models;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Services.Logging
{
    public class LogRepositoryLoggerProvider : ILoggerProvider
    {
        private readonly PermissionManager permissionManager;
        private readonly ILogRepository logRepository;

        public LogRepositoryLoggerProvider(PermissionManager permissionManager, ILogRepository logRepository)
        {
            this.permissionManager = permissionManager;
            this.logRepository = logRepository;
        }

        public ILogger CreateLogger(string categoryName) => new LogRepositoryLogger(permissionManager, logRepository, categoryName);

        public void Dispose() { }
    }
}
