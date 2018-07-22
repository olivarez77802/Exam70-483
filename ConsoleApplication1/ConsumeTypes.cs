using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    /*
     * Consume Types
     *    Box or unbox to convert value types; cast types; convert types; handle dynamic types; 
     *    ensure interoperability with code that access COM API's.
     */
   public class ConsumeTypes
    {
        public static void Menu()
        {
            
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Consume Types \n ");
                Console.WriteLine(" 0.  Box or unbox to convert Value Types \n ");
                Console.WriteLine(" 1.  Cast Types \n ");
                Console.WriteLine(" 2.  Convert Types \n ");
                Console.WriteLine(" 3.  Dynamic Types \n");
                Console.WriteLine(" 4.  COM API \n");
                Console.WriteLine(" 5.  Parse Examples");
                Console.WriteLine(" 6.  TryParse Example");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: Boxing();
                        Console.ReadKey();
                        break;
                            
                    case 1:
                        CastExamples();
                        break;
                    case 2:
                        ConvertTypes();
                        Console.ReadKey();
                        break;
                    case 3:
                        DynamicExamples.DMain();
                        Console.ReadKey();
                        break;
                    case 4:
                       
                        break;
                    case 5:
                        ParseExamples.Main_Mod();
                        Console.ReadKey();
                        break;

                    case 6: TryParseExamples();
                        break;
                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);  // end do
        } // end Menu
        static void Boxing()
        {
            /* 
             * Object - Keyword that allow you to store any kind of data type.
             * 
             * 
             * Boxing is the act of converting a VALUE type instance to a REFERENCE type
               instance.   

                int x = 9;
                object y = x;   -  box the int

                Unboxing casts the object back to the VALUE type

                x = (int)y; 
                unbox the int
                https://www.youtube.com/watch?v=A8q88vDDSsY

            */
            int x = 9;    /* Values Type */
            object y = x; /* Reference Type */
            x = 10;       /* Value Type */
            /* Displays
             * 9
             * Int32;
             * 9
             */
            Console.WriteLine(y);
            Console.WriteLine(y.GetType());
            Console.WriteLine(y.ToString());
            x = (int)y;
            /* Displays
             * 9
             * Int32;
             * 9
             */
            Console.WriteLine(x);
            Console.WriteLine(x.GetType());
            Console.WriteLine(x.ToString());


        }
        static void CastExamples()
        {
            /*
             * Casting is when you want to provide an Explicit Conversion (versus Implicit) conversion
             * from one type to another.  Explicit casting will throw an execption if it can't be of the
             * type being cast.
             * 
             * Blind casting - Casts without first confirming that the cast will be valid.
             * Using 'AS' keyword is defined as a safe cast.  If the cast fails it will not throw
             * an exception rather it will assign a null value.  You must then check for that null value.
             * 
             * AS Operator - Way of checking value.
             * You can use the 'AS' operator to
             * perform certain types of conversions between compatible reference types or nullable types
             * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/as
             * 
             * Example
             * Button button = sender as Button;
             * if (button!= null)
             * {
             *    button.text = "Processing..";
             * }
             * 
             * **************************************************************************************************
             * Arrays are reference types
             * Array CoVariance - You can implicitly cast a Derive[] to a Base[] type
                Example - Base Type is object and Derived Type is String
                Array CoVariance is broken because you cannot determine type, so you should
                not use.

                Broken array covariance - Writing Array Example
                Apple[] apples = new Apple[]
                {
                  new Jonagold(),
                  new Gala(),
                  new Fuji()
                }
                Fruits[] fuits = apples;
                fruit[1] - new Pineapple();
                apples[1].Peel();     <---- Points to a pineapple, therefore array covariance is broken, not a type safe operation

                Good Array Covariance - Reading Array Example
                IEnumerable<Apple> apples = ...;
                IEnumerable<Fruit> fruits;
                fruits = apples;      <---- Safe to read
                
               For arrays
                  * CoVariance is safe for reading
                  * ArrayTypeMismatch Exception upon writing
                  * This is why the 'out' keyword is used in IEnumerable
                   
                  
               See IEnumeratorInterfaces.cs for more information about IEnumerable
               IEnumerable<T> and IEnumerator<T> use CoVariance and are good to use unlike 
               Array CoVariance.
     
                You can always cast a derived type to a base type
                string is derived from object
                string str = "Hello world"
                object obj = str;
    
               However.  You cannot normally cast a collection of a derived type to a collection of a base type
               One exception is arrays, this will work for arrays.  This is called Array CoVariance.
               Below not allowed    
               var strList = new List<string> {"Monday","Tuesday"};
               List<object> objList = strList;
    
               CoVariance is safe for enumerators because an enumerator can't modify the collection
               The below will work.  Micorosft allows for the IEnumerable<T> and IEnumerator<T> interfaces.
               var strList = new List<string> {"Monday", "Tuesday" };
               IEnumerable<object> objEnum = strList;
    
               If you go to the definition of IEnumerable
               The 'out' keyword is what tells the compiler that the Interface can be treated as Covariant.
               The 'out' keyword lets you know it can't be modified
    
               Covariant because T is used with 'out' keyword.  Making it readable (not writeable)
                ...public interface IEnumerable<out T> : IEnumerable
               {
                 ...IEnumerator<T> GetEnumerator();
               }
               interface IEnumerator<out T>
               {
                  bool MoveNext();
                  T Current { get; }
               }
             * 
             */
        }
        static void ConvertTypes()
        {
            /*
             * You can convert a string to a number by using methods in the 'Convert' class or by using the 'TryParse'
             * method found on various numeric types(int, long, float,etc).
             * 
             * If you have a string, it is slightly more effecient and straightforward to call a 'TryParse' method.
             * Using 'Convert' method is more useful for general objects that implement IConvertible.
             * 
             * You can use 'Parse' or 'TryParse' methods on numeric types you expect the string contains, such as
             * System.Int32 type.  The Convert.ToUInt32 method uses 'Parse' internally.  If the string is not a valid
             * format, 'Parse' throws an exception whereas 'TryParse' returns false.
             * 
             * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
             *  
             */
            double dNumber = 23.15;
            try
            {
                // Returns 23
                int iNumber = System.Convert.ToInt32(dNumber);
                Console.WriteLine(" Converted double {0} to integer {1}", dNumber, iNumber);
            }
            catch(System.OverflowException)
            {
                Console.WriteLine("Overflow in double to int conversion");
            }
        }

        static void TryParseExamples()
        {
            /*
             * public static bool TryParse(string s, out in result)
             * s- A string containing a number to convert
             * result - returns the 32bit signed integer value equivalent of the number contained in string s
             * Return value - true if s was converted successfully; otherwise false
             * 
             * Remarks - TryParse method is like the Parse method, except the TryParse method does not throw
             * an exception if the conversion fails.
             */
            string s = "10";
            string n = "a";
            int result;
            if (int.TryParse(s,out result))
            {
               Console.WriteLine("Try Parse returns true - successfull converted string to integer {0}", result);
            }
            else
            {
                Console.WriteLine("Try Parse returns false - {0}", result);
            }
            if (int.TryParse(n, out result))
            {
                Console.WriteLine("Try Parse returns true - successfull converted string to integer {0}", result);
            }
            else
            {
                Console.WriteLine("Try Parse returns false - {0}", result);
            }
        }
    }
}
