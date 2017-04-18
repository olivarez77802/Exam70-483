using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JesseTesting.App
{
    class ManageProgramFlow
    {
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Manage Program Flow \n");
                Console.WriteLine(" 0.  Implement MultiThreading and ASynchrounous Processing \n ");
                Console.WriteLine(" 1.  Manage MultiThreading n ");
                Console.WriteLine(" 2.  Implement Program Flow \n ");
                Console.WriteLine(" 3.  Create and Implement Events and CallBacks \n ");
                Console.WriteLine(" 4.  Implement Exception Handling \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 1: CryptographyExamples.Menu();
                        break;
                    case 4: ExceptionClassExamples.Menu();
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
