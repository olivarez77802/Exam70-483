using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JesseTesting.App
{
    class DebugAppImplementSecurity
    {
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Debug Applications and Implement Security \n ");
                Console.WriteLine(" 0.  Validate Application Input \n ");
                Console.WriteLine(" 1.  Perform Symmetric and ASymmetric Encryption \n ");
                Console.WriteLine(" 2.  Manage Assemblies \n ");
                Console.WriteLine(" 3.  Debug an Application \n ");
                Console.WriteLine(" 4.  Implement Diagnostics in an Application \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 1: CryptographyExamples.Menu();
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
