using Database.Models;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using System;

namespace LiveView.Extensions
{
    public static class ILoggerExtensions
    {
        private static void Log<TLoggerType>(this ILogger<TLoggerType> logger, LogLevel logLevel, LogEntry logEntry, Exception ex = null)
        {
            logger.Log(logLevel, new EventId(), logEntry, ex, (state, exception) =>
                $"LogEntry: Date={state.Date}, UserId={state.UserId}, OperationId={state.OperationId}, EventId={state.EventId}, OtherInformation={state.OtherInformation}"
            );
        }

        public static void LogInfo<TLoggerType>(this ILogger<TLoggerType> logger, Enum operation, string message, params object[] args)
        {
            logger.Log(LogLevel.Information, new LogEntry
            {
                Date = DateTime.UtcNow,
                OperationId = UniqueIdGenerator.Get(operation),
                OtherInformation = String.Format(message, args)
            });
        }

        public static void LogError<TLoggerType>(this ILogger<TLoggerType> logger, string message, params object[] args)
        {
            logger.Log(LogLevel.Error, new LogEntry
            {
                Date = DateTime.UtcNow,
                OtherInformation = String.Format(message, args)
            });
        }

        public static void LogException<TLoggerType>(this ILogger<TLoggerType> logger, Exception exception, string message = null)
        {
            logger.Log(LogLevel.Error, new LogEntry
            {
                Date = DateTime.UtcNow,
                OtherInformation = message ?? exception.Message
            }, exception);
        }

        public static void LogExceptionAndShowErrorBox<TLoggerType>(this ILogger<TLoggerType> logger, Exception exception, string message = null)
        {
            var showMessage = message ?? exception.Message;
            logger.LogException(exception, showMessage);
            ErrorBox.Show(Lng.Elem("General error"), Lng.Elem(showMessage));
        }
    }
}
