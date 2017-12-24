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
*/

{
    delegate void CustomDel(string s);
    delegate int Countit(int x);
   
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
                Console.WriteLine(" 1.  Async Processing \n ");
                Console.WriteLine(" 2.  Callbacks  \n");
                Console.WriteLine(" 3.  Events \n");
                Console.WriteLine(" 4.  Threading \n");
                Console.WriteLine(" 5.  Tasks \n");
                Console.WriteLine(" 6.  Async and Await \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: Delegates();
                        break;
                    case 1: KeyWordsLiterals();
                        break;
                    case 2: Operators();
                        break;
                    case 3: EventProcessing();
                        break;
                    case 4: ThreadingExamples.ThreadPrimaryMain(); 
                        break;
                    case 5: TaskLibExamples.Menu();
                        break;
                    case 6: AsyncAwaitExamples.AsyncEx1Main();
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
        static void KeyWordsLiterals()
        {

            Process.Start("http://msdn.microsoft.com/en-us/library/x53a06bb.aspx");
        }
        static void Operators()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/6a71f45d.aspx");
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
    }
   
    
          
}



