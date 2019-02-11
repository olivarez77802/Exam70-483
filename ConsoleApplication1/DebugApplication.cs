using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    class DebugApplication
    {
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Debug an Appication \n ");
                Console.WriteLine(" 0.  Create and Manage Preprocessor directives \n ");
                Console.WriteLine(" 1.  Choose an approriate build type \n ");
                Console.WriteLine(" 2.  Manage program database files (debug symbols) \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        PreProcessorDirectives();
                        break;
                    case 1:
                        break;
                    case 2:
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
            /*  The #define directive defines a preprocessor symbor or conditional compilation symbol for the module
             *  that contains the directive.  You can use the #if and #elif proprocessor directive to see if the sybmol
             *  is defined.  Note: You cannot assign a value to the symbol, so it isn't comparable to a C# variable or
             *  constant.  All you can do is define or undefine the symbol and see if it has been defined.
             *  
             *  Both the #deine and #undef directives must appear in a module before any nondirective statemement in
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
             *  //#define DEGUG1
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
#elif DEMO
            Console.WriteLine("Line only executed in NON-Demo mode");
#endif

        }


    }
}
