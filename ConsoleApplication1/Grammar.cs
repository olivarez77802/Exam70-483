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
                Console.WriteLine(" 0.  Escape Characters \n ");
                Console.WriteLine(" 1.  Value and Reference Types\n ");
                Console.WriteLine(" 2.  Operators and their Precedence \n");
                Console.WriteLine(" 3.  Preprocessing Directives \n");
                Console.WriteLine(" 4.  Program Flow \n");
                Console.WriteLine(" 5.  Statement Keywords \n");              
                Console.WriteLine(" 6.  Access Keywords \n");
                Console.WriteLine(" 7.  Conversion Keywords \n");
                Console.WriteLine(" 8.  KeyWords Menu \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: EscapeCharacters();
                        break;
                    case 1:
                        
                    case 2: Operators();
                        break;
                    case 3: PreProcessorDirectives();
                        break;
                    case 4: ProgramFlow();
                        break;
                    case 5: StatementKeywords.Menu();
                        break;
                    case 6: AccessKeywords.Menu();
                        break;
                    case 7:
                        //ConversionKeyWordExamples.PMain();
                        break;
                    case 8: Console.WriteLine(" Need to recreate KeyWords.Menu()");
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        }  // end Menu

        #region Escape Characters
        static void EscapeCharacters()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/6tcf2h8w.aspx");

        }
        #endregion


        static void Operators()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/6a71f45d.aspx");
            int i = 0;
            if (false & ++i == 1)
            {
                // i is incremented, but the conditional
                // expression evaluates to false, so
                // this block does not execute.
                Console.WriteLine("This line is never written using &");
            }
            Console.WriteLine(" Using & The value of i is {0} ", i);

            int j = 0;
            if (false && ++j == 1)
            {
                // i is incremented, but the conditional
                // expression evaluates to false, so
                // this block does not execute.
                Console.WriteLine("This line is never written using &&");
            }
            Console.WriteLine(" Using && The value of j is {0} ", j);
            Console.ReadKey();
        }
        #region PreProcessor Directives
        static void PreProcessorDirectives()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/vstudio/ed8yd1ha%28v=vs.100%29.aspx");
#if DEMO
            Console.WriteLine("Line only executed in Demo mode");
#elif DEMO
            Console.WriteLine("Line only executed in NON-Demo mode");
#endif
        }
        #endregion
        static void ProgramFlow()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/hh147286%28VS.88%29.aspx");
        }



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