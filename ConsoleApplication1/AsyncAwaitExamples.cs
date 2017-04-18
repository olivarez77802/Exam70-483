using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JesseTesting.App
{
    // Async and Await are not supported until C# 5.0
    // Class called by Delegate.cs
    // async and await are markers which mark code positions from where control should resume after a task (thread) completes.
    
    // Called by Delegate.cs
    class AsyncAwaitExamples
    {
       
        public static void AsyncEx1Main()
        {
            // Notice "New Thread is displayed first
            Method();
            Console.WriteLine("Main thread");
            Console.ReadLine();
        }

        public static void Method()
        {
            Task.Factory.StartNew(new Action(LongTask));   // Invoking this Task in a Parallel Way
            Console.WriteLine("New Thread");
        }

        public static void LongTask()
        {
            Thread.Sleep(20000);
        }

        //public static void AsyncEx2Main()
        //{
        //    // Notice "New Thread is displayed first
        //    Method2();
        //    Console.WriteLine("Main thread");
        //    Console.ReadLine();
        //}

        //public static async void Method2()
        //{
        //    await Task.Factory.StartNew(new Action(LongTask));   // Invoking this Task in a Parallel Way
        //    Console.WriteLine("New Thread");
        //}

        
    }
}
