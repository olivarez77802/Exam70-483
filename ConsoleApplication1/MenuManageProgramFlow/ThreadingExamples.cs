using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Exam70483.MenuManageProgramFlow
{
    public class ThreadingExamples
    {
        /*
            Process.Start("");
            Process.Start("http://msdn.microsoft.com/en-us/library/c5kehkcz.aspx");

            Using Locking Mechanisms - One way to deal with data sharing is mutual exclusion.  Mutal exclusion is implemented in .NET
            in several ways: monitors, mutexes, semaphores, reader-writer locks.  Locking is both dangerous and resource-intensive. 
            Sometimes, you just need to perform simple operations, and you need to make sure that they are atomic.  To solve this
            kind of problem,.NET offers a class called Interlocked, defined in the System.Threading namespace.   The Interlocked
            class has only static methods, and all represent atomic operations, meaning they will be performed without being 
            interrupted by the scheduler.

            Monitors - Work Only with reference objects, not value objects.

            The lock keyword ensures that one thread does not enter a critical section of code while another thread is in the critical section. 

            If another thread tries to enter a locked code, it will wait, block, until the object is released.

           The section Threading (C# and Visual Basic) discusses threading.

           The lock keyword calls Enter at the start of the block and Exit at the end of the block.
            A ThreadInterruptedException is thrown if Interrupt interrupts a thread that is waiting to enter a lock statement.

           In general, avoid locking on a public type, or instances beyond your code's control. The common constructs 
            lock (this), lock (typeof (MyType)), and lock ("myLock") violate this guideline:

           •lock (this) is a problem if the instance can be accessed publicly.


           •lock (typeof (MyType)) is a problem if MyType is publicly accessible.


           •lock("myLock") is a problem because any other code in the process using the same string, will share the same lock. 


           Best practice is to define a private object to lock on, or a private static object variable to protect data common to all instances

           * Locking only works if you lock EVERYWHERE that shared state is vulnerable.
           * It is easy to forget locking somewhere
           * The logic to avoid deadlocks is hard
           * Locking is good on a small scale, but becomes unmanageable on a larger scale
           * Concurrent collections avoid the locking deadlock problems.
   */


        public static void Menu()
        {
           
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Threading Menu \n ");
                Console.WriteLine(" 0.  ..");
                Console.WriteLine(" 1.  Parm Thread Main \n ");
                Console.WriteLine(" 2.  Stop Thread \n");
                Console.WriteLine(" 3.  Thread Static Main \n");
                Console.WriteLine(" 4.  Thread Shared Resources 1 \n");
                Console.WriteLine(" 5.  Thread Shared Resources 2 \n");
                Console.WriteLine(" 6.  Thread Shared Resources 3 \n");
                Console.WriteLine(" 7.  Thread Shared Resources 4 \n");
                Console.WriteLine(" 8.  Lock Thread  \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: 
                        break;
                    case 1: ThreadingExamples.ParmThreadMain();
                        Console.ReadKey();
                        break;
                    case 2: ThreadingExamples.StopThread();
                        Console.ReadKey();
                        break;
                    case 3:
                        ThreadingExamples.ThreadStaticMain();
                        Console.ReadKey();
                        Console.WriteLine("Notice Total is same each time");
                        for (int i = 0; i < 3; i++)
                        {
                            ThreadingExamples.Thread_Shared_Resources1();
                        }
                        Console.ReadKey();

                        break;
                    case 4:
                        Console.WriteLine("Notice Total is different each time because of shared resources");
                        for (int i = 0; i < 3; i++)
                        {
                            ThreadingExamples.Thread_Shared_Resources2();
                        }
                        Console.ReadKey();

                        break;
                    case 5:
                        Console.WriteLine(" Using Lock with Threads ");
                        for (int i = 0; i < 3; i++)
                        {
                            ThreadingExamples.Thread_Shared_Resources3();
                        }
                        Console.ReadKey();

                        break;
                    case 6:
                        Console.WriteLine(" Using Monitor.Enter and Monitor.Exit to Lock  ");
                        for (int i = 0; i < 3; i++)
                        {
                            ThreadingExamples.Thread_Shared_Resources4();
                        }
                        Console.ReadKey();

                        break;
                    case 9:
                        Console.WriteLine("Threading with the effects of lock keyword");
                        ThreadingExamples.LockThreadMain();
                        Console.ReadKey();
                        x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        }

       
        #region ParmThreadMain
        //* Parameterized Threads
        static void ParmThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("Threadproc: {0}", i);
                Thread.Sleep(0);
            }
        }
        static void ParmThreadMain()
        {
            Console.WriteLine("*************** Begin ParmThreadMain ****************");
            Thread t = new Thread(new ParameterizedThreadStart(ParmThreadMethod));
            t.Start(15);
            /* 
             * Join blocks the current thread until the other thread is finished executing.
             * When the other thread finishes, Join will return and the the current thread
             * will be unblocked.
             */
            t.Join();
            Console.WriteLine("*************** End ParmThreadMain ******************");
        }
        // Example of Stopping a Thread along with coding an inline Thread
        #endregion
        #region StopThread
        static void StopThread()
        {
            Console.WriteLine("*************** Begin StopThread ********************");
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
                {
                    while (!stopped)
                    {
                        Console.WriteLine("Running...");
                        Thread.Sleep(1000);   // one second
                    }
                    Console.WriteLine("Thread is about to close");
                }));
            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            stopped = true;
            t.Join();
            Console.WriteLine("**************** End StopThread **********************");
        }
        #endregion
        #region ThreadStaticMain
        //Using ThreadStatic Attribute
        // Thread static will make it into two different threads
        // without Thread static becomes one thread
        [ThreadStatic]
        private static int _field;
        static void ThreadStaticMain()
        {
            Console.WriteLine("****************** Begin ThreadStaticMain ****************");
            Thread t1 = new Thread(new ThreadStart(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        _field++;
                        Console.WriteLine("Thread A: {0}", _field);

                    }
                }));
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);

                }
                Console.WriteLine("****************** End ThreadStaticMain ****************");
            }));
            t2.Start();

        }
        #endregion
        #region Thread_Shared_Resources1

        //Operates over the one main UI Thread
        static int Total1 = 0;
        static void Thread_Shared_Resources1()
        {
            AddOneMillion1();
            AddOneMillion1();
            AddOneMillion1();
            Console.WriteLine("Total = " + Total1);
        }
        #endregion
        #region Thread_Shared_Resources2
        // Threads do Time-Slicing spreading their time over three threads
        static int Total2 = 0;
        static void Thread_Shared_Resources2()
        {
            Thread thread1 = new Thread(AddOneMillion2);
            Thread thread2 = new Thread(AddOneMillion2);
            Thread thread3 = new Thread(AddOneMillion2);

            thread1.Start(); thread2.Start(); thread3.Start();
            thread1.Join(); thread2.Join(); thread3.Join();

            Console.WriteLine("Total = " + Total2);
        }
        #endregion
        #region Thread_Shared_Resources3
        static int Total3 = 0;
        static void Thread_Shared_Resources3()
        {
            Thread thread1 = new Thread(AddOneMillion3);
            Thread thread2 = new Thread(AddOneMillion3);
            Thread thread3 = new Thread(AddOneMillion3);

            thread1.Start(); thread2.Start(); thread3.Start();
            thread1.Join(); thread2.Join(); thread3.Join();

            Console.WriteLine("Total = " + Total3);
        }
        #endregion
        #region Thread_Shared_Resources4
        static int Total4 = 0;
        static void Thread_Shared_Resources4()
        {
            Thread thread1 = new Thread(AddOneMillion4);
            Thread thread2 = new Thread(AddOneMillion4);
            Thread thread3 = new Thread(AddOneMillion4);

            thread1.Start(); thread2.Start(); thread3.Start();
            thread1.Join(); thread2.Join(); thread3.Join();

            Console.WriteLine("Total = " + Total4);
        }
        #endregion
        #region LockThreadMain
        class Account
        {
            private Object thisLock = new Object();
            int balance;

            Random r = new Random();

            public Account(int initial)
            {
                balance = initial;
            }

            int Withdraw(int amount)
            {

                // This condition never is true unless the lock statement
                // is commented out.
                if (balance < 0)
                {
                    throw new Exception("Negative Balance");
                }

                // Comment out the next line to see the effect of leaving out 
                // the lock keyword.
                lock (thisLock)
                {
                    if (balance >= amount)
                    {
                        Console.WriteLine("Balance before Withdrawal :  " + balance);
                        Console.WriteLine("Amount to Withdraw        : -" + amount);
                        balance = balance - amount;
                        Console.WriteLine("Balance after Withdrawal  :  " + balance);
                        return amount;
                    }
                    else
                    {
                        return 0; // transaction rejected
                    }
                }
            }

            public void DoTransactions()
            {
                for (int i = 0; i < 100; i++)
                {
                    Withdraw(r.Next(1, 100));
                }
            }
        }

        //class Test
        //{
        public static void LockThreadMain()
        {
            Thread[] threads = new Thread[10];
            Account acc = new Account(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
        }
        //}

        #endregion
        #region AddOneMillion1-4
        static void AddOneMillion1()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                Total1++;
            }
        }
        static void AddOneMillion2()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                Total2++;
            }
        }
        static object _lock = new object();
        static void AddOneMillion3()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                lock (_lock)
                {
                    Total3++;
                }
            }
        }
        static object _lock4 = new object();
        static void AddOneMillion4()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                bool lockTaken = false;
                // if the lock is aquired the Enter method will update lockTaken to true.
                Monitor.Enter(_lock4, ref lockTaken);
                try
                {
                    Total4++;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(_lock4);
                }
            }
        }
        #endregion

       
    }
}
