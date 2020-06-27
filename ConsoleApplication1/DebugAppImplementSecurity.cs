using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483
{
    class DebugAppImplementSecurity
    {
        public static void Menu()
        {
            //Temp
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Debug Applications and Implement Security \r ");
                Console.WriteLine(" 0.  Validate Application Input \r ");
                Console.WriteLine("     Validate JSON data; choose the appropriate data collection type; \r ");
                Console.WriteLine("     manage data integrity; evaluate a regular expression to validate \r");
                Console.WriteLine("     the input format; use built-in functions to validate data type \r");
                Console.WriteLine("     and content \r");
                Console.WriteLine(" 1.  Perform Symmetric and ASymmetric Encryption \r ");
                Console.WriteLine("     Choose and appropriate encryption algorithm; manage and create  \r");
                Console.WriteLine("     certificates; implement key management; implement the \r");
                Console.WriteLine("     System.Security namespace; hash data and encrypt streams \r");
                Console.WriteLine(" 2.  Manage Assemblies \r ");
                Console.WriteLine("     Version assemblies; sign assemblies using strong names; implement \r");
                Console.WriteLine("     side-by-size; put an assembly in the global assembly cache; create a \r");
                Console.WriteLine("     a WinMD assembly \r");
                Console.WriteLine(" 3.  Debug an Application \r ");
                Console.WriteLine("     Create and manage preprocessor directives; choose an appropriate build \r");
                Console.WriteLine("     type; manage program database files (debug symbols)\r");
                Console.WriteLine(" 4.  Implement Diagnostics in an Application \r ");
                Console.WriteLine("     Implement logging and tracing; profiling applications; create and \r");
                Console.WriteLine("     monitor performance counters; write to the event log. \r");
                Console.WriteLine(" 9.  Quit            \r\r ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: ValidateAppInput.Menu();
                        break;
                    case 1: CryptographyExamples.Menu();
                        break;
                    case 2: ManageAssemblies.Menu();
                        break;
                    case 3: DebugApplication.Menu();
                        break;
                    case 4: ImplementDiagnostics.Menu();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;

                }


            } while (x < 9);
        }
    }
}
