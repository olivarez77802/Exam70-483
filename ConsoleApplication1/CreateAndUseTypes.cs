using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483
{
    /*
     *  Called by Program.cs
     */
    class CreateAndUseTypes
    {
       public static void CT_Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Create and Use Types \n ");
                Console.WriteLine(" 0.  Create Types (Value-Reference) \n ");
                Console.WriteLine(" 1.  Consume Types  \n ");
                Console.WriteLine(" 2.  Enforce Encapsulation \n ");
                Console.WriteLine(" 3.  Create and Implement a Class Heirarchy \n ");
                Console.WriteLine(" 4.  Find,execute, and create types at run time using Reflection \n ");
                Console.WriteLine(" 5.  Manage the object lifecycle \n ");
                Console.WriteLine(" 6.  Manipulate Strings \n");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        CreateTypes.Menu();
                        //TypeSystem.Menu();
                        break;
                    case 1: DynamicExamples.DMain();
                        break;
                    case 2: ClassesAndInterfaces.Menu();
                        break;
                    case 4: RunTimeTypes.Menu();
                        break;
                    case 5:
                        /*
                         * See also Static Types defined in DynamicExamples.cs
                         * Static Typing eliminates a large class of errors before a program
                         * is run.
                         * 
                         * Managed Language - CLR is the managed language for C#
                         * - Managed Languages depeend on services provided by runtime environmnet.
                         * - C# is one of many languages that compile into managed code
                         * - Managed code is executed by the Common Language Runtime (CLR).
                         * - The CLR provides features such as:
                         *    * Automatic memorary management
                         *    * Exception Handling
                         *    * Standard Types
                         *    * Security
                         *  
                         *    https://www.youtube.com/watch?v=JfNTD7bTscw
                         *    
                        */
                        break;
                    case 6: StringBuilderExamples.PrimaryMain();
                        Console.WriteLine("Equality");
                        Console.ReadKey();
                        StringEquality.SE_Main();
                        Console.ReadKey();
                        
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
