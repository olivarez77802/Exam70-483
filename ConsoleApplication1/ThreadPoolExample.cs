using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Exam70483
{
    class ThreadPoolExample
    {
        public static void TPEMain()
        {
            int maxThreads;
            int minThreads;
            int avaThreads;

            int comp1;
            int comp2;
            int comp3;

            ThreadPool.GetMaxThreads(out maxThreads, out comp1);
            Console.WriteLine("The Max Number of Threads: {0}", maxThreads);

            ThreadPool.GetMinThreads(out minThreads, out comp2);
            Console.WriteLine("The Min Number of Threads: {0}", minThreads);

            ThreadPool.GetAvailableThreads(out avaThreads, out comp3);
            Console.WriteLine("The number of available Threads: {0}", avaThreads);
            
        }
    }
}
