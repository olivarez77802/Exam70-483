using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Exam70483
{
    class TypeMembers
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Type Members Menu \n ");
                Console.WriteLine(" 0.  .....\n ");
                Console.WriteLine(" 1.  .... \n");
                Console.WriteLine(" 2.  Indexers \n");
                Console.WriteLine(" 3.  Properties \n");
                Console.WriteLine(" 4.  Variables  \n");
                Console.WriteLine(" 9.  Quit       \n ");
                Console.Write(" Enter Number to execute Routine ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
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
