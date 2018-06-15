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
                /* 
                 * Method Parameters
                 * Parameters pass by value
                 *    Reference Types pass a copy of the reference
                 *       So both the calling code and the method being called both will have pointers to the exact same object.
                 *    Value types pass a copy of the value
                 *    Value types are immutable  - methods used on a value type may create a new instance and may not change the underlying value
                 *    and that rule also applies to strings which behaves like a value type.
                 *    
                 *    Even though string is a reference type it behave very much like a value type
                 *    Example:
                 *    string name = "scott"
                 *    name.ToUpper();
                 *    Assert.AreEqual("SCOTT", name);     <-- Assert will fail this is because .ToUpper() creates a new string
                 *    
                 *    name = name.ToUpper();
                 *    Assser.AreEqual("SCOTT", name);     <-- Assert will now pass
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
                    case 0: Collections.CollectionsMenu();
                        break;
                    case 1:
                        EnumTest.EnumMain();
                        break;
                    case 3: Collections.CollectionsMenu();
                        break;
                    case 4: Delegate.Menu();
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
