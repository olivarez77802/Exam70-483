using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exam70483
{
   
    class ConsumeData
    {
     /*
     * I can't move this object to Folder ImplementDataAccess until ExamLibrary has a reference to Newton.JSON
     * see JSONExamples.cs
     */
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Consume data \n ");
                Console.WriteLine("    Retrieve data from a database; update data in a database; \n ");
                Console.WriteLine("    consume JSON and XML data; retrieve data by using web services. \n\n ");
                Console.WriteLine(" 0.  ... ");
                Console.WriteLine(" 1.  ... ");
                Console.WriteLine(" 2.  ... ");
                Console.WriteLine(" 3.  ... ");
                Console.WriteLine(" 4.  ....");
                Console.WriteLine(" 5.  ... ");
                Console.WriteLine(" 6.  JSON ");
                Console.WriteLine(" 7.  XML ");
                Console.WriteLine(" 8.  WCF WebService Examples ");
                Console.WriteLine(" 9.  Quit            \n\n ");


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
                        break;
                    case 6:
                        JSONExamples.Menu();
                        Console.ReadKey();
                        break;
                    case 7:
                        XMLExamples.Menu();
                        Console.ReadKey();
                        break;
                    case 8:
                        WCFWebServiceExamples.Menu();
                        Console.ReadKey();
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
