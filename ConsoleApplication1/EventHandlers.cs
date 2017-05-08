using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JesseTesting.App
{

    public class Metronome
    {
        public event TickHandler Tick;
        public EventArgs e = null;
        public delegate void TickHandler(Metronome m, EventArgs e);
        public void Start()
        {
            int i = 1;
            while (i < 4)
            {
                
                System.Threading.Thread.Sleep(3000);
                if (Tick != null)
                {
                    ++i;
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

    abstract class EventHandlers
    {
        public delegate void EventHandler();
        public static event EventHandler _show;

        static void EH_Main_1()
        {
            //Add event handlers to Show event.
            _show += new EventHandler(Dog);
            _show += new EventHandler(Cat);
            _show += new EventHandler(Mouse);
            _show += new EventHandler(Mouse);

            //Delegate inference
            _show += Dog;


            //Anonymous Method
            //Anonymous Methods are defined use the delegate keyword
            _show += delegate
            {
                Console.WriteLine("Giraffe");
            };
            //Invoke the event.
            _show.Invoke();
        }
        static void EH_Main_2()
        {

            https://www.codeproject.com/Articles/11541/The-Simplest-C-Events-Example-Imaginable
            Metronome m = new Metronome();
            Listener l = new Listener();
            l.Subscribe(m);
            m.Start();
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

        public static void EH_Main()
        {
            EH_Main_1();
            Console.ReadKey();
            EH_Main_2();
            Console.ReadKey();


        }
    }

}
