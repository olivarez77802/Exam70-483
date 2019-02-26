using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    /* Event Sytax
     * 1. Accessiblity (public or private)
     * 2. event - keyword
     * 3. delegate: A delegate type that defines the kind of method that can act as an event
     *              handler for the event.
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
    public class EventHandlerExamples
    {
        /* 
         * Event Handlers will usually be coupled with an Event Listener.
        */
        // Same as defining public delegatate void Action1(); 
        public delegate void EventHandler();
        public static event EventHandler Option1;
        public static event EventHandler Option2;
        public static void Menu()
        {

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
                    case 0:
                        // The below is the same thing as making the Event a Listener
                        Option1 += new EventHandler(EH_Main_1);
                        // Below is the same as Firing an Event
                        Option1.Invoke();
                        // Firing an event, does not unsubscribe the method
                        //Console.WriteLine(" Doing again to prove Firing an event does not unsubscribe a method");
                        //Option1.Invoke();
                        Console.ReadKey();
                        break;
                    case 1: Option2 += new EventHandler(EH_Main_2);
                        Option2.Invoke();
                        Console.ReadLine();
                        break;
                    case 3:


                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

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

        #region Listener

        public class Metronome
        {
            /* 
             * Event Handler
             */
            public delegate void TickHandler(Metronome m);
            public event TickHandler Tick;       /* Event Tick uses delegate TicketHandler */
            
           
            /*
             * Listener.  Metronome class creates a tick at a tick of 3 seconds and 
             * a Listener class hears the metronome ticks and prints 'Heard it' every 
             * time it receives an event.
             */
            public void Start()
            {
                int i = 1;
                while (i < 4)
                {

                    System.Threading.Thread.Sleep(3000);
                    if (Tick != null)
                    {
                        ++i;
                        /* Fire event - Firing an event only executes the method, it does not unsubcribe the method from the event */
                        Tick(this);
                    }
                }
            }
        }

        public class Listener
        {
            /* 
             * Will put a method on the Queue, whatever is on the Queue will get executed 
             * whenever the Event is fired.  
            */
            public void Subscribe(Metronome m)
            {
                m.Tick += new Metronome.TickHandler(HeardIt);
            }
            private static void HeardIt(Metronome m)
            {
                System.Console.WriteLine("HEARD IT");
            }
          

        }
       
        public static void EH_Main_2()
        {

            /*  https://www.codeproject.com/Articles/11541/The-Simplest-C-Events-Example-Imaginable */
            Metronome m = new Metronome();
            Listener l = new Listener();
            l.Subscribe(m);
            m.Start();
        }
        #endregion
        #region EventHandler

        public delegate void EventHandler_1();
        public static event EventHandler_1 _show;

        public static void EH_Main_1()
        {
            /*
             * 
             * https://www.dotnetperls.com/event
            */
            //Add event handlers to Show event.
            _show += new EventHandler_1(Dog);
            _show += new EventHandler_1(Cat);
            _show += new EventHandler_1(Mouse);
            _show += new EventHandler_1(Mouse);

            //Delegate inference
            _show += Dog;



            //Anonymous Method
            //Anonymous Methods are defined use the delegate keyword
            _show += delegate
            {
                Console.WriteLine("Giraffe");
            };

            //Lambda
            EventHandler_1 _show2 = () => Console.WriteLine("Pig");



            //Invoke the event.
            _show.Invoke();
            _show2.Invoke();
        }

        static void Cat()
        {
            Console.WriteLine("Cat");
        }

        static void Dog()
        {
            Console.WriteLine("Dog");
        }

        static void Mouse()
        {
            Console.WriteLine("Mouse");
        }

             
        #endregion
    }
}


