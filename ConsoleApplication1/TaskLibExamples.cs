using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam70483
{
    /*
    // Threading does Time Slicing (versus parallel execution) on each core.
    // So multithreading is actually time slicing.
    //
    // Task Parallel Library(TPL) uses System.Threading.Tasks
    //
    // Parallel.For is from the Task Parallel Library
    // TPL encapsulates multicore execution.  Parallellism across
    // cores is taken care of by TPL.
    //
    //  Video uses Performance Monitor
    //  https://www.youtube.com/watch?v=No7QqSc5cl8
    
        Advanced C# - Task Parallel Library
        https://www.youtube.com/watch?v=gfkuD_eWM5Y&index=5&list=PLrzrNeNx3kNHUOzNmvX5gZy0scGLKpY7m

        System.Threading namespace is the old method.  The replacment is using the Task Parallel Library.
        The Task Parallel Library takes away the headache of asking yourself should I spawn a new thread or should I not.
        Should I reuse other threads that are idle and waiting, all of these issues are now taken care of with the Task
        Parallel Library.  It has been optimized for execution on machines that have either multi-core, single core, or dual
        processors.

        Threading versus Tasks
           Task - It doesn't create it's own Operate System thread (we avoid OS threads).  Task is executed by a Task Scheduler
           and allows us to return a result.  We can say task represent some asynchonous operaton through lightweight object for
           managing a parallelizable unit of work.  Task available in .Net 4.0 and above.

           Thread - is used for creating and maniupulating a thread in OS and allows us to fully control by using Resume, Abort, or Suspend methods.
                    Big disadvantage is the expense of creating threads.

       

    */
    // Called by Delegate.cs
    class TaskLibExamples
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Task Library Examples \n ");
                Console.WriteLine(" 0.  Task Example 0 \n ");
                Console.WriteLine(" 1.  Task Example 1 \n ");
                Console.WriteLine(" 2.  Task Example 2 - Task.Factory \n ");
                Console.WriteLine(" 3.  Task Example 3 - ContinueWith \n");
                Console.WriteLine(" 4.  Task Example 4 - Message \n");
                Console.WriteLine(" 5.  Task Example 5 - WaitAll \n");
                Console.WriteLine(" 6.  Task Example 6 - WaitAll \n");
                Console.WriteLine(" 7.  Task Example 7 - Parallel.ForEach \n");
                Console.WriteLine(" 8.  Task Example 8 - Paralle.ForEach \n");
                Console.WriteLine(" 9.  Quit - CanellationToken             \n\n ");
                Console.Write(" Enter Number to execute Routine ");
                 
                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: TaskExample_0();
                        break;
                    case 1:
                        TaskExample_1();
                        break;
                    case 2: TaskExample_2(); 
                        break;
                    case 3: TaskExample_3();
                        break;
                    case 4: TaskExample_4();
                        break;
                    case 5: TaskExample_5();
                        break;
                    case 6: TaskExample_6();
                        break;
                    case 7: TaskExample_7();
                        break;
                    case 8: TaskExample_8();
                        break;
                    case 9: TaskExample_9();  
                         Console.ReadKey();
                         x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }

                
            } while (x < 9);  // end do

        }  // end Menu()


        private static void TaskExample_0()
        {
            var t1 = new Task(() =>
            {
                Console.WriteLine("task 1 is beginning Sleep(1000) or 1 sec");
                Thread.Sleep(1000);
                Console.WriteLine("task 1 is completed");
            });
            t1.Start();
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
        private static void TaskExample_1()
        {
            var t1 = new Task(() => DoSomeVeryImportantWork(1, 1500));
            t1.Start();
            var t2 = new Task(() => DoSomeVeryImportantWork(2, 3000));
            t2.Start();
            var t3 = new Task(() => DoSomeVeryImportantWork(3, 1000));
            t3.Start();
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
        private static void TaskExample_2()
        {
            /*
            // Task Factory already has Start built in.  Do not  need tx.Start
            */
            var t1 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 1500));
            var t2 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000));
            var t3 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000));

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
        private static void TaskExample_3()
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
        public static void TaskExample_4()
        {
            // Do not  need tx.Start
            var t1 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 1500));
            var t2 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000));
            var t3 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000));

            // Notice :Press any key to quit is written before tasks are started           
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();

        }
        private static void TaskExample_5()
        {
            // Do not  need tx.Start
            var t1 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 1500));
            var t2 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000));
            var t3 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000));

            var tasklist = new List<Task> { t1, t2, t3 };

            // Waits until all tasks have completed before continuing with execution of the program.
            Task.WaitAll(tasklist.ToArray());

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();

        }
        private static void TaskExample_6()
        {
            // Do not  need tx.Start
            var t1 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 1500));
            var t2 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000));
            var t3 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000));

            var tasklist = new List<Task> { t1, t2, t3 };

            // Waits until all tasks have completed before continuing with execution of the program.
            Task.WaitAll(tasklist.ToArray());

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Doing some other work");
                Thread.Sleep(250);
                Console.WriteLine(" i = {0} ", i);
            }
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();

        }
        private static void TaskExample_7()
        {
            var intList = new List<int> { 1, 2, 5, 6, 8, 76, 5, 3, 54, 68, 78, 89, 9, 7, 6, 5, 4, 4 };
            // ThreadBlocking occurs with Parallel.ForEach.   Simulates a WaitAll.   "Press any Key to Quit is not
            // displayed until Parallel.ForEach is finished.
            Parallel.ForEach(intList, (i) => Console.WriteLine(i));
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();

        }
        private static void TaskExample_8()
        {
            /*
            // Parallel.For takes in a Range.   Will not display in order, but will execute in Parallel.   Blocks Threads
            // Simulates WaitAll.  Waits until all threads are finished.
            */
            Parallel.For(0, 100, (i) => Console.WriteLine(i));
            Console.WriteLine("Press any key to quit Example 9");
            Console.ReadKey();

        }
        private static void TaskExample_9()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            var t = Task.Factory.StartNew(() =>
            {
                foreach (var item in
                    Enumerable.Range(0, 100).AsParallel().WithCancellation(ct).Select(i => i).Where(i => i % 5 == 0))
                {
                    Console.WriteLine(" Example of Cancellation Token item is {0}", item);
                }
            }, ct);

            // Comment out Thread.Sleep if you want it to cancel, otherwise it will fishish before the cancel is called.

            Thread.Sleep(250);
            cts.Cancel();
            Console.WriteLine("Press any key to quit Example 10");
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
    }
}
