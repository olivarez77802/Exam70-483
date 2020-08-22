using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483
{
    /*
     *  Called by Program.cs
     */
    public class CreateAndUseTypes : CUT_Methods
    {
       public static void Menu()
        {
            IMenu CUT = new CUT_Methods();

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Create and Use Types \n ");
                Console.WriteLine(" 0.  Create Types (Value-Reference) \n ");
                /* Create value types, including structs and enum; create reference types, constructors, 
                 * static variables, methods, classes, extension methods; create optional and named parameters;
                 * create indexed properties; create overloaded and overriden methods
                */
                Console.WriteLine(" 1.  Consume Types  \n ");
                /* Box or unbox to convert between value types; cast types; convert types; handle dynamic types;
                 * ensure interoperability with code that accesses COM APIs
                */
                Console.WriteLine(" 2.  Enforce Encapsulation \n ");
                /* Enforce encapsulation by using properties; enforce encapsulation by using accessors, including
                 * public, private, protected, and internal; enforce encapsulation by using explicit interface
                 * implementation
                 */
                Console.WriteLine(" 3.  Create and Implement a Class Hierarchy \n ");
                /* Design and implement an interface; inherit from a base class; create and implement classes
                 * on the IComparable, IEnumerable, IDisposable, and IUnknown Interfaces
                */
                Console.WriteLine(" 4.  Find,execute, and create types at run time using Reflection \n ");
                /* Find and apply attributes; read attributes; generate code at runtime by using CodeDom and
                 * Lambda expressions; use types from the System.Reflection namespace, including Assembly, 
                 * PropertyInfo, MethodInfo, Type.
                */
                Console.WriteLine(" 5.  Manage the object lifecycle \n ");
                /* Manage unmanaged resources; implement IDisposable, including interaction with finalization;
                 * manage IDisposable by using the  Using statement; manage finalization and garbage collection
                */
                Console.WriteLine(" 6.  Manipulate Strings \n");
                /* Manipulate strings by using the StringBuilder, StringWriter, and StringReader classes, search
                 * strings; enumerate string methods; format strings; use string interpolation
                */
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: CUT.MenuOpt0();
                            break;
                    case 1: CUT.MenuOpt1();
                            break;
                    case 2: CUT.MenuOpt2();
                            break;
                    case 3: CUT.MenuOpt3();
                            break;
                    case 4: CUT.MenuOpt4();
                        // RunTimeTypes.Menu();
                        break;
                    case 5: CUT.MenuOpt5();
                        // ManageObjectCycle.Menu();
                        break;
                                            
                    case 6: CUT.MenuOpt6();

                        //ManipulateStrings.Menu();
                        //Console.WriteLine("Equality");
                        //Console.ReadKey();
                        //StringEquality.SE_Main();
                        //Console.ReadKey();
                        
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
