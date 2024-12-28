using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using System;

namespace LiveView.Extensions
{
    public static class ILoggerExtensions
    {
        public static void LogInfo<TLoggerType>(this ILogger<TLoggerType> logger, string message, params object[] args)
        {
            logger.LogInformation(String.Format(Lng.Elem(message), args));
        }
        
        public static void LogError<TLoggerType>(this ILogger<TLoggerType> logger, string message, params object[] args)
        {
            logger.LogError(String.Format(Lng.Elem(message), args));
        }

        public static void LogException<TLoggerType>(this ILogger<TLoggerType> logger, Exception exception, string message = null)
        {
            logger.LogError(exception, Lng.Elem(message ?? exception.Message));
        }

        public static void LogExceptionAndShowErrorBox<TLoggerType>(this ILogger<TLoggerType> logger, Exception exception, string message = null)
        {
            var showMessage = message ?? exception.Message;
            logger.LogException(exception, showMessage);
            ErrorBox.Show(Lng.Elem("General error"), Lng.Elem(showMessage));
        }
    }
}
