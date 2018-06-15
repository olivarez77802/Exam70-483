using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483
{
    /*
     * Called by CreateAndUseTypes.cs
    */
    class CreateTypes
    {
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Create Types \r ");
                Console.WriteLine(" Create value types (structs, enum), refererence types, generic types, \r");
                Console.WriteLine(" constructors, static variables, methods, classes, extension methods, \r");
                Console.WriteLine(" optional and named parameters, and indexed properties; create \r");
                Console.WriteLine(" overloaded and overridden methods \n");
                Console.WriteLine(" 0.  Value and Reference Types \n ");
                Console.WriteLine(" 1.  Generic Types \n ");
                Console.WriteLine(" 2.  Constructors \n ");
                Console.WriteLine(" 3.  Static Variables \n ");
                Console.WriteLine(" 4.  Extension Methods\n ");
                Console.WriteLine(" 5.  Optional/Named/Out Parameters \n ");
                Console.WriteLine(" 6.  Methods \n");
                Console.WriteLine(" 7.  Indexers \n");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: TypeSystem.Menu();
                        break;
                    case 1: DynamicExamples.DMain();
                        break;
                    case 4:
                        /* Extension Methods
                         * - Extend types without altering them.  Escpecially useful for extending types that are not yours or are sealed.
                         * - They are declared as static in a static class
                         * - The first paramter has the 'this' modifier
                         * - The first parameter's type is the type being extended
                         * 
                         * Both the class and the method have to be static
                         * The type that your extending goes into the signature as the first argument with the 'this' keywordaa
                         */
                        EnumerableMethods.Menu();
                        break;
                    case 5:
                        /* Optional/Named/Out Parameters
                         * 
                         * ***************************************************************************************
                         * Optional Parameters
                         * There are 4 ways that can be used to make method parameters optional
                         * 1. Use parameter arrays - Can have 0 or 1,2,3,... parameters.
                         * 2. Method overloading
                         * 3. Specify parameter defaults
                         * 4. Use OptionalAttribute that is present in System.Runtime.InteropServices namespace
                         * 
                         * Please note - A parameter array must be the last parameter in a formal parameter list.
                         * 
                         * 1. Parameter arrays
                         * 
                         * AddNumbers(10,20)  <-- 3 or more paramters optional 
                         * AddNumbers(10,20 new object[] {30,40,50});
                         * public static void AddNumbers( int firstNumber, int secondNumber, params object[] resetofNumbers)
                         * 
                         * params must be last parameter - below will get comile error
                         * public static void AddNumbers( int firstNumber,  params object[] resetofNumbers, int secondNumber)
                         * https://www.youtube.com/watch?v=jbtjGii300k&index=67&list=PLAC325451207E3105
                         * 
                         * 2. Method OverLoading
                         * 
                         * AddNumber(10,20)  <-- Will give error, since you must provide 3 or more paramters.
                         * AddNumber(10,20,null)  <-- will work without error
                         * publiic static void AddNumbers(int firstNumber, int secondNumber, int[] restofNumbers)
                         * 
                         * AddNumber(10,20)  <-- Will work with the below method overload
                         * public static void AddNumbers(int firstNumber, int secondNumber)
                         * {
                         *   AddNumbers(fistNumber, secondNumber, null);
                         * }
                         * public static void AddNumbers(int firstNumber, int secondNumber, int[] restOfNumbers)
                         * {
                         * }
                         * 
                         * https://www.youtube.com/watch?v=khcOI3-Kh84&index=68&list=PLAC325451207E3105
                         * 
                         * 3. Specifying parameter defaults - If we don't supply the third parameter then it
                         *    will take the default assigned).
                         * 
                         * AddNumbers(10,20);  <-- 3rd parameter will take default of null.
                         * AddNumbers(10, 20, new int[] {30, 40});  <-- will use 30, 40 as 3rd and 4th parameters.
                         * public static void AddNumbers(int firstNumber, int secondNumber, int[] restofNumbers = null)
                         * 
                         * 
                         * https://www.youtube.com/watch?v=Dmycz0ro1Yc&index=69&list=PLAC325451207E3105
                         * 
                         * 4. Optional Attribute - Present in System.Runtime.InteropServices namespace
                         * 
                         * using System.Runtime.InteropServices
                         * AddNumbers(10,20);
                         * public static void AddNumbers(int firstNumber, int secondNumber, [Optional] restofNumbers)
                         *
                         *                          * 
                         * https://www.youtube.com/watch?v=p_9f5SSXxLw&list=PLAC325451207E3105&index=70
                         * 
                         * 
                         * ***************************************************************************************
                         * Named Parameters
                         *   You don't have to specify the type.  The name and type is attained from the 
                         *   calling method.  You don't have to worry about the order, since the parameters
                         *   are named it is smart enough to figure them out regardless of the order.
                         *   
                         *   Sample
                         *   var customer = new Customer();
                         *   var order = new Order();
                         *   var payment = new Payment();
                         *   orderController.PlaceOrder
                         *   (customer, order, payment, allowSplitOrders:true, emailReceipt:false)
                         *
                         * **************************************************************************************
                         * Out Parameters
                         *   The 'out' keyword causes arguments to be passed by reference.  This is like 
                         *   the 'ref' keyword, except that the ref requires that the variable be 
                         *   initialized before it is passed.  To use an out parameter, both the 
                         *   method definition and the calling method must explicitly use the 
                         *   out keyword
                         * 
                         */
                        RunwithOutput();
                        break;
                    case 6: Methods.Menu();
                        break;
                    case 7: Indexer.Indexer_Main();
                        Console.ReadKey();
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

            /* http://msdn.microsoft.com/en-us/library/t3c3bfhx.aspx 
             * 
             * Default parameters
             * public Car(string colors, int number_of_wheels = 4)
             * 
             * var c = new Car("Blue");     <-- Will substitue, the value = 4 at compile time
             * 
             * 
             *  */

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
