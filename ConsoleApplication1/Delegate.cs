using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace Exam70483

/*
 * See GenericExamples.cs for definitions of Func, Action, Predicate delegates and meanings
 * 
 * Called by ManageProgramFlow.cs
 * 
 * Defining a delegate type
 * 1.  accessiblity  - for the delegat type such as public or private.
 * 2.  delegate  - The keyword
 * 3.  returnType - The data type that a method of this delegate type returns
 *                  such as void, int, or string.
 * 4. delegateName - The name that you want to give the delegate type
 * 5. Parameters - The parameter list that a method of this delagate type 
 *                 should take.
 *                 
 * Static and Instance Methods
 * If you set a delegate variable equal to a static method, it's clear 
 * what happens when you invoke a variable's method.  There is only one
 * method shared by all the instances of the class that defines it, so
 * that is the method that is called.
 * 
 * 
*/

{
    class Delegate
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Delegates Menu \n ");
                Console.WriteLine(" 0.  Delegates \n ");
                Console.WriteLine(" 1.  Instance versus Static Methods \n ");
                Console.WriteLine(" 2.  ....  \n");
                Console.WriteLine(" 3.  Events \n");
                Console.WriteLine(" 4.  ... \n");
                Console.WriteLine(" 5.  ...  \n");
                Console.WriteLine(" 6.  ...  \n");
                Console.WriteLine(" 7.  ... \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                // Will stop if selection is 2 or less
                Debug.Assert(selection > 2);
                switch (selection)
                {
                    case 0: Delegates();
                        break;
                    case 1: InstanceVersusStatic();
                        Console.ReadKey();
                        break;
                    case 2:
                        break;
                    case 3: EventProcessing();
                        break;
                    case 4:  
                        break;
                    case 5: 
                        break;
                    case 6:
                        break;
                    case 7: 
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        }

        static void Delegates()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/aa288459(v=vs.71).aspx");
            Console.WriteLine(" Delegate Example 1 ");
            Delegate_Example_1();
            Delegate_Example_2();
            Delegate_Example_3();
         }
       
        
        static void EventProcessing()
        {
            // Process.Start("http://msdn.microsoft.com/en-us/library/vstudio/ed8yd1ha%28v=vs.100%29.aspx");
            EventExamples.CarMain();
            Console.ReadKey();
            EventExamples.PersonMain();
            Console.ReadKey();
            EventExamples.CowMain();
            Console.ReadKey();
            
        }
        
        
             
        static void Delegate_Example_1()
        {
            Console.WriteLine("Delegate Example 1");
            DelegateExamples.TCMain();
            Console.ReadKey();
        }
       
        static void Delegate_Example_2()
        { 
          // Lambda Delegates
            Console.WriteLine("Delegate Example 2 - Lambda Delegate ");
            DelegateExamples.Lambda_Main();
            Console.ReadKey();
         }

        static void Delegate_Example_3()
        {
            // An example of a Regular Method; Anonymous Method, and Lambda Delegates
            // Which are all the same.
            Console.WriteLine("Delegate Example 3 - Showing Different/Same Delegates ");
            GenericExamples.Same_Main();
            Console.ReadKey();
        }
        static void InstanceVersusStatic()
        {
            // Make some Persons
            PersonDel alice = new PersonDel() { Name = "Alice" };
            PersonDel bob = new PersonDel() { Name = "Bob" };

            //Make Alice's InstanceMethod variable refer to her own GetName 
            //method.
            alice.InstanceMethod = alice.GetName;
            alice.StaticMethod = PersonDel.StaticName;

            //Make Bob's Instance Method variable refer to Alice's GetName
            //method.
            bob.InstanceMethod = alice.GetName;
            bob.StaticMethod = PersonDel.StaticName;

            //Demonstrate the methods- Displays Alice, Alice, Static, Static
            string result = "";
            result += "Alice's InstanceMethod returns: " + alice.InstanceMethod() + "\n";
            result += "Bob's Instance Method returns:" + bob.InstanceMethod() + "\n";
            result += "Alice's Static Method returns:" + alice.StaticMethod() + "\n";
            result += "Bob's Static Method returns:" + bob.StaticMethod() + "\n";
            Console.WriteLine("result  {0}", result);
        }

    }
    class PersonDel
    {
        public string Name;

        // A method that returns a string.
        public delegate string GetStringDelegate();

        //A static method
        public static string StaticName()
        {
            return "Static";
        }
        
        // Return this instance's Name.
        public string GetName()
        {
            return Name;
        }
        // Variables to hold GetStringDelegates.
        public GetStringDelegate StaticMethod;
        public GetStringDelegate InstanceMethod;
    }
   
    
          
}



