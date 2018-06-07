using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    public class EventsandCallBacksMenu
    {
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Create and Implement Events and CallBacks \n");
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
                    case 0:
                        EventHandlers.EH_Main_1();
                        EventHandlers.EH_Main_2();
                        Console.ReadKey();
                            break;
                    case 2: Delegate.Menu();
                        break;
                    case 3:
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
                    case 4:
                       
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
