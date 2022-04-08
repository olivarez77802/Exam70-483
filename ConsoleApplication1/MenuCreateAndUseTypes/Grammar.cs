#define DEMO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Exam70483.MenuCreateAndUseTypes
{
    class Grammar
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Grammar Menu \n ");
                Console.WriteLine(" 0.  ... \n ");
                Console.WriteLine(" 1.  ... \n ");
                Console.WriteLine(" 2.  ... \n");
                Console.WriteLine(" 3.  ... \n");
                Console.WriteLine(" 4.  ... \n");
                Console.WriteLine(" 5.  Statement Keywords \n");              
                Console.WriteLine(" 6.  Access Keywords \n");
                Console.WriteLine(" 7.  ...  \n");
                Console.WriteLine(" 8.  ... \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: 
                        break;
                    case 1:
                        break;
                    case 2: 
                        break;
                    case 3: 
                        break;
                    case 4:
                        break;
                    case 5:
                        MenuManageProgramFlow.StatementKeywords.Menu();
                        break;
                    case 6: MenuCreateAndUseTypes.AccessKeywords.Menu();
                        break;
                    case 7:
                         break;
                    case 8: 
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        }  // end Menu

       


    } // end Class Grammer

    

}  // End of NameSpace