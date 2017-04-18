using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JesseTesting.App
{
    class EventExamples
    {
        #region CarMain

        class Car
        {
            public event Action OnChange;
            public event Action OffChange;
            private double speed;
            public double Speed
            {
                get
                {
                    return speed;
                }
                set
                {
                    speed = value;
                    if (speed >= 60)
                    {
                        if (OnChange != null)
                        {
                            //Fire an Event
                            OnChange();
                        }
                    }
                    else
                    {
                        OffChange();
                    }
                }
            }
        } // end Class Car
      
        public static void CarMain()
        {
            Car c = new Car();
            // Adding a function to a delegate will call all functions hooked up to a delegate
            c.OnChange += c_OnChange;
            c.OffChange += c_OffChange;
            c.Speed = 5;
            c.Speed = 55;
            c.Speed = 65;


        }
        public static void c_OnChange()
        {
            Console.WriteLine("Event Fired : Car is >= 60mph");
        }
        public static void c_OffChange()
        {
            Console.WriteLine("Event Fired : Car is < 60mph");
        }
        #endregion
        #region PersonMain
        class Person
        {
            public delegate void MyEventHandler();
            public event MyEventHandler cashEvent;

            private int cash;
            public int Cash
            {
                get
                {
                    return cash;
                }
                set
                {
                    cash = value;
                    if (cash >= 100)
                    {
                        if (cashEvent != null)
                        {
                            cashEvent();
                        }
                    }
                }
            }
            public void AddCash(int amount)
            {
                Cash += amount;
            }
        } // End Class Person
        public static void PersonMain()
        {
            Person p = new Person();
            //
            // Lamda expression equivalent would be 
            // p.cashEvent += () => Console.WriteLine("Person has 100 Books ");
            //
            p.cashEvent += p_CashEvent;
            p.AddCash(50);
            p.AddCash(50);
        }
        static void p_CashEvent()
        {
            Console.WriteLine("Person has gained 100 dollars");
        }
        #endregion
        #region CowMain
        class Cow
        {
            public string Name { get; set; }
            public EventHandler Moo;
            public void BeTippedOver()
            {
                if (Moo != null)
                    Moo(this, EventArgs.Empty);
            }
        }
       
        public static void CowMain()
        {
            Cow c1 = new Cow { Name = "Betsy" };
            c1.Moo += giggle;
            Cow c2 = new Cow { Name = "Georgy" };
            c2.Moo += giggle;
            Cow victim = new Random().Next() % 2 == 0 ? c1 : c2;
            victim.BeTippedOver();
        }
        static void giggle(object sender, EventArgs e)
        {
            Cow c = sender as Cow;
            Console.WriteLine(" Giggle giggle ... we made" + c.Name + "moo!");
        }
        #endregion

    }
}
