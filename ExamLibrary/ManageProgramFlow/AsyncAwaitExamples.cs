using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exam70483
{
    // Async and Await are not supported until C# 5.0
    // Class called by Delegate.cs
    // async and await are markers which mark code positions from where control should resume after a task (thread) completes.
    
    // Called by Delegate.cs
    public class AsyncAwaitExamples
    {
       
        public static void AsyncEx1Main()
        {
            /* Display Order:
             * New Thread
             * Main Thread
             * End Async Main 1
             * End Long Task
            */ 
            Method();
            Console.WriteLine("Main thread");
            Console.WriteLine("End Async Main 1");
            Console.ReadLine();
        }

        static void Method()
        {
            Task.Factory.StartNew(new Action(LongTask));   // Invoking this Task in a Parallel Way -Starts a new thread
            Console.WriteLine("New Thread");               // back to Main Thread - Does NOT wait! Returns to Primary 
                                                           // Thread.
        }

        static void LongTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("End Long Task");
        }

        public static void AsyncEx2Main()
        {
            /*
             * Display Order:
             * Main Thread
             * End Async Main 2
             * End Long Task
             * New Thread
            */
              Method2();
              Console.WriteLine("Main thread");
              Console.WriteLine("End Async Main 2");
              Console.ReadLine();
        }

        static async void Method2()
        {
            await Task.Factory.StartNew(new Action(LongTask));   // Invoking this Task in a Parallel Way - starts a new thread
            Console.WriteLine("New Thread");                     // await forces you to wait until task is finished.  Returns 
                                                                 // to execution outside Method2.
        }

        
    }
}
