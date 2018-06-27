using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.MathService1;

namespace Exam70483
{
    class ConsumeData
    {
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
                Console.WriteLine(" 8.  WCF WebService ");
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
                        WCFWebService();
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
        static void WCFWebService()
        {

            MathServiceClient client = new MathServiceClient();

            int result = client.Add(5, 6);
            Console.WriteLine(" Result from WCF WebService Add 5 + 6 is {0}", result);
            int result2 = client.Multiply(5, 6);
            Console.WriteLine(" Result from WCF WebService Multiply 5 * 6 is {0}", result2);
            int result3 = client.Subtract(10, 5);
            Console.WriteLine(" Result from WCF WebService Subtract 10 - 5 is {0}", result3);
            int result4 = client.Divide(10, 5);
            Console.WriteLine(" Result from WCF WebService Multiply 10 / 5 is {0}", result4);
            //Process.Start("https://www.youtube.com/watch?v=GzN1vHWlJjA");
        }

    }
}
