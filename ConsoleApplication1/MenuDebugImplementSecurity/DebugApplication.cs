﻿#define OldMethod
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exam70483.MenuDebugImplementSecurity
{
   
    class DebugApplication
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Debug an Application \n ");
                Console.WriteLine("- Create and manage preprocessor directives; choose ");
                Console.WriteLine("- an appropriate build type; manage program database");
                Console.WriteLine("- files (PDB) Debug symbols");
                Console.WriteLine(" 0.  Create and Manage Preprocessor directives \n ");
                Console.WriteLine(" 1.  Choose an approriate build type \n ");
                Console.WriteLine(" 2.  Manage program database files (debug symbols) \n ");
                Console.WriteLine(" 3.  Debug.Assert \n");
                Console.WriteLine(" 4.  ...\n");
                Console.WriteLine(" 5.  ... \n");
                Console.WriteLine(" 6.  ...\n");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        Trace.WriteLine(" Calling PreProcessor Directives");
                        PreProcessorDirectives();
                        Console.ReadKey();
                        break;
                    case 1:
                        Trace.WriteLine(" Calling Selection 1");
                        break;
                    case 2:
                        Trace.WriteLine(" Calling Selection 2");
                        break;
                    case 3: DebugAssert();
                        Trace.WriteLine(" Calling Selection 3");
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
        static void PreProcessorDirectives()
        {
            /*  The #define directive defines a preprocessor symbol or conditional compilation symbol for the module
             *  that contains the directive.  You can use the #if and #elif preprocessor directive to see if the sybmol
             *  is defined.  Note: You cannot assign a value to the symbol, so it isn't comparable to a C# variable or
             *  constant.  All you can do is define or undefine the symbol and see if it has been defined.
             *  
             *  Both the #define and #undef directives must appear in a module before any nondirective statemement in
             *  a modules.  Because these statements must go at the beginning of the file, you normally don't use
             *  #undef to undefine a symbol that you had just created with a #define.  Usually #undef is more useful
             *  for undefining a symbol that you created using the projects' property pages.
             *  
             *  The #if, #elif, #else, and #endif directives work much like the C# if,else, and else if statements do,
             *  but they test preprocessor symbols instead of boolean expressions.  Because you cannot assign a value
             *  to a preprocessor symbol, these statements merely test whether a sybmol exists.
             *  
             *  Top of program
             *  #define DEBUG1
             *  //#define DEGUG2
             *  
             *       private void VerifyInternetConnections
             *       {
             *  #if DEBUG2
             *       // Display lots of debugging information
             *  #elif DEBUG1
             *       // Display some debugging information
             *  #else
             *       // Only exectuted if DEBUG1 or DEBUG2 are not defined.
             *       // Display minimal debugging information
             *  #endif
             *       // Verify the connetions
             *       }
             *  
             *  Predefined Compiler Constants
             *  DEBUG and TRACE
             *  
             *  Visual Studio predefines DEBUG and TRACE.  You can use these symbols using the
             *  #if, #elif, #else, and #endif directives.   DEBUG is only activated in Debug builds
             *  and not the Release Builds.  The TRACE costant is used in both the DEBUG and RELEASE
             *  Builds.
             *  
             *  
             *  Other Directives
             *  #warning - Generates a warning
             *  #line - allows you to change line number
             *  #line default - restores the lines that follow original numbering
             *  #region
             *  #endregion
             *  #pragma warning
             *  #pragma warning restore
             *  #pragma checksum
             *  
             *  
             *  
             */
            Process.Start("http://msdn.microsoft.com/en-us/library/vstudio/ed8yd1ha%28v=vs.100%29.aspx");
#if DEMO
            Console.WriteLine("Line only executed in Demo mode");
#elif !DEMO
            Console.WriteLine("Line only executed in NON-Demo mode");
#endif

#if OldMethod
#warning Using obsolete method
#else
#warning testing
#endif

        }
        static void DebugAssert()
        {
   /*
    *  A method can use Assert to verify that its data makes sense.   For example
    *  Debug.Assert(items.Length <=100)
    *  If an order contains more that 100 items, the Assert statement halts
    *  execution, so you can examine the code to decide whether this is a bug
    *  or just an unusual order.
    *  
    *  The "Assert" statement executes only in debug releases of a program.
    *  In a "release" build, the above Assert statement is ignored.
    * 
    */

        }
      
      
    }
}
