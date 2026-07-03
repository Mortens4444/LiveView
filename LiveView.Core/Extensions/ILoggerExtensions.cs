using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Core.Extensions
{
    public static class ILoggerExtensions
    {
        public static void LogException(this ILogger logger, Exception exception, string message = null)
        {
            logger.LogError(exception, message);
        }
    }
}
