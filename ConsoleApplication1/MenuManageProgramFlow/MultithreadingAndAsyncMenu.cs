using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam70483.MenuManageProgramFlow
{
    class MultithreadingAndAsyncMenu
   //  class ManageProgramFlow_0
    {
        #region Menu
        public static void Menu()
        {
            IMenu MPF0 = new MultiThreadingAndAsync_Methods();

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Implement multithreading and and asynchronous processing \n ");
                Console.WriteLine("Use the Task Parallel lib, including the Parallel.For method, PLINQ, Tasks;");
                Console.WriteLine("create continuation tasks; spawn threads by using ThreadPool; unblock the UI;");
                Console.WriteLine("use async and await keywords; manage data by using concurrent collections.");
                Console.WriteLine(" 0.  Async and Await Examples");
                Console.WriteLine(" 1.  Async and Await Examples continued ");
                Console.WriteLine(" 2.  Task Examples ");
                Console.WriteLine(" 3.  ThreadPool Examples ");
                Console.WriteLine(" 4.  Continuation Tasks ");
                Console.WriteLine(" 5.  Parallel For Tasks ");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: MPF0.MenuOpt0(); 
                        break;
                    case 1: MPF0.MenuOpt1();
                        break;
                    case 2: MPF0.MenuOpt2();
                         break;
                    case 3: MPF0.MenuOpt3();
                        break;
                    case 4: MPF0.MenuOpt4();
                        break;
                    case 5: MPF0.MenuOpt5();
                        break;
                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);
        }
        #endregion
       
    }
}
