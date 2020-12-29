using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    // public class EventsandCallBacksMenu
    class CreateEventsAndCallbacks 
    {
        public static void Menu()
        {
            IMenu MPF3 = new MPF3_Methods();
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Create and Implement Events and CallBacks \n");
                Console.WriteLine("   Create Event Handlers; subscribe to and unsubscribe from events;");
                Console.WriteLine("   use built-in delegate types to create events;");
                Console.WriteLine("   create delegates; lambda expressions; anonymous methods");
                Console.WriteLine(" ");
                Console.WriteLine(" 0.  Create Event Handlers \n ");
                Console.WriteLine(" 1.  Subscribe and Unsubscribe from Events  \n ");
                Console.WriteLine(" 2.  Delegates  \n ");
                Console.WriteLine(" 3.  Lambda Expressions \n ");
                Console.WriteLine(" 4.  Anonymous Methods \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Exam70483.Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: MPF3.MenuOpt0();
                       // EventHandlerExamples.Menu();
                        Console.ReadKey();
                        break;
                    case 1: MPF3.MenuOpt1();
                        // EventExamples.Menu();
                            Console.ReadKey();                                
                            break;
                    case 2: MPF3.MenuOpt2();
                        // Delegate.Menu();
                            break;
                    case 3: MPF3.MenuOpt3();
                        /*
                         * c - Input parameter
                         * No type was specified for 'c'.  Lambda expressions have implicit typing
                         * .Net knows that you are iterating through a list of Customers, so 'c' must be a Customer
                         * =>  Called the lambda operator
                         * C.CustomerID == customerid    Called the body of the function
                         * 
                         * Could be read as 'Iterating over the Customer List for each customer return true if the 
                         * CustomerId matches customerid
                         * 
                         * c => C.CustomerId == customerid
                         */
                        break;
                    case 4: MPF3.MenuOpt4();
                       // See EnumerableMethods.cs
                       // See EventHandlers.cs
                       // See GenericExamples.cs
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
