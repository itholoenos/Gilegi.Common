using System;
using System.Collections.Generic;
using System.Threading;

namespace Gilegi.Common.Utilities
{
    /// <summary>
    /// utility to retry actions
    /// </summary>
    public static class Retry
    {
        /// <summary>
        /// retry an action without return value (void)
        /// </summary>
        /// <param name="action"></param>
        /// <param name="retryInterval"></param>
        /// <param name="retryCount"></param>
        public static void Do(Action action, TimeSpan retryInterval, int retryCount = 3)
        {
            Do<object>(() => {
                action();
                return null;
            }, retryInterval, retryCount);
        }

        /// <summary>
        /// retry and action with return value of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="retryInterval"></param>
        /// <param name="retryCount"></param>
        /// <returns></returns>
        public static T Do<T>(Func<T> action, TimeSpan retryInterval, int retryCount = 3)
        {
            var exceptions = new List<Exception>();

            for (int retry = 0; retry < retryCount; retry++)
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                    Thread.Sleep(retryInterval);
                }
            }

            throw new AggregateException(exceptions);
        }
    }
}
