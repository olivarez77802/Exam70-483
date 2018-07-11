using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    class AttributeExamples
    {
        /*
         * Attributes allow you to add declarative information to your programs.  This information can be queried at run time using
           reflection.  
           
           There are several predefined attributes created by .NET It is also possible to create your own Custom Attributes.
           A few predefined attributes within the .Net framework:
           obsolete - Marks type and type members as outdated
           WebMethod - To expose a webmethod as an XML Web Service
           Serializable - Indicates that a class can be serializable

           Do an ALT-F12 on the Attribute to view information on the sealed class

           An attribute is a class that inherits from the System.Attributes namespace
           https://www.youtube.com/watch?v=TWZXj27-6Cw&list=PLAC325451207E3105&index=52   
         * 
         */

        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Atributes");
               
                Console.WriteLine(" 0.  Obsolete Attribute ");
                Console.WriteLine(" 1.  WCF Web Service Examples");
                Console.WriteLine(" 2.  ..");
                Console.WriteLine(" 3.  ..");
                Console.WriteLine(" 4.  ..");
                Console.WriteLine(" 5.  ..");
                Console.WriteLine(" 6.  ..");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        ObsoleteEx();
                        break;
                    case 1:
                        WCFWebServiceExamples.Menu();
                        break;
                    case 2:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
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
        static void ObsoleteEx()
        {
            Calculator.Add(10, 20);
            Calculator.Add(new List<int> { 10, 20, 40 });

        }
        class Calculator
        {
            [Obsolete("Write any comment can be used to  point to new Method to use")]
            public static int Add(int FirstNumber, int SecondNumber)
            {
                return FirstNumber + SecondNumber;
            }
            public static int Add(List<int> Numbers)
            {
                int Sum = 0;
                foreach (int Number in Numbers)
                {
                    Sum = Sum + Number;
                }
                return Sum;
            }
        }
    }
}
