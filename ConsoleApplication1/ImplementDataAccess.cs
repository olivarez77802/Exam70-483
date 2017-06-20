using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JesseTesting.App
{
    class ImplementDataAccess
    {
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Implement Data Access \n ");
                Console.WriteLine(" 0.  Perform I/O Operations \n ");
                Console.WriteLine(" 1.  Consume Data \n ");
                Console.WriteLine(" 2.  Query and Manipulate data and Objects using LINQ \n ");
                Console.WriteLine(" 3.  Serialize and Deserialize Data  \n ");
                Console.WriteLine(" 4.  Store Data and Retrieve Data from Collections \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: InputOutput.Menu();
                        break;
                    case 4: Collections.CollectionsMenu();
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
