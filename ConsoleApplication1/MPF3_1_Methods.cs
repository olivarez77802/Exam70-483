using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    class MPF3_1_Methods : IMenu
    {
        public void MenuOpt0()
        {
            CarMain();
           
        }

        public void MenuOpt1()
        {
            PersonMain();
        }

        public void MenuOpt2()
        {
            CowMain();
        }

        public void MenuOpt3()
        {
            BankMain();
        }

        public void MenuOpt4()
        {
            BankMainEI();
        }

        public void MenuOpt5()
        {
            throw new NotImplementedException();
        }

        public void MenuOpt6()
        {
            throw new NotImplementedException();
        }

        #region CarMain

        public class Car
        {
            /* 
             * Event Handler
             */
            public event Action OnChange;
            public event Action OffChange;
            private double speed;
            /* 
             * Event Listener
             */
            public double Speed
            {
                /* Don't really need a 'get' in this program */
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
                        /* Fire an Event */
                        OffChange();
                    }
                }
            }
        } // end Class Car

        public class Listener
        {
            public void Subscribe(Car c)
            {
                c.OnChange += c_OnChange;
                c.OffChange += c_OffChange;
            }
            private static void c_OnChange()
            {
                Console.WriteLine("Event Fired : Car is >= 60mph. ");
            }
            private static void c_OffChange()
            {
                Console.WriteLine("Event Fired : Car is < 60mph");
            }
            public void UnSubscribe(Car c)
            {
                c.OnChange -= c_OnChange;
                c.OffChange -= c_OffChange;
                Console.WriteLine("Unsubscribed from Event");
            }
        }
        public static void CarMain()
        {
            Car c = new Car();
            // Adding a function to a delegate will call all functions hooked up to a delegate
            //c.OnChange += c_OnChange;
            //c.OffChange += c_OffChange;
            Listener l = new Listener();
            l.Subscribe(c);
            c.Speed = 5;
            c.Speed = 55;
            c.Speed = 65;
            /*
             * Unsubscribe - See Memory Leaks write up in ManageObjectCycle.cs
            */
            l.UnSubscribe(c);

        }

        #endregion
        #region PersonMain
        class Person
        {
            /* 
             * The class containing the event is used to publish the event. This is called the publisher class. Some other class that accepts this event 
             * is called the subscriber class. Events use the publisher-subscriber model.
             * https://www.tutorialspoint.com/csharp/csharp_events.htm
             */
            public delegate void MyEventHandler();
            public event MyEventHandler cashEvent;

            /*
             * Listener
             */
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
                        // cashEvent would be null if it did not have any subcriptions to the event or +=
                        if (cashEvent != null)
                        {
                            /* Fire an Event */
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
            /*
               +=   Is how you subscribe to an Event.   This is why you check for Null in Person in case you
                    didn't subscribe to the Event.
                    Event += EventHandler
                    Event Handler signture must match with delegate signature
                    https://www.tutorialsteacher.com/csharp/csharp-event

                     
               Lamda expression equivalent would be 
               p.cashEvent += () => Console.WriteLine("Person has 100 Books ");
            */
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
            /*
            *  Subscribe using Event Handler.  When you subscribe, you are not calling the method.  The method is called
            *  when the event is triggered.
            */
            Cow c1 = new Cow { Name = "Betsy" };
            c1.Moo += giggle;
            Cow c2 = new Cow { Name = "Georgy" };
            c2.Moo += giggle;
            Cow victim = new Random().Next() % 2 == 0 ? c1 : c2;
            victim.BeTippedOver();
            /*
             *  Subscribe using a Lambda expression.   Ordinarily paramters are s,e... I just made them xrx,cce to
             *  show that you can make them anything.
             */
            Cow c3 = new Cow { Name = "Jesse" };
            c3.Moo += (xrx, cce) => giggle(xrx, cce);
            Cow victum2 = c3;
            victum2.BeTippedOver();
            /*
             * Subscribe using a delegate; otherwise known as an Anonymous method
             */
            Cow c4 = new Cow { Name = "Arthur" };
            c4.Moo += delegate (object s, EventArgs e)
            {
                giggle(s, e);
            };
            Cow victum3 = c4;
            victum3 = c4;
            victum3.BeTippedOver();
        }
        static void giggle(object sender, EventArgs e)
        {
            Cow c = sender as Cow;
            Console.WriteLine(" Giggle giggle ... we made" + c.Name + "moo!");
        }
        #endregion
        #region BankAccount
        class BankAccount
        {
            public delegate void OverdrawnEventHandler(BankAccount b);
            public event OverdrawnEventHandler Overdrawn;

            //The account balance
            public decimal Balance { get; set; }

            // Add money to the Account
            public void Credit(decimal amount)
            {
                Balance += amount;
            }

            //Remove money from the account.
            public void Debit(decimal amount)
            {
                // See if there is this much money in the account.
                if (Balance >= amount)
                {
                    //Remove the money
                    Balance -= amount;
                }
                else
                {
                    // Raise the overdrawn envent.
                    if (Overdrawn != null)
                    {
                        Overdrawn(this);
                    }
                }
            }

        } // End of BankAccount
        class ListenToBank
        {
            public void Subscribe(BankAccount b)
            {
                b.Overdrawn += new BankAccount.OverdrawnEventHandler(Heardit);
            }
            private void Heardit(BankAccount b)
            {
                Console.WriteLine("Account is overdrawn Balance is {0}", b.Balance);
            }
        }
        public static void BankMain()
        {
            BankAccount b = new BankAccount();
            ListenToBank l = new ListenToBank();

            l.Subscribe(b);
            b.Credit(10);
            Console.WriteLine("Credit 10 Balance is {0}", b.Balance);
            b.Debit(5);
            Console.WriteLine("Debit 5 Balance is {0}", b.Balance);
            b.Debit(5);
            Console.WriteLine("Debit 5 Balance is {0}", b.Balance);
            Console.WriteLine("Debit 5 ");
            b.Debit(5);

        }
        #endregion
        #region BankAccountUsingEventInheritance
        class OverdrawnEventArgs : EventArgs
        {
            public decimal CurrentBalance, DebitAmount;

            public OverdrawnEventArgs(decimal currentBalance, decimal debitAmount)
            {
                CurrentBalance = currentBalance;
                DebitAmount = debitAmount;
            }
        }
        /*
        * EVENT INHERITANCE
        * - While building Windows Forms Classes, Microsoft found that simple events don't work well with derived classes.
        *   The problem is that an event can be raised only from within the class that declared it, so a subclass cannot
        *   raise the base class events.
        * - The solution that Microsoft uses in the .NET Framework and many other class heirarchies is to give the base
        *   class a protected method that raises the event.   Then a derived class can call that method to raise the event.
        *   By convention, this method's name should begin with "On" and end with the name of the event, as in OnOverdrawn.
        */
        class BankAccountEI
        {
            public delegate void OverdrawnEventHandler(BankAccountEI b, OverdrawnEventArgs e);
            public event OverdrawnEventHandler Overdrawn;

            //The account balance
            public decimal Balance { get; set; }
            // Add money to the Account
            public void Credit(decimal amount)
            {
                Balance += amount;
            }
            /*
             protected virtual void OnOverdrawn (OverdrawnEventArgs args) 
              
             Not sure why the original method was set up to be virtual.
             Virtual means you can optionally override the method.  I am
             not sure why we would want to ever override.
                        
            */
            protected void OnOverdrawn(OverdrawnEventArgs args)
            {
                if (Overdrawn != null)
                {
                    Overdrawn(this, args);
                }
            }


            //Remove money from the account.
            public void Debit(decimal amount)
            {
                // See if there is this much money in the account.
                if (Balance >= amount)
                {
                    //Remove the money
                    Balance -= amount;
                }
                else
                {
                    // Raise the overdrawn event.
                    if (Overdrawn != null)
                    {
                        OnOverdrawn(new OverdrawnEventArgs(Balance, amount));
                    }
                }
            }

        } // End of BankAccountEI
        class ListenToBankEI
        {
            public void Subscribe(BankAccountEI b)
            {
                b.Overdrawn += new BankAccountEI.OverdrawnEventHandler(Heardit);
            }
            private void Heardit(BankAccountEI b, OverdrawnEventArgs e)
            {
                Console.WriteLine("Account is overdrawn Balance is {0} Amount is {1}", e.CurrentBalance, e.DebitAmount);
            }
        }

        class MoneyMarketAccount : BankAccountEI
        {
            public void DebitFee(decimal amount)
            {
                //See if there is this much money in the account
                if (Balance >= amount)
                {
                    //Remove the money
                    Balance -= amount;
                }
                else
                {
                    //Raise the overdrawn event.
                    // base.Overdrawn is not allowed, a subclass must use a
                    // method to raise a base class events.
                    OnOverdrawn(new OverdrawnEventArgs(Balance, amount));
                }
            }
        }
        public static void BankMainEI()
        {
            MoneyMarketAccount mm = new MoneyMarketAccount() { Balance = 0 };
            ListenToBankEI l = new ListenToBankEI();

            l.Subscribe(mm);
            //Console.WriteLine("Balance is {0)", mm.Balance);
            mm.Credit(10);
            Console.WriteLine("Credit 10 Balance is {0}", mm.Balance);
            mm.Debit(5);
            Console.WriteLine("Debit 5 Balance is {0}", mm.Balance);
            mm.DebitFee(5);
            Console.WriteLine("DebitFee 5 Balance is {0}", mm.Balance);
            mm.DebitFee(10);
            Console.WriteLine("DebitFee 10 Balance is {0}", mm.Balance);

        }

        #endregion
    }
}
