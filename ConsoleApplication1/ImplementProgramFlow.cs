﻿using System;
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
                Console.WriteLine(" 2.  Operators");
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
                        Operators.Menu();
                        Console.ReadKey();
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


        static void ShortCircuit()
        {
            /* 
             * Short-circuiting logic
             *   && and || operators
            
             *   
            */

        }
    }
}
