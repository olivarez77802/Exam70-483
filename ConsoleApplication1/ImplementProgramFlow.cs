using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    public class ImplementProgramFlow
    {
        public static void Menu()
        {


            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Implement Program Flow \n ");
                Console.WriteLine("    Iterate across collection and array items; program decisions by using switch \n");
                Console.WriteLine("    statements, if/then, and operators; evaluate expressions");
                Console.WriteLine(" 0.  Ternary / Short-circuiting logic  \n ");
                Console.WriteLine(" 1.  Iteration Statements \n ");
                Console.WriteLine(" 2.  Switch Statemement \n");
                Console.WriteLine(" 3.  Operators ");
                Console.WriteLine(" 2.   \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        ShortCircuit();
                        break;
                    case 1:
                        IterationStatements.Menu();
                        break;
                    case 2:
                    // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
                        break;
                    case 3:
                        break;
                    // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator  

                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        }


        static void ShortCircuit()
        {
            /* 
             * Short-circuiting logic
             *   && and || operators
             *   ?:conditional 'ternary' operators
             *   Use truthiness unary operators 'true' and 'false'
             *   
             *   The ternary or conditional operater can be used
             *   as 'if statement' shorthand
             *   
             *   if (value == 1)
             *   {
             *     Console.WriteLine("one");
             *   }
             *   else
             *   {
             *     Console.WriteLine("Not one");
             *   }
             *   //Ternary Shorthand
             *   Console.WriteLine(value == 1 ? "One" : "Not one");
             *   
             *   
            */

        }
    }
}
