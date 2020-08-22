using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483
{
    /*
     * Called by TypeSystem.cs
     */
    class ReferenceTypes
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                /* See also TypeSystem.cs for info on Reference Types
                 * 
                 * Reference Types can represent a non-existent value with a null reference.
                 * Value Types cannot represent null values.
                 * 
                 *  string s = null;    - ok, Nullable type
                 *  int i = null;       - Compile error, value type cannot be null
                 *  
                 *  Nullablity for value types introduced in C# 2.0
                 *    Nullable types - int?, double?, bool?, char?, int?
                      https://msdn.microsoft.com/en-us/library/2cf62fcy.aspx
                      Nullable<decimal> result = null     <--- Long form
                      decimal? result = null;             <--- Shorthand form

                      For an example of when you might use a nullable type, consider how an ordinary Boolean variable 
                      can have two values: true and false.There is no value that signifies "undefined".In many programming
                      applications, most notably database interactions, variables can occur in an undefined state.
                      For example, a field in a database may contain the values true or false, but it may also contain
                      no value at all. Similarly, reference types can be set to null to indicate that they are not initialized.
             
                      int? n = null;
            
                      int m1 = n;        // Will not compile.
                      int m2 = (int)n;   // Compiles, but will create an exception if n is null.
                      int m3 = n.Value;  // Compiles, but will create an exception if n is null.

                      Customer customer = null;  <--- An instance of a class can return null, since class is a reference type

                      List<Customer> customerList = null;  <-- List of classes can return null.

                      2 rules of thought on returning NULLS from methods.  
                         1.  Don't do it.  Retuning nulls always requires the calling method to check the return value
                             for Nulls.  If there are any missed it increases the risk there will be a null exception thrown.
                         2.  Always return null anytime the return value is nothing.  So if you are asking for Customers and
                             none are found then you want to return a null.
                    
                     See also Operaters.cs for
                     1. Null Conditional (Ternary) Operator ? :
                     2. Null Coalesce Operator ??
                         // Set y to the value of x if x is not NULL; otherwise
                         // if x==null, set y to -1
                         // int y = x ?? -1;

                 * 
                 * 
                 * Method Parameters
                 * Parameters pass by value
                 *    Reference Types pass a copy of the reference
                 *       So both the calling code and the method being called both will have pointers to the exact same object.
                 *    Value types pass a copy of the value
                 *    Value types are immutable  - methods used on a value type may create a new instance and may not change
                 *    the underlying value and that rule also applies to strings which behaves like a value type.
                 *    
                 *    Even though string is a reference type it behave very much like a value type
                 *    Example:
                 *    string name = "scott"
                 *    name.ToUpper();
                 *    Assert.AreEqual("SCOTT", name);     <-- Assert will fail this is because .ToUpper() creates a new string
                 *    
                 *    name = name.ToUpper();
                 *    Asssert.AreEqual("SCOTT", name);     <-- Assert will now pass
                 *    
                 */
                Console.Clear();
                Console.WriteLine(" Reference Types Menu \r ");
                Console.WriteLine(" object.Equals() evaluates to Reference Equality (unless overridden\n ");
                Console.WriteLine(" 0.  String and Collections \n ");
                Console.WriteLine(" 1.  Object \n ");
                Console.WriteLine(" 2.  Class  \n ");
                Console.WriteLine(" 3.  Array  \n ");
                Console.WriteLine(" 4.  Delegate \n ");
                Console.WriteLine(" 5.  Inteface \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: Collections.Menu();
                        break;
                    case 1:
                        EnumTest.EnumMain();
                        break;
                    case 3: Collections.Menu();
                        break;
                    case 4: ManageProgramFlow_3_2.Menu();
                        //Delegate.Menu();
                        break;
                    case 5: InterfacesMenu.Menu();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);
        }

    }
}
