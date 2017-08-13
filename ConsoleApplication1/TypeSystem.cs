using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Exam70483
{
    class TypeSystem
    {
        public static void Menu()
        {
            // Reference Types can represent a non-existent value with a null reference.
            // Value Types cannot represent null values.
            //
            //  string s = null;    - ok, Nullable type
            //  int i = null;       - Compile error, value type cannot be null
            //
            //  Boxing is the act of converting a VALUE type instance to a REFERENCE type
            //  instance.   
            //
            //       int x = 9;
            //       object = x;   -  box the int
            //
            //  Unboxing casts the object back to the VALUE type
            //
            //       int y = (int)obj;    // unbox the int
            //
            //  Nullable types - int?, double?, bool?, char?, int?
            //  https://msdn.microsoft.com/en-us/library/2cf62fcy.aspx
            //  For an example of when you might use a nullable type, consider how an ordinary Boolean variable 
            //  can have two values: true and false.There is no value that signifies "undefined".In many programming
            //  applications, most notably database interactions, variables can occur in an undefined state.
            //  For example, a field in a database may contain the values true or false, but it may also contain
            //  no value at all. Similarly, reference types can be set to null to indicate that they are not initialized.
            //
            //   int? n = null;
            //
            //   int m1 = n;        // Will not compile.
            //   int m2 = (int)n;   // Compiles, but will create an exception if n is null.
            //   int m3 = n.Value;  // Compiles, but will create an exception if n is null.
            //
            //


            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Create Types Menu \n ");
                Console.WriteLine(" 0.  Value Types \n ");
                Console.WriteLine(" 1.  Reference Types \n ");
                Console.WriteLine(" 2.  Boxing and Unboxing \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: ValueTypes.Menu();
                        break;
                    case 1: ReferenceTypes.Menu();
                        break;
                   
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }
                
            } while (x < 9);

        }

        static void EscapeCharacters()
        {
            Console.WriteLine(" Escape Characters is Empty ");
            Console.ReadKey();
        }
        
      
        
        static void ProgramFlow()
        {
            Console.WriteLine(" Program Flow is Empty ");
            Console.ReadKey();
        }
        static void StatementsExpressions()
        {

            Console.WriteLine(" StatementsExpressions is Empty ");
            Console.ReadKey();
        }
       
       
    }

}
