using Database.Interfaces;
using Database.Models;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Core.Services.Logging
{
    public class LogRepositoryLoggerProvider : ILoggerProvider
    {
        private readonly PermissionManager<User> permissionManager;
        private readonly ILogRepository logRepository;
        private bool disposed;

        public LogRepositoryLoggerProvider(PermissionManager<User> permissionManager, ILogRepository logRepository)
        {
            this.permissionManager = permissionManager;
            this.logRepository = logRepository;
        }

        public ILogger CreateLogger(string categoryName)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(nameof(LogRepositoryLoggerProvider));
            }

            return new LogRepositoryLogger(permissionManager, logRepository, categoryName);
        }

        public void Dispose()
        {
            disposed = true;
        }
    }
}
