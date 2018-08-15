using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    /*
    https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/increment-operator
    */
    class Operators
    {
        public static void Menu()
        {
            Operator_plus();
            Ternary_Operator();
            ShortCircuitAND();
            //ShortCircuitOR();
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
    } // end Class Operators

}
