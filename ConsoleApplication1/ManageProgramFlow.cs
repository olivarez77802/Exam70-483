using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483
{
    class ManageProgramFlow
    {
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Manage Program Flow \n");
                Console.WriteLine(" 0.  Implement MultiThreading and ASynchrounous Processing \r ");
                Console.WriteLine("     Use the Task Parallel library (ParallelFor,Plinq,Tasks); \r");
                Console.WriteLine("     create continuation tasks; spawn threads by using ThreadPool; \r");
                Console.WriteLine("     unblock the UI; use async and await keywords; manage data by using \r");
                Console.WriteLine("     concurrent collections.  \r ");
                Console.WriteLine(" 1.  Manage MultiThreading \r ");
                Console.WriteLine("     Synchronized resources; implement locking; cancel a long running task; \r ");
                Console.WriteLine("     implement thread safe methods to handle race conditions \r ");
                Console.WriteLine(" 2.  Implement Program Flow \r ");
                Console.WriteLine("     Iterate across collection and array items; program decisions \r");
                Console.WriteLine("     by using switch statements, if/then, and operators; \r ");
                Console.WriteLine("     evaluate expressions \r ");
                Console.WriteLine(" 3.  Create and Implement Events and CallBacks \r ");
                Console.WriteLine("     Create event handlers; subscribe to and unsubscribe from events; \r");
                Console.WriteLine("     use built in delegate types to create events; creat delegates; \r");
                Console.WriteLine("      lambda expressions; anonymous methods");
                Console.WriteLine(" 4.  Implement Exception Handling \r ");
                Console.WriteLine("     Handle exception types: catch types versus base exceptions. try-");
                Console.WriteLine("     catch finally blocks.   throw exceptions; determine when to rethrow");
                Console.WriteLine("     vs. throw; create custom exceptions");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 1: CryptographyExamples.Menu();
                        break;
                    case 3: EventsandCallBacksMenu.Menu();
                        break; 
                    case 4:
                        /*
                         * A "finally" statement will execute even there is an exception that goes through "catch" block
                         * The "finally" statement will also execute when there is no exception
                         * Finally block will always execute so it is a good place to close file or shut down resources.
                         * A try/Finally block can also be used by the "using" statement
                         */

                        ExceptionClassExamples.Menu();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;

                }


            } while (x < 9);
        }
    }
}
