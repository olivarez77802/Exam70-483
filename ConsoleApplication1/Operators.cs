using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    /*
    https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/increment-operator

    See Collections.cs for more information on Ternary Operators.
    */
    class Operators
    {
        /*
         * See also ReferenceTypes.cs for Nullable Value Types (int?,double?, bool?, char?).
        */
        public static void Menu()
        {

           
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Iteration Statements Menu \n ");
                Console.WriteLine(" 0.  Prefix_PostFix Operator ");
                Console.WriteLine(" 1.  Ternary_Operator ");
                Console.WriteLine(" 2.  ShortCircuit && Operator ");
                Console.WriteLine(" 3.  Ternary Operator..Postfix..Prefix");
                Console.WriteLine(" 4.  Null Coalesce Operator ");
                Console.WriteLine(" 5.  ... ");
                Console.WriteLine(" 6.  ... ");
                Console.WriteLine(" 7.  ... ");
                Console.WriteLine(" 9.  Quit  ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        Operator_plus();
                        Console.ReadKey();
                        break;
                    case 1:
                        Ternary_Operator();
                        Console.ReadKey();
                        break;
                    case 2:
                        ShortCircuitAND();
                        Console.ReadKey();
                        break;
                    case 3:
                        Ternary_Operator2();
                        Console.ReadKey();
                        break;
                    case 4:
                        Null_Coalesce_Example();
                        Console.ReadKey();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
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


        static void Operator_plus()
        {
            /*
             * ++x - is a prefix increment operation.  The result of the operation is the value of the operand after it has been
             *       incremented.  
             * x--   is a postfix increment operation.  The result of the operation is the value of the operand before it has been
             *       incremented.
            */
            Console.WriteLine("Prefix and Postfix increment operation");
            double x;
            x = 1.5;
            Console.WriteLine(++x);  // Output 2.5
            x = 1.5;
            Console.WriteLine(x++);  // Output 1.5
            Console.WriteLine(x);    // Output 2.5
        }
        static void Ternary_Operator()
        {
            /*
             *   ?:conditional 'ternary' operators
             * Use truthiness unary operators 'true' and 'false'
             *   
             *   The ternary or conditional operater can be used
             *   as 'if statement' shorthand
             *
             *   if (value == 1)
             *   {
             *     Console.WriteLine("one");
             *   }
             *   else
             *   {
             * Console.WriteLine("Not one");
             *
             *   //Ternary Shorthand
             * Console.WriteLine(value == 1 ? "One" : "Not one");
             *
             */
            Console.WriteLine("Ternary Conditional Operator");
            int input = Convert.ToInt32(Console.ReadLine());
            string classify;

            // if-else construction.  
            if (input > 0)
                classify = "positive";
            else
                classify = "negative";

            // ?: conditional operator.  
            classify = (input > 0) ? "positive" : "negative";
            Console.WriteLine("classify is {0}", classify);
        }
        static void Ternary_Operator2()
        {
            int i = 1;
            int j;
            // Result is 1
            j = i < 5 ? square(i++) : square(i--);
            Console.WriteLine("Postfix Square is {0}", j);
            // Result is 36
            i = 6;
            j = i < 5 ? square(i++) : square(i--);
            Console.WriteLine("Postfix Square is {0}", j);
            // Result is 4
            i = 1;
            j = i < 5 ? square(++i) : square(--i);
            Console.WriteLine("Prefix Square is {0}", j);
            // Result is 25
            i = 6;
            j = i < 5 ? square(++i) : square(--i);
            Console.WriteLine("Prefix Square is {0}", j);

        }
        static int square (int i)
        {
            return i * i;
        }
        static void ShortCircuitAND()
        {
            /*
             && Operator
             The conditional - AND operator (&&) performs a logical - AND of its bool operands, 
             but only evaluates its second operand if necessary.
            */

            // Each method displays a message and returns a Boolean value. 
            // Method1 returns false and Method2 returns true. When & is used,
            // both methods are called. 
            Console.WriteLine("Short circuit && versus noral &");
            Console.WriteLine("Regular AND:");
            if (Method1() & Method2())
                Console.WriteLine("Both methods returned true.");
            else
                Console.WriteLine("At least one of the methods returned false.");

            // When && is used, after Method1 returns false, Method2 is 
            // not called.
            Console.WriteLine("\nShort-circuit AND:");
            if (Method1() && Method2())
                Console.WriteLine("Both methods returned true.");
            else
                Console.WriteLine("At least one of the methods returned false.");


        }

        static bool Method1()
        {
            Console.WriteLine("Method1 called.");
            return false;
        }

        static bool Method2()
        {
            Console.WriteLine("Method2 called.");
            return true;
        }
        static void ShortCircuitOR()
        {
            // Example #1 uses Method1 and Method2 to demonstrate 
            // short-circuit evaluation.

            Console.WriteLine("Regular OR:");
            // The | operator evaluates both operands, even though after 
            // Method1 returns true, you know that the OR expression is
            // true.
            Console.WriteLine("Result is {0}.\n", Method1_OR() | Method2_OR());

            Console.WriteLine("Short-circuit OR:");
            // Method2 is not called, because Method1 returns true.
            Console.WriteLine("Result is {0}.\n", Method1_OR() || Method2_OR());


            // In Example #2, method Divisible returns True if the
            // first argument is evenly divisible by the second, and False
            // otherwise. Using the | operator instead of the || operator
            // causes a divide-by-zero exception.

            // The following line displays True, because 42 is evenly 
            // divisible by 7.
            Console.WriteLine("Divisible returns {0}.", Divisible(42, 7));

            // The following line displays False, because 42 is not evenly
            // divisible by 5.
            Console.WriteLine("Divisible returns {0}.", Divisible(42, 5));

            // The following line displays False when method Divisible 
            // uses ||, because you cannot divide by 0.
            // If method Divisible uses | instead of ||, this line
            // causes an exception.
            Console.WriteLine("Divisible returns {0}.", Divisible(42, 0));
        }
        // Method1 returns true.
        static bool Method1_OR()
        {
            Console.WriteLine("Method1 called.");
            return true;
        }

        // Method2 returns false.
        static bool Method2_OR()
        {
            Console.WriteLine("Method2 called.");
            return false;
        }


        static bool Divisible(int number, int divisor)
        {
            // If the OR expression uses ||, the division is not attempted
            // when the divisor equals 0.
            return !(divisor == 0 || number % divisor != 0);

            // If the OR expression uses |, the division is attempted when
            // the divisor equals 0, and causes a divide-by-zero exception.
            // Replace the return statement with the following line to
            // see the exception.
            //return !(divisor == 0 | number % divisor != 0);
        }
        static void Null_Coalesce_Example()
        {
            int? x = null;

            // Set y to the value of x if x is not NULL; otherwise
            // if x==null, set y to -1
            int y = x ?? -1;

            // Assign i to return value of the method if the method's result
            // is not NULL; otherwise, if the result is null, set i to the 
            // default value of int.
            int i = GetNullableInt() ?? default(int);

            // Display the value of s if s is NOT null; otherwise,
            // display the string "Unspecified".
            string s = GetStringValue();
            Console.WriteLine(s ?? "Unspecified");

        }
        static int? GetNullableInt()
        {
            return null;
        }
        static string GetStringValue()
        {
            return null;
        }
    } // end Class Operators


}
