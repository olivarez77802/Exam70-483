using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class AttributeExamples
    {

        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Atributes");
                Console.WriteLine("    Create and apply attributes; read attributes; generate code at runtime");
                Console.WriteLine("    using CodeDom and Lambda expressions; use types from the System.Refection");
                Console.WriteLine("    namespace, including Assembly, PropetryInfo, MethodInfo, Type");

                Console.WriteLine(" 0.  Reflection ");
                Console.WriteLine(" 1.  Relection - GetTypes");
                Console.WriteLine(" 2.  Refelection - GetExecutingAssembly");
                Console.WriteLine(" 3.  Reflection - Determine Type ");
                Console.WriteLine(" 4.  CodeDom ");
                Console.WriteLine(" 5.  Attributes ");
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
                        AttributeExamples.Menu();
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
    }
}
