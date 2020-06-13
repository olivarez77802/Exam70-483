using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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

        internal static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Atributes");
               
                Console.WriteLine(" 0.  Obsolete Attribute ");
                Console.WriteLine(" 1.  WCF Web Service Examples");
                Console.WriteLine(" 2.  APMain..");
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
                        APMain();
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
        /* 
         * Nested classes are private by default, so I could delete private
         * Example of how the outside class is private but the inside method is public or internal
         */
        private static class Calculator
        {
            [Obsolete("Write any comment can be used to  point to new Method to use")]
            internal static int Add(int FirstNumber, int SecondNumber)
            {
                return FirstNumber + SecondNumber;
            }
            internal static int Add(List<int> Numbers)
            {
                int Sum = 0;
                foreach (int Number in Numbers)
                {
                    Sum = Sum + Number;
                }
                return Sum;
            }
        }
        #region AttributeProgram
      
            [System.Obsolete("use class B")]
            class A
            {
                private void Method() { }
            }
            class B
            {
                [System.Obsolete("use New Method", true)]
                private static void OldMethod() { }
                internal void NewMethod() { }
            }
            class Check : Attribute
            {
                public int MaxLength { get; set; }
            }
            class Customer
            {
                private string _CustomerCode;

                [Check(MaxLength = 12)]
                internal string CustomerCode
                {
                    get { return _CustomerCode; }
                    set { _CustomerCode = value; }
                }
            }
          
         
        static void APMain()
        {
            /*
            Process.Start("https://msdn.microsoft.com/en-us/library/22kk2b44(v=vs.90).aspx");
            Process.Start("http://www.codeproject.com/Articles/827091/Csharp-Attributes-in-minutes#Whatareattributesandwhydoweneedit");
            */

            // Generate 2 warnings
            A a = new A();
            // Generate no errors or warnings
            B b = new B();
            b.NewMethod();
            // Generates an error, terminating compilation
            // b.OldMethod();
           // Console.ReadKey();

            Customer obj = new Customer();
            obj.CustomerCode = "12345678901";

            //Get the type of the object
            Type objtype = obj.GetType();
            Console.WriteLine(" Object type is {0}", objtype);

            //Use the 'Type' object and loop through all properties and attributes
            foreach (PropertyInfo p in objtype.GetProperties())
            {
                // for every property loop through all attributes
                foreach (Attribute t in p.GetCustomAttributes(false))
                {
                    Check c = (Check)t;
                    Console.WriteLine(" t is {0}", t);
                    Console.WriteLine(" p is {0}", p.Name);
                    if (p.Name == "CustomerCode")
                    {
                        Console.WriteLine("Attribute Max Lenth is {0}", c.MaxLength);
                        if (obj.CustomerCode.Length > c.MaxLength)
                        {
                            throw new Exception(" Max length issues ");
                        }
                    }
                }
            } //end foreach

            Console.ReadKey();

        }  //endAPMain

        #endregion
    }
}
