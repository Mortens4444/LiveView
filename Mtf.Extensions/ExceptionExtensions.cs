using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Mtf.Extensions
{
    public static class ExceptionExtensions
    {
        public static int GetErrorCode(this Exception ex)
        {
            return Marshal.GetHRForException(ex);
        }

        public static string GetDetails(this Exception exception)
        {
            return exception == null ?
                throw new ArgumentNullException(nameof(exception)) :
                GetDetails(exception, exception.GetType().Name);
        }

        public static string GetDetails(this Exception exception, string title)
        {
            var result = new StringBuilder();
            var ex = exception;
            var i = 1;
            while (ex != null)
            {
                var exceptionDetails = GetExceptionDetails($"{title} {i++}", ex);
                _ = result.AppendLine(exceptionDetails);
                ex = ex.InnerException;
            }

            return result.ToString();
        }

        public static string GetLastInnerExceptionMessage(this Exception exception)
        {
            var result = String.Empty;
            var ex = exception;
            while (ex != null)
            {
                result = ex.Message;
                ex = ex.InnerException;
            }
            return result;
        }

        private static string GetExceptionDetails(string title, Exception exception)
        {
            return $"-------------------------- {title} ----------------------------{Environment.NewLine}" +
                $"Type: {exception.GetType()}{Environment.NewLine}" +
                $"Message: {exception.Message}{Environment.NewLine}" +
                $"StackTrace: {exception.StackTrace}{Environment.NewLine}" +
                $"------------------------- {title} End --------------------------{Environment.NewLine}";
        }
    }
}
