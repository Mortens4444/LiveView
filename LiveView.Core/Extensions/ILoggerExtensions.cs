using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using System;

namespace LiveView.Core.Extensions
{
    public static class ILoggerExtensions
    {
        public static void LogException(this ILogger logger, Exception exception, string message = null)
        {
#if NET6_0_OR_GREATER
            logger.LogError(exception, message);
#else
            logger.LogError($"{message} {Lng.Elem("Exception details:")} {exception}");
#endif
        }
    }
}
