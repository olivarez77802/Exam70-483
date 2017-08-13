using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483.App.App
{
    class ValueTypes
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Value Types Menu \n ");
                Console.WriteLine(" 0.  Structs  \n ");
                Console.WriteLine(" 1.  Enums  \n ");
                Console.WriteLine(" 2.  Numeric \n");
                Console.WriteLine(" 3.  Char \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: ClassesAndInterfaces.Menu();
                        break;
                    case 1: 
                        EnumTest.EnumMain();
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
