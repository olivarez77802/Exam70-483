using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    public class Lambda 
    {
        /*  Anonymous Methods were developed in C# 2.0.   Anonymous syntax is a bit
         *  harder to write and manage.  In C# 3.0 Lambda expressions are introduced, it provides a simple,
         *  more concise syntax to write lambda methods.
         *  
         *  Arguments To Process => Statments to Process
         *  
         *  There are two types of Lambda expressions,
            Expression Lambda
            It has only one expression, with no curly brace or return statement.

            Statement Lambda
            It is a collection of statements.
         * 
         * https://www.c-sharpcorner.com/article/anonymous-methods-and-lambda-expressions-in-c-sharp/
         * 
         * Named Methods - Anonymous methods were a replacement for Named Methods.  Lamda Expressions are 
         * better alternative to using named anonymous methods
         * https://www.tutorialspoint.com/csharp/csharp_anonymous_methods.htm
         */

        public static List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
        
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Lambda Expression Menu \n ");
                Console.WriteLine(" 0.  Expression Lambda \n ");
                Console.WriteLine(" 1.  Statement Lambda \n ");
                Console.WriteLine(" 2.  \n");
                Console.WriteLine(" 3.  \n");
                Console.WriteLine(" 4.  \n");
                Console.WriteLine(" 5.  ... \n");
                Console.WriteLine(" 6.  ... \n");
                Console.WriteLine(" 7.  ... \n");
                Console.WriteLine(" 9.  Quit   \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: ExpressionLambda();                                            
                            Console.ReadLine();
                            break;
                    case 1: StatementLambda();
                            Console.ReadLine();
                             break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        } // End Menu()
        static void ExpressionLambda()
        {
            int res = list.Find(n => n == 3);
            if (res == 0)
            {
                Console.WriteLine("item not found in the list");
            }
            else
            {
                Console.WriteLine("Item found");
            }

        }
        static void StatementLambda()
        {
            List<int> res = list.FindAll(n =>
            {
                if (n <= 5)
                {
                    return true;
                }
                else
                    return false;
            });
            Console.WriteLine("Value of n<5 are: ");
            foreach (int item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}
