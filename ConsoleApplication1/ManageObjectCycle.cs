using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    class ManageObjectCycle
    {
        /*
                        * See also Static Types defined in DynamicExamples.cs
                        * Static Typing eliminates a large class of errors before a program
                        * is run.
                        * 
                        * Managed Language - CLR is the managed language for C#
                        * - Managed Languages depeend on services provided by runtime environmnet.
                        * - C# is one of many languages that compile into managed code
                        * - Managed code is executed by the Common Language Runtime (CLR).
                        * - The CLR provides features such as:
                        *    * Automatic memorary management
                        *    * Exception Handling
                        *    * Standard Types
                        *    * Security
                        *  
                        *    https://www.youtube.com/watch?v=JfNTD7bTscw
                        *    
                       */
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Manage the object life cycle \n ");
                Console.WriteLine("     Manage unmanaged resources; implement IDisposable, including interaction ");
                Console.WriteLine("     with finalization, manage IDisposable by using the 'Using' statement, ");
                Console.WriteLine("     manage finalization and garbage collection \n ");
                Console.WriteLine(" 0.  Garbage Collection ");
                Console.WriteLine(" 1.  Object Creation  ");
                Console.WriteLine(" 2.  ... ");
                Console.WriteLine(" 3.  .. ");
                Console.WriteLine(" 4.  .. ");
                Console.WriteLine(" 5.  .. ");
                Console.WriteLine(" 6.  .. ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        /* Garbage Collection
                         * 
                         * Garbage collection is automatic memory management
                         * De-referenced objects (orphans) are not collected immediately but
                         * periodically.  
                         * -- Many factors affect Garbage collection frequency
                         * -- Not all orphans are collected at the same time
                         * 
                         * Garbage collection is computationally expensive
                         * 
                         * Most of the time you let the Garbage Collector do it's thing.
                         * Some situation may benefit forcing the Garbage collector to run
                         * an example is a Windows Service.
                         * 
                         * GC.Collect();
                         * GC.WaitForPendingFinalizers();
                         * GC.Collect();
                         * 
                         * Note!  Having a loop calling GC.Collect() is a bad thing!
                         * 
                         * Better way to force garbage collection is to implement an interface
                         * call IDisposable.
                         * 
                         * Advanced Dispose Pattern
                         * Example:
                         * public class AdvancedDemo : IDisposable
                         * {
                         *   public void Dispose()
                         *   {
                         *      Dispose(true);
                         *      -- The below stops the Finalizer from having to be re-run and redoing the Dispose
                         *      -- since we have already run the Dispose and don't want to do it again.
                         *      GC.SuppressFinalize(this);
                         *   }
                         *   protected virtual void Dispose(bool disposing)
                         *   {
                         *     if (disposing)
                         *     {
                         *        // release mananged resourced
                         *     }
                         *     // release managed resources
                         *   }
                         *   ~ Represents a Finalizer  - It is the inverse of a constructor.  It allows us to 
                         *     perform an operation at the end of a managed type.
                         *     In the situation where we haven't run Dispose.  When Garbage Collection actually
                         *     runs it will then call our Finalizer which will call Dispose(false).  Garbage 
                         *     collection will only run if we do not hold references out to other objects. So 
                         *     we don't need to dispose of resources in this scenario, hence we pass in false,
                         *     but we still let go of the managed object. 
                         *     
                         *   ~AdvancedDemo
                         *   {
                         *      Dispose(false)
                         *   }
                         *   
                         * }
                         * 
                         * *******************************************************************************************
                         * Dispose versus Close versus Stop
                         * - Close 
                         *   May be functionally the same as Close
                         *   May be a subset of Dispose
                         * - A Closed object may be reopened
                         *   IDbConnection
                         * - Stop is similar to Close
                         *   May be restarted
                         *   Timer
                         **********************************************************************************************
                         *  Unmanged Resources
                         *   - Text File Reading, File Opening, XML Reading
                         *   - Microsoft came up with the 'Using' statement to properly dispose of these unmanaged resources
                         *   
                         *   Using(declare unmanaged type that implements IDisposable)  
                         *   
                         *   The Using is the equivalent of using the 'try, catch, finally block that calls IDisposable'.
                         *   
                         *   https://www.youtube.com/watch?v=0SZL-dsMEXM  
                         *   
                         *   https://www.dotnetperls.com/using
                         *   
                         * ********************************************************************************************
                         * Memory Leaks
                         * - Despite having automatic memory management, it is still possible to create 
                         *   managed memory leaks.
                         * - Events can be a common source of memory management leks
                         *   Events can hold references to objects
                         *   Solution! Unsubscribe from events proactively!
                         * - Weak references can be used to avoid some memory leak scenarios.
                         * 
                         * Weak References
                         * - Weak references create a reference that the Garbage Collector ignores
                         * - The Garbage collector will assume an object is eligible for collection
                         *   if it is only referenced to by weak references.  
                         *    
                         *   
                         * 
                         * https://www.youtube.com/watch?v=1G2IhEdb6lA
                        */
                        break;
                    case 1:
                        ObjectCreation();
                       break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                                                
                    case 6:
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
        static void ObjectCreation()
        {
            Process.Start("https://www.youtube.com/watch?v=SZotrU_5Tf4");
        }
    }
}
