using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483
{
    /*
     * See GenericExamples.cs for definitions of Func, Action, Predicate delegates and meanings
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
    class EventExamples
    {
        public static void Menu()
        {
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
                    case 0:
                        EventExamples.CarMain();
                        Console.ReadKey();
                        break;
                    case 1:
                        EventExamples.PersonMain();
                        Console.ReadKey();
                        break;
                    case 2:
                        EventExamples.CowMain();
                        Console.ReadKey();
                        break;
                    case 3:
                        BankMain();
                        Console.ReadKey();
                        break;
                    case 4:

                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

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


        }
      
        #endregion
        #region PersonMain
        class Person
        {
            /* 
             * Event Handler
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
        class BankAccountEH
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

            public virtual void OnOverdrawn (OverdrawnEventArgs args)
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
                    // Raise the overdrawn envent.
                    if (Overdrawn != null)
                    {
                        OnOverdrawn(new OverdrawnEventArgs(Balance, amount);
                    }
                }
            }

        } // End of BankAccount

        #endregion
    }
}
