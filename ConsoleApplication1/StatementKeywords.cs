using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Exam70483.App.App
{
   abstract class StatementKeywords
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Statement KeyWords Menu \n ");
                Console.WriteLine(" 0.  Selection Statements \n ");
                Console.WriteLine(" 1.  Iteration Statements \n ");
                Console.WriteLine(" 2.  Jump Statements \n");
                Console.WriteLine(" 3.   \n");
                Console.WriteLine(" 4.  Checked and unchecked \n");
                Console.WriteLine(" 5.  fixed Statement \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: SelectionStatements();
                        break;
                    case 1: IterationStatements.Menu();
                        break;
                    case 2: JumpStatements();
                        break;
                    case 3: 
                        break;
                    case 4: CheckedUncheckedStatements();
                        break;
                    case 5: FixedStatements();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        }

        static void SelectionStatements()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/676s4xab.aspx");
        }
        
        static void JumpStatements()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/d96yfwee.aspx");
        }
        
        static void CheckedUncheckedStatements()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/hh147286%28VS.88%29.aspx");
        }
        static void FixedStatements()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/f58wzh21.aspx");
        }
      
    }
}
