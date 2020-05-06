using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Exam70483
{
    /*
     * Create and Use Types/ Manipulate Strings
     *    Manipulate strings by using the StringBuilder, StringWriter, and StringReader classes; search strings;
     *    enumerate string methods; format strings; use string interpolation.
    */
   // struct ManipulateStrings   // and String Examples
   struct CreateAndUseTypes_6
    {
        #region Main
        public static void Menu()
        {
            IMenu CUT6 = new CUT6_Methods();
            int x = 0;
            do
            {
                //Process.Start("http://msdn.microsoft.com/en-us/library/z2kcy19k.aspx");
                //Process.Start("http://www.dotnetperls.com/stringbuilder");
                Console.Clear();
                Console.WriteLine("Manipulate Strings");
                Console.WriteLine("  Maniuplate strings using StringBuilder, StringWriter, and  ");
                Console.WriteLine("  StringReader classes; search strings; enumerate string");
                Console.WriteLine("  methods; format strings; use string interpolation ");

                Console.WriteLine(" 0.  StringBuilder");
                Console.WriteLine(" 1.  StringWriter");
                Console.WriteLine(" 2.  StringReader");
                Console.WriteLine(" 3.  Format Strings");
                Console.WriteLine(" 4.  String Methods");
                Console.WriteLine(" 5.  String Equality");
                Console.WriteLine(" 6.  Display Character Set");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: CUT6.MenuOpt0();
                            break;
                    case 1: CUT6.MenuOpt1();
                        //StringWriter_Ex();
                        Console.ReadKey();
                        break;
                    case 2: CUT6.MenuOpt2();
                        //StringReader_Ex();
                        Console.ReadKey();
                        break;
                    case 3: CUT6.MenuOpt3();
                        break;
                    case 4: CUT6.MenuOpt4();
                        //Process.Start("https://msdn.microsoft.com/en-us/library/system.string_methods(v=vs.110).aspx");
                        //StringMethodExamples.SMEMain();
                        Console.ReadKey();
                        break;
                    case 5: CUT6.MenuOpt5();
                        break;
                    case 6: CUT6.MenuOpt6();
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
        #endregion
       
    } /* end Class ManipulateStrings */


}
