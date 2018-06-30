using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    class ValidateAppInput
    {
        /*
         *  Validate Application Input
         *  
        */
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Validate Application Input \n ");
                Console.WriteLine("     Validate JSON data; choose an appropriate data collection type; \n ");
                Console.WriteLine("     manage data integrity; evaluate a regular expression to validate \n");
                Console.WriteLine("     the input format; use built-in functions to validate data type \n");
                Console.WriteLine("     and content \n");
                Console.WriteLine(" 0.  JSON \n ");
                Console.WriteLine(" 1.  ..  \n ");
                Console.WriteLine(" 2.  .. \n ");
                Console.WriteLine(" 3.  .. \n ");
                Console.WriteLine(" 4.  .. \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        JSONExamples.Menu();
                        Console.ReadKey();
                        break;
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    case 4:
                        
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
    }
}

