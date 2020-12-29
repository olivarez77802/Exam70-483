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
 * 1.  accessiblity  - for the delegate type such as public or private.
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
 * Covariance and Contravariance
 * - Give flexiblity when assigning methods to delegate variables.  They basically
 * - let you treat the return type and parameters of a delegate polymorphically.
 * - When you assign a method to a delegate, covariance and contravariance provide
 *   flexibility for matching a delegate type with a method signature. 
 * - Covariance permits a method to have return type that is more derived than defined in the 
 *   delegate.
 * - Contravariance permits a method that has a parameter types that are less derived than
 *   those in the delegate type.
 *      
 * 
 * Covariance Example.
 * 
 *   Employee : Person
 *   public delegate Person ReturnPersonDelegate()
 *   You could set a ReturnPersonDelegate variable equal to a method that returns an Employee objects.
 *   Employee method1
 *   
 * 
 * Contravariance Example
 * 
 * public delegate Employee EmployeeParameterDelegate(Employee parm1)
 * Persom method1()
 * 
 * Contravariance allows you to pass method1 as a parameter even though it is of type Person.
 * 
 * ------------------------------------------------------------------------------------------
 * Action Delegates
 * public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2)
 * The keyword 'in' within the generic parameter list indicates that the T1 and T2 type 
 * parameters are contravariant.
 * 
 *    //Method 1.
 *    private delegate void EmployeeParameterDelegate(Employee employee);
 *    private EmployeeParameterDelegate EmployeeParameterMethod1;
 * 
 *    //Method 2.
 *    private Action<Employee> EmployeeParameterMethod2;
 * 
 *    The generic Action delegate represents a method that returns void.  Employee is
 *    the type of Parameter(s).
 * 
 * Func Delegates
 * - The generic Func delegate represents a method that returns a value.  Syntax
 *   public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2)
 *   
 *       //Method 1.
 *       private delegate Person ReturnPersonDelegate();
 *       private ReturnPersonDelegate ReturnPersonMethod1;
 *       
 *       //Method 2.
 *       private Func<Person> ReturnPersonMethod2;
 *       -- Above is an example of a Function that takes no parameters and returns a Person type object.
 * 
 * Anonymous Types
 * -  The following code stores an anonymous method in a variable of a delegate type.
 * private Func<float, float> Function = delegate(float x) {return x * x;};
 * 
 * Events
 *      //Method1.
 *      public delegate void OverdrawnEventHandler();
 *      public event OverdrawnEventHandler Overdrawn;
 *      
 *      //Method2.  - Simplified way of writing above
 *      public event Action Overdrawn;
 *      
 * 
 *       
*/

{
    // class Delegate
    //class ManageProgramFlow_3_2
    class CreateEventsAndCallbacks_2
    {
        /*
         * You can use a delegate much as you use any other type.  First, use the delegate
         * keyword to define the delegate type.  Next, create variables of the delegate type,
         * and set them equal to methods that match the delegate's parameters and return type.
         * Finally write code to invoke the variable, which calls the mthod refered to by 
         * the variable.
        */
        public delegate void Action();
        public static void Menu()
        {
            Action Option1, Option2, Option3, Option4;
            
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Delegates Menu \n ");
                Console.WriteLine(" 0.  ...\n ");
                Console.WriteLine(" 1.  Instance versus Static Methods \n ");
                Console.WriteLine(" 2.  Delegate 1  \n");
                Console.WriteLine(" 3.  Delegate 2  \n");
                Console.WriteLine(" 4.  Delegate 3  \n");
                Console.WriteLine(" 5.  ...  \n");
                Console.WriteLine(" 6.  ...  \n");
                Console.WriteLine(" 7.  ... \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: 
                        break;
                    case 1:
                        Option1 = InstanceVersusStatic;
                        Option1();
                        Console.ReadKey();
                        break;
                    case 2:
                        Option2 = Delegate_Example_1;
                        Option2();
                        Console.ReadKey();
                        break;
                    case 3:
                        Option3 = Delegate_Example_2;
                        Option3();
                        Console.ReadKey();
                        break;
                    case 4:
                        Option4 = Delegate_Example_3;
                        Option4();
                        Console.ReadKey();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        }

      
        static void Delegate_Example_1()
        {
            Console.WriteLine("Delegate Example 1");
            DelegateExamples.TCMain();
           
        }
       
        static void Delegate_Example_2()
        { 
          // Lambda Delegates
            Console.WriteLine("Delegate Example 2 - Lambda Delegate ");
            DelegateExamples.Lambda_Main();
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



