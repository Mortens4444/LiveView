using Database.Interfaces;
using Database.Models;
using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes.Exceptions;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Core.Services.Logging
{
    public class LogRepositoryLogger : ILogger
    {
        private readonly ILogRepository logRepository;
        private readonly string categoryName;
        private readonly long currentUserId;

        public LogRepositoryLogger(PermissionManager<User> permissionManager, ILogRepository logRepository, string categoryName)
        {
            this.logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
            this.categoryName = categoryName ?? throw new ArgumentNullException(nameof(categoryName));
            currentUserId = permissionManager.CurrentUser?.Tag.Id ?? 1;
        }

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

        public void Log<TState>(LogLevel logLevel, EventId logEventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            LogEntry logEntry;
            if (state is LogEntry stateLogEntry)
            {
                logEntry = stateLogEntry;
            }
            else
            {
                logEntry = new LogEntry
                {
                    OtherInformation = state.ToString()
                };
            }

            logEntry.Date = DateUtils.GetLogDateTime();
            logEntry.UserId = currentUserId;
            if (String.IsNullOrEmpty(logEntry.OtherInformation))
            {
                logEntry.OtherInformation = String.Empty;
            }
            logEntry.OtherInformation += exception?.GetDetails();
            logRepository.Insert(logEntry);
        }
    }
}
