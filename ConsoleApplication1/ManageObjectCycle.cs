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
         * Assemblies have an extension of .DLL or .EXE depending on the type of
         * application.
         * 
         * .Net Assemblies contain IL (Intermediate Language), where as pre .Net
         * assemblies contain Native Code (Machine Code).
         * 
         * .Net the application execution consists of 2 steps
         * (Offers application portability).
         * 1. Compilation - Source code to IL.
         * 2. Execution or JIT Compilation - IL to Platform specific native code.
         * 
         * CLR - .NET Runtime environment provides several benefits.  Garbage 
         * collection is one of them.
         * 
         * .NET supports different programming languages like C#,VB,J#, and C++,
         * C#,VB, and J# can only generate managed code(IL), whereas C++ can 
         * generate both managed code(IL) and unmanaged code(Native Code).
         * 
         * The native code is not stored permanently anywhere, after we close the 
         * program the native code is thrown away.  When we execute the program
         * again, the native code gets generated again.   Native code is only 
         * stored in memory while the program is running.
         * 
         * Managed Language - CLR is the managed language for C#
         * - Managed Languages depend on services provided by runtime environmnet.
         * - C# is one of many languages that compile into managed code
         * - Managed code is executed by the Common Language Runtime (CLR).
         * - The CLR provides features such as:
         *    * Automatic memory management (Garbage Collection)
         *    * Exception Handling
         *    * Standard Types
         *    * Security
         *  
         *    https://www.youtube.com/watch?v=JfNTD7bTscw
         *    
         *    
         *    DotNet Program Execution
         *    C#, VB, C++,.. Reside on top of .Net Application
         *    Compiled into EXE or DLL
         *    DLL or Exe Gets fed to CLR
         *    CLR composed of Intermediate Language, JIT Compiler, Native Code
         *    CLR interfaces with Operating System
         *    https://www.youtube.com/watch?v=ruf4U9_Rbss&list=PL8598C97BA1D871C1
         *    
         *    What is Garbage Collection?
         *    - Garbage collection is automatic memory management
         *    - Dereferenced objects (orphans) are collected immediately but periodically.
         *    - Garbage collection is computationally expensive
         *    
         *    What if you don't want to wait for the CLR to do Garbage Collection, you know
         *    you are consuming a lot of resources and you want to proactively free
         *    expensive resources.   The solution to this is you can Implement IDisposable.
         *    
         *    Dispose versus Close versus Stop
         *    Close
         *    - May be functionally the same as Dispose
         *    - May be a subset of the Dispose functionality
         *    - A closed object may be reopened (IDbConnection)
         *    Stop
         *    - Similar to Close
         *    - May be restarted (Timer,etc.)
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
                         *  Unmanaged Resources
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
                         * - Events can be a common source of memory management leaks
                         *   Events can hold references to objects
                         *   Solution! Unsubscribe from events proactively!  Use -= on Event.
                         * - Weak references can be used to avoid some memory leak scenarios.
                         * - Memory leaks - A programmer allocates a block of memory from the
                         *   operating system, intending to free it later, but forgets and leaves
                         *   it hanging.  The block of memor is said to be 'leaked' away as it 
                         *   can't be recovered for later use.  If your app runs long enough,
                         *   these leaks accumulate and the app runs out of memory.  This is not a big
                         *   deal in programs like Notepad that a user runs a few minutes and then
                         *   shuts down, but it is fatal in apps like web servers that are supposed
                         *   to run continuously.  You think we could remember to free all of our memory
                         *   allocations, but they often get lost in complex program logic.
                         * 
                         * Weak References
                         * - Weak references create a reference that the Garbage Collector ignores
                         * - The Garbage collector will assume an object is eligible for collection
                         *   if it is only referenced to by weak references.  
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
