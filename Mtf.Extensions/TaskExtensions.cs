using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Mtf.Extensions
{
    public static class TaskExtensions
    {
        public static Task LogExceptions(this Task task)
        {
            return task?.ContinueWith(t =>
            {
                if (t.Exception != null)
                {
                    var aggregateException = t.Exception.Flatten();
                    foreach (var exception in aggregateException.InnerExceptions)
                    {
                        Debug.WriteLine(exception);
                    }
                }
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
        }

        public static Task<T> LogExceptions<T>(this Task<T> task)
        {
            return task?.ContinueWith(t =>
            {
                if (t.Exception != null)
                {
                    var aggregateException = t.Exception.Flatten();
                    foreach (var exception in aggregateException.InnerExceptions)
                    {
                        Debug.WriteLine(exception);
                    }
                }
                return t.Result;
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Default);
        }
    }
}
