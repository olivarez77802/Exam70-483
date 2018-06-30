using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    public class RunTimeTypes
    {
        /*
           
           Attributes allow you to add declarative information to your programs.  This information can be queried at run time using
           reflection.  
           
           There are several predefined attributes created by .NET It is also possible to create your own Custom Attributes.
           A few predefined attributes within the .Net framework:
           obsolete - Marks type and type members as outdated
           WebMethod - To expose a webmethod as an XML Web Service
           Serializable - Indicates that a class can be serializable

           An attribute is a class that inherits from the System.Attributes namespace
           https://www.youtube.com/watch?v=TWZXj27-6Cw&list=PLAC325451207E3105&index=52   
           
           See also DynamicExamples.cs
           
           Windows RunTime
           https://www.youtube.com/watch?v=24Uaf3Y4qW8
               
                         
        */


        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Find, execute, and create types at runtime by using reflection");
                Console.WriteLine("    Create and apply attributes; read attributes; generate code at runtime");
                Console.WriteLine("    using CodeDom and Lambda expressions; use types from the System.Refection");
                Console.WriteLine("    namespace, including Assembly, PropetryInfo, MethodInfo, Type");
          
                Console.WriteLine(" 0.  Reflection ");
                Console.WriteLine(" 1.  Relection - GetTypes");
                Console.WriteLine(" 2.  Refelection - GetExecutingAssembly");
                Console.WriteLine(" 3.  Reflection - Determine Type ");
                Console.WriteLine(" 4.  CodeDom ");
                Console.WriteLine(" 5.  ... ");
                Console.WriteLine(" 6.  ... ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        ReflectionExamples.Menu();
                        break;
                    case 1:
                        AssemblyClassExamples.GetTypes();
                        Console.ReadKey();
                        break;
                    case 2:
                        AssemblyClassExamples.GetExecutingAssembly();
                        Console.ReadKey();
                        break;
                    case 4:
                        AssemblyClassExamples.Determine_type();
                        break;
                    case 5:
                         break;
                    case 6:
                        CodeDom_Example();
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
        static void CodeDom_Example()
        {
            /*
             * Code (D)ocument (O)bject (M)odel
             * Writing Code that Writes Code
             * 
             */
        }
    }
}
