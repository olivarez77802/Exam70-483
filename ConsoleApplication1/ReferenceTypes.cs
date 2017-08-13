using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483.App.App
{
    class ReferenceTypes
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Reference Types Menu \r ");
                Console.WriteLine(" object.Equals() evaluates to Reference Equality (unless overridden\n ");
                Console.WriteLine(" 0.  String \n ");
                Console.WriteLine(" 1.  Object \n ");
                Console.WriteLine(" 2.  Class  \n ");
                Console.WriteLine(" 3.  Array  \n ");
                Console.WriteLine(" 4.  Delegate \n ");
                Console.WriteLine(" 5.  Inteface \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: Collections.CollectionsMenu();
                        break;
                    case 1:
                        EnumTest.EnumMain();
                        break;
                    case 3: Collections.CollectionsMenu();
                        break;
                    case 4: Delegate.Menu();
                        break;
                    case 5: InterfacesMenu.Menu();
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
