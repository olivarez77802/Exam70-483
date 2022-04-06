#define DEMO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Exam70483
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
                    case 5: StatementKeywords.Menu();
                        break;
                    case 6: ExamLibrary.CreateAndUseTypes.AccessKeywords.Menu();
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

    public class EnumTest
    {
        enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
        public static void EnumMain()
        {
            int x = (int)Days.Sun;
            int y = (int)Days.Fri;
            Console.WriteLine("Sun = {0}", x);
            Console.WriteLine("Fri = {0}", y);
        }
    }

}  // End of NameSpace