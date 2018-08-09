using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Exam70483
{
    class AccessKeywords  //making it abstract means I will never want this class to be instantiated.
    {

        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Access Keywords \n ");
                Console.WriteLine(" 0.  base \n ");
                Console.WriteLine(" 1.  this \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: baseKeyWord();
                        break;
                    case 1: thisKeyWord();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        }

        static void baseKeyWord()
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/hfw7t1ce.aspx");
            Process.Start("http://www.csharp-station.com/Tutorial/CSharp/lesson08");
            BaseExamples.TMain();
            Console.ReadKey();
            BaseExamples.D_Main();
            Console.ReadKey();
        }

        static void thisKeyWord()
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/dk1507sz.aspx");
        }



    }
}


