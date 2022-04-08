using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam70483.MenuManageProgramFlow
{
    class ManageMultithreadingMenu
    // class ManageProgramFlow_1
    {
        public static void Menu()
        {
            IMenu MPF1 = new MPF1_Methods();
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Manage Mulithreading - Synchronize resources; implement locking; cancel a long-running task; \n ");
                Console.WriteLine(" Implement thread-safe methods to handle race conditions. \n ");
                Console.WriteLine(" 0.  Threading Examples");
                Console.WriteLine(" 1.  CancellationTokenSource with Task.Factory");
                Console.WriteLine(" 2.  CancellationTokenSource with TaskFactory");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: MPF1.MenuOpt0();
                            break;
                    case 1: MPF1.MenuOpt1();
                            break;
                    case 2: MPF1.MenuOpt2();
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
        
    }
}
