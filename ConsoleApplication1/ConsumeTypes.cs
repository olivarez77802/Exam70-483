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
           /* Boxing is the act of converting a VALUE type instance to a REFERENCE type
              instance.   
            
               int x = 9;
               object = x;   -  box the int
           
               Unboxing casts the object back to the VALUE type
            
               int y = (int)obj; 
               unbox the int
           */
        }
        static void CastExamples()
        {
            /*
             * Casting is when you want to provide an Explicit Conversion (versus Impllicit) conversion
             * from one type to another.  Explicit casting will throw an execption if it can't be of the
             * type being cast.
             * 
             * Blind casting - Casts without first confirming that the cast will be valid.
             * Using 'AS' keyword is defined as a safe cast.  If the cast fails it will not throw
             * an exception rather it will assign a null value.  You must then check for that null value.
             * 
             * AS Operator - Way of checking value.
             * 
             * Example
             * Button button = sender as Button;
             * if (button!= null)
             * {
             *    button.text = "Processing..";
             * }
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
