using System;
using System.Collections.Generic;
using System.Text;
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
            catch (AggregateException e)
            {
                if (e.InnerExceptions.Count > 0)
                    throw e.InnerExceptions[0];
                else
                    throw;
            }
        }
    }
}
