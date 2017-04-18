using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JesseTesting.App
{
    class CreateTypes
    {
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Create Types \n ");
                Console.WriteLine(" 0.  Value and Reference Types \n ");
                Console.WriteLine(" 1.  Generic Types \n ");
                Console.WriteLine(" 2.  Constructors \n ");
                Console.WriteLine(" 3.  Static Variables \n ");
                Console.WriteLine(" 4.  \n ");
                Console.WriteLine(" 5.  Optional/Named/Out Parameters \n ");
                Console.WriteLine(" 6.  Methods n");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: TypeSystem.Menu();
                        break;
                    case 1: DynamicExamples.DMain();
                        break;
                    case 5: RunwithOutput();
                        break;
                    case 6: Methods.Menu();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;

                }


            } while (x < 9);
        }

        static void RunwithOutput()
        {

            /* http://msdn.microsoft.com/en-us/library/t3c3bfhx.aspx  */

            Console.Clear();
            Console.WriteLine("\nRunwithOutput");
            Console.WriteLine("\nThe 'out' keyword causes arguments to be passed by reference.  This is like ");
            Console.WriteLine("the 'ref' keyword, except that the ref requires that the variable be ");
            Console.WriteLine("initialized before it is passed.  To use an out parameter, both the ");
            Console.WriteLine("method definition and the calling method must explicitly use the ");
            Console.WriteLine("out keyword");
            var simpleMath = new MathOps();
            int answer, remainder;
            simpleMath.Divide2(15, 6, out answer, out remainder);
            Console.WriteLine("\nanswer " + answer);
            Console.WriteLine("remainder" + remainder);
            Console.Write("\nPress Enter to Continue ");
            Console.ReadKey();
        }
    }
}
