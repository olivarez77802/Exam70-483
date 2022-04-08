using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483.MenuManageProgramFlow
{
    /* Event Sytax
     * 1. Accessiblity (public or private)
     * 2. event - keyword
     * 3. delegate: A delegate type that defines the kind of method that can act as an event
     *              handler for the event.  A delegate is a type safe function pointer that serves
     *              as a pipleline for the EventArgs.
     * 4. EventName: The name that the class is giving the event.
     * 
     * Example:
     *  public delegate void OverdrawnEventHandler();
     *  public event OverdrawnEventHandler Overdrawn;
     *  
     *  Common mistakes: Oversubscribed
     *  If you subscribe to an event more than once, the event handler is called more than once.
     *  For example, if the program executes the statmement processOrderButton += processOrderButton_Click
     *  three times, when the user clicks the button, the processOrderButton_Click event handler executes
     *  three times.
     *  Each time you unsubscribe from an event, the event handler is removed from the list of subcribers
     *  once.  For example, if the program executes the statemement processOrderButton.Click += processOrderButton_Click
     *  three times and the statement processOrderButton -= processOrderButton_Click once, if the user
     *  clicks the button, the event handler executes two times.
     *  If you unsubscribe an event handler that is not subcribed for an event, nothing happens and there
     *  is no error.  For example, if a program executes the statement processOrderButton -= processOrderButton_Click
     *  but that event handler has not been subcribed to the event, the program continues running normally.
     *  
     *  
     * 
     */
   // public class EventHandlerExamples
    // class ManageProgramFlow_3_0
    class CreateEventsAndCallbacks_0
    {
        /* 
         * Event Handlers will usually be coupled with an Event Listener. Event Handler
         * is responsible for receiving and processing data from a delegate.  Event
         * Handlers, normally receive two parameters:
         * - Sender
         * - EventArgs
         * EventArgs are responsible for encapsulating Event Data.
        */
        // Same as defining public delegatate void Action1(); 
        public delegate void EventHandler();
        public static event EventHandler Option1;
        public static event EventHandler Option2;
        public static void Menu()
        {
            IMenu MPF3_0 = new MPF3_0_Methods();
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" EventHandlers \n ");
                Console.WriteLine(" 0. Invoke Event \n");
                Console.WriteLine(" 1. Metronome \n");
                Console.WriteLine(" 2.  .. ");
                Console.WriteLine(" 3.  .. ");
                Console.WriteLine(" 4.  .. ");
                Console.WriteLine(" 5.  .. ");
                Console.WriteLine(" 6.  ..");
                Console.WriteLine(" 7.  ..");
                Console.WriteLine(" 9.  Quit            \n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: MPF3_0.MenuOpt0();
                            Console.ReadKey();
                            break;
                    case 1: MPF3_0.MenuOpt1();
                            Console.ReadLine();
                            break;
                    case 3: MPF3_0.MenuOpt3();
                            break;
                    case 4: MPF3_0.MenuOpt4();
                            break;
                    case 5: MPF3_0.MenuOpt5();
                            break;
                    case 6: MPF3_0.MenuOpt6();
                            break;
                    case 7: Console.ReadKey();
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


