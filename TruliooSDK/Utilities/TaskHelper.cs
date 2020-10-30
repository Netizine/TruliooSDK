using System;
using System.Threading.Tasks;

namespace TruliooSDK.Utilities
{
    public static class TaskHelper
    {
        /// <summary>
        /// Runs asynchronous tasks synchronously and throws the first caught exception
        /// </summary>
        /// <param name="t">The task to be run synchronously</param>
        public static void RunTaskSynchronously(Task t)
        {
            try
            {
                Task.WaitAll(t);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count > 0)
                {
                    throw ex.InnerExceptions[0];
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
