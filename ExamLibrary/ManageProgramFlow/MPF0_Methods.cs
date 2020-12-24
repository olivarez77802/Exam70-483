using System;
using System.Collections.Generic; 
/* using System.Linq;
using System.Text; */
using System.Threading;
using System.Threading.Tasks;

namespace Exam70483
{
    class MPF0_Methods : IMenu
    {
        public void MenuOpt0()
        {
            AsyncAwaitExamples.AsyncEx1Main();
           
        }

        public void MenuOpt1()
        {
            AsyncAwaitExamples.AsyncEx2Main();
            
        }

        public void MenuOpt2()
        {
            TaskLibExamples.Menu();
           
        }

        public void MenuOpt3()
        {
            ThreadPoolExample.Method();
        }

        public void MenuOpt4()
        {
            ContinuationExample();
            
        }

        public void MenuOpt5()
        {
            Console.WriteLine("Start of Parallel ForEach Example");
            ParallelForEachExample();
            Console.WriteLine("Start of Parallel For Example");
            ParallelForExample();
            Console.ReadKey();
           
        }
        public void MenuOpt6()
        {
            throw new NotImplementedException();
        }
        private static void ContinuationExample()
        {
            /*
            // Do not  need tx.Start
               ContinueWith does an implicit Wait so that it does not execute until Previous Task has completed
            */
            var t1 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 1500)).ContinueWith((PrevTask) => DoSomeOtherVeryImportantWork(1, 2000));
            var t2 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000));
            var t3 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000));

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
        private static void DoSomeVeryImportantWork(int id, int Sleeptime)
        {
            Console.WriteLine("task {0} is beginning Sleeptime {1}", id, Sleeptime);
            Thread.Sleep(Sleeptime);
            Console.WriteLine("task {0} has completed", id);
        }
        private static void DoSomeOtherVeryImportantWork(int id, int Sleeptime)
        {
            Console.WriteLine("Do_some_other task {0} is beginning Sleeptime {1}", id, Sleeptime);
            Thread.Sleep(Sleeptime);
            Console.WriteLine("Do_some_other task {0} has completed", id);
        }
        private static void ParallelForEachExample()
        {
            var intList = new List<int> { 1, 2, 5, 6, 8, 76, 5, 3, 54, 68, 78, 89, 9, 7, 6, 5, 4, 4 };
            // ThreadBlocking occurs with Parallel.ForEach.   Simulates a WaitAll.   "Press any Key to Quit is not
            // displayed until Parallel.ForEach is finished.
            Parallel.ForEach(intList, (i) => Console.WriteLine(i));
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();

        }
        private static void ParallelForExample()
        {
            /*
            // Parallel.For takes in a Range.   Will not display in order, but will execute in Parallel.   Blocks Threads
            // Simulates WaitAll.  Waits until all threads are finished.
            */
            Parallel.For(0, 100, (i) => Console.WriteLine(i));
            Console.WriteLine("Press any key to quit Example 9");
            Console.ReadKey();

        }

        
    }
}
