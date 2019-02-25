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
     */
    public class EventHandlerExamples
    {

        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" EventHandlers \n ");
                Console.WriteLine(" 0. EventHandler Example 1 .. ");
                Console.WriteLine(" 1. Metronome ");
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
                        EH_Main_1();
                        Console.ReadLine();
                        break;
                    case 1:
                        EH_Main_2();
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
            public delegate void TickHandler(Metronome m, EventArgs e);
            public event TickHandler Tick;       /* TicketHandler is a delegate */
            public EventArgs e = null;
           
            /*
             * Listener
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
                        /* Fire event */
                        Tick(this, e);
                    }
                }
            }
        }

        public class Listener
        {
            public void Subscribe(Metronome m)
            {
                m.Tick += new Metronome.TickHandler(HeardIt);
            }
            private void HeardIt(Metronome m, EventArgs e)
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


