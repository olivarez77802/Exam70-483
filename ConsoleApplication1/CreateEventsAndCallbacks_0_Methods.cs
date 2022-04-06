using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    public class MPF3_0_Methods : IMenu
    {
        public delegate void EventHandler();
        public static event EventHandler Option1;
        public static event EventHandler Option2;
        public void MenuOpt0()
        {
            // The below is the same thing as making the Event a Listener
            Option1 += new EventHandler(EH_Main_1);
            // Below is the same as Firing an Event
            Option1.Invoke();
            // Firing an event, does not unsubscribe the method
            //Console.WriteLine(" Doing again to prove Firing an event does not unsubscribe a method");
            //Option1.Invoke();
            
        }

        public void MenuOpt1()
        {
            Option2 += new EventHandler(EH_Main_2);
            Option2.Invoke();
            Console.ReadLine();
           
        }

        public void MenuOpt2()
        {
            throw new NotImplementedException();
        }

        public void MenuOpt3()
        {
            throw new NotImplementedException();
        }

        public void MenuOpt4()
        {
            throw new NotImplementedException();
        }

        public void MenuOpt5()
        {
            throw new NotImplementedException();
        }

        public void MenuOpt6()
        {
            throw new NotImplementedException();
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
