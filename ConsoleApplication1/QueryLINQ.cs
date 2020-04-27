using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{ 
    class QueryLINQ
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Query and manipulate data and objects by using LINQ \n ");
                Console.WriteLine("    Query data by using operators, including projection, ");
                Console.WriteLine("    join, group, take, skip, aggregate; create method  ");
                Console.WriteLine("    based LINQ Queries; query data by using query comprehension");
                Console.WriteLine("    syntax; select data by using anonymous types; force ");
                Console.WriteLine("    execution of a query; read, filter, create and modify  ");
                Console.WriteLine("    data structures by using LINQ to XML.  ");
                Console.WriteLine(" 0.  LINQ Examples ");
                Console.WriteLine(" 1.  Anonymous Types ");
                Console.WriteLine(" 2.  ... ");
                Console.WriteLine(" 3.  ... ");
                Console.WriteLine(" 4.  ....");
                Console.WriteLine(" 5.  ... ");
                Console.WriteLine(" 6.  ... ");
                Console.WriteLine(" 7.  ... ");
                Console.WriteLine(" 8.  ....");
                Console.WriteLine(" 9.  Quit            \n\n ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        LINQExamples.Menu();
                        break;
                    case 1:
                        Anonymous.Menu();
                        break;
                    case 2:
                       
                        break;
                    case 3:
                       
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
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
