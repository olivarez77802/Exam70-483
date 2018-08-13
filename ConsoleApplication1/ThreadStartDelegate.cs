using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
// using System.Threading.Tasks;

namespace Exam70483
{
    /*
     * Namespace  System.Threading
     * 
     * ParameterizedThreadStart Delegate
     * https://msdn.microsoft.com/en-us/library/system.threading.parameterizedthreadstart(v=vs.110).aspx
     * 
     *  // Delegates are type safe function pointers.   It is type safe because the signature the delegate points to 
         should match the signature of the delegate.
        
         ThreadStart is a delegate in System.Threading
        
         Why does a delegate need to be passed as a parameter to the Thread Class Constructor ? 
         The purpose of creating a Thread is to execute a function.  A delegate is a type safe function
         pointer, meaning it points to a function that the thread has to execute.  In short, all threads
         require an entry point. i.e. a pointer to the function where they should begin exectution
         So threads always require a delegate.
        
         In the code below, we are not explicitily creating the ThreadStart delegate, then how is it working?
                    Thread T1 = new Thread(Number.PrintNumbers);
                    T1.Start();
        
          The framework automatically rewrites it to the below behind the scenes :
                    Thread T1 = new Thread(new ThreadStart(Numbers.PrintNumbers));
                    T1.Start();
        
          We can also rewrite using the delegate keyword.
                    Thread T1 = new Thread(delegate() {Number.PrintNumbers(); });
        
          Also can be rewritten using a lambda expression
                    Thread T1 = new Thread(() => Numbers.PrintNumbers());
        

     * 
     */
    class ThreadStartDelegate
    {
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Parameterized Thread Menu \n ");
                Console.WriteLine(" 0.  ThreadMain - 2 Threads \n ");
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
                        ThreadMain();
                        Console.ReadKey();
                        break;
                    case 1:
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.ReadKey();
                        break;
                    case 3:
                         break;
                    case 4:
                         break;
                    case 5:
                        Console.ReadKey();
                        break;
                    case 6:
                        break;
                    case 9:
                       break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        } //* end Menu

        #region ThreadMain
        static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc {0}", i);
                Thread.Sleep(0);
            }
        }
        static void ThreadMain()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main Thread: Do some work");
                Thread.Sleep(0);
            }
            t.Join();
            Console.WriteLine("After");

        }
        #endregion
    }
}
