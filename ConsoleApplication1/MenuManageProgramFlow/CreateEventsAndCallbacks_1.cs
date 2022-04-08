
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483.MenuManageProgramFlow
{
    /*
     * See Memory Leaks (caused by not unsubscribing to Events) in ManageObjectCycle.cs
     * 
     * See GenericExamples.cs for definitions of Func, Action, Predicate delegates and meanings
     * 
     * EVENT BEST PRACTICES
     * Microsoft recommends that all events provide two parameters: the object that is raising the event and another object that gives arguments that are relevant
     * to the event. The second object should be of a class derived from the EventArgs class.
     * 
     * Event - Something that happened.  i.e. A mouse Click, keyboard click
     * Defining an Event:
     * 1. Accessiblity - public or private
     * 2. Event - keyword
     * 3. delegate - A delegtate type that defines the kind of method that can act as an event
     *               handler for the event.
     * 4. Eventname - The name that the class is giving the event.
     * 
     * Event Listener - Detect an event and call the event handler.
     * 
     * Event Handler - A callback which is usually called when there is an event.  EventHandler
     * is the contract the event must have with anyone who communicates with it. It's like "string MyString" - 
     * the string is declaring the type. event MyEventHandler TheEvent is declaring that anyone who interacts 
     * with this event must conform to the MyEventHandler contract. 
     * Event Handlers will usually be coupled with an Event Listener. Event Handler
     * is responsible for receiving and processing data from a delegate.  Event
     * Handlers, normally receive two parameters:
     * - Sender
     * - EventArgs
     * EventArgs are responsible for encapsulating Event Data.
     * 
     * Using EventHandler<T>
     * .Net includes a generic EventHandler<T> Class that can be used instead of a custom delegate
     * 
     * -->>   public delegate void WorkedPerformedHandler(object sender, WorkPerformedEventArgs e);   
     *  
     *  above can be replaced with 
     * 
     *  -->> public event EventHandler<WorkPerformedEventArgs> WorkPerformed;   /* compiler will create the delegate
     *  
     * ***************************************************************************************************************
     *  -- Beware of multithreading implications
     * 
     *  class Button
     *  {
     *    public event Action Clicked;
     *    
     *    protected virtual void OnClicked()   <-- Allow overriding
     *    {
     *     var clicked = Clicked;
     *     if (clicked != null)   <--- Thread safety.  Could end up with a race condition if you used Clicked instead of clicked
     *     {                        -- If two threads are doing this at the same time, one will end up winning the race and will
     *       clicked;               -- overwrite the result of the other.
     *     }
     *    }
     *  }
     *  
     */

    // class EventExamples
    //class ManageProgramFlow_3_1
    class CreateEventsAndCallbacks_1
    {
        public static void Menu()
        {
            IMenu MPF3_1 = new MPF3_1_Methods();
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Event Examples Menu \n ");
                Console.WriteLine(" 0.  Car Speed \n ");
                Console.WriteLine(" 1.  Person \n ");
                Console.WriteLine(" 2.  Cow    \n");
                Console.WriteLine(" 3.  Bank Account \n");
                Console.WriteLine(" 4.  Event Inheritance");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: MPF3_1.MenuOpt0();
                           Console.ReadKey();
                           break;
                    case 1: MPF3_1.MenuOpt1();
                           Console.ReadKey();
                           break;
                    case 2: MPF3_1.MenuOpt2();
                           Console.ReadKey();
                           break;
                    case 3: MPF3_1.MenuOpt3();
                            Console.ReadKey();
                            break;
                    case 4: MPF3_1.MenuOpt4();
                            Console.ReadKey();
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
