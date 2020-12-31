using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam70483;

namespace ExamLibrary.CreateAndUseTypes
{
    public class EnforceEncapsulation
    {
        public static void Menu()
            {

                int x = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine(" Enforce Encapsulation\n ");
                    Console.WriteLine("   Enforce Encapsulation by using properties; Enforce \n ");
                    Console.WriteLine("   Encapsulation by using Accessors; including public, \n ");
                    Console.WriteLine("   private, protected, and internal, enforce encapsulation \n ");
                    Console.WriteLine("   by using explicit interface implementation. \n ");
                    Console.WriteLine(" 0.  Properties \n ");
                    Console.WriteLine(" 1.  Accessors  \n ");
                    Console.WriteLine(" 2.  Interface \n ");
                    Console.WriteLine(" 3.  Auto Implemented Properties \n");
                    Console.WriteLine(" 9.  Quit            \n\n ");
                    Console.Write(" Enter Number to execute Routine ");


                    int selection;
                    selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                    switch (selection)
                    {
                        case 0:
                           
                            Console.ReadKey();
                            break;

                        case 1:
                           
                            break;
                        case 2:
                           
                            Console.ReadKey();
                            break;
                        case 3:
                          
                            Console.ReadKey();
                            break;
                        case 4:

                            break;
                        case 5:
                            
                            Console.ReadKey();
                            break;

                        case 6:
                           
                            break;
                        case 9:
                            x = 9;
                            break;
                        default:
                            Console.WriteLine(" Invalid Number");
                            break;
                    }


                } while (x < 9);  // end do
            } // end
        static void Properties_info()
        {
            /* Why Properties
             * - Marking the class fields public and exposing to the external world is bad, as you will not have 
             *   control over what gets assigned and returned.  Properties allow you to put edits on fields.
             *   Programming languages that do not have properties use getter and setter methods to encapsulate
             *   and protect fields.  Getter and Setter methods were used before C# had properties.
             *   https://www.youtube.com/watch?v=uYXQH2QFmqk&list=PLAC325451207E3105&index=26
             * 
             */

        }
        static void Accessors_info()
        {
            /* Properties
             * - In C# to encapsulate and protect fields we use properties
             *   1. We use get and set accessors to implement properties
             *   2. A property with both get and set accessor is a Read/Write property
             *   3. A property with only get accessor is a Read Only property
             *   4. A property with only set accessor is a Write only property
             *   
             *   Note: The advantage of properties over traditional Get() and Set() methods is that
             *   you can access them as if they were public fields.
             *   
             *   A 'value' keyword can be used within the get and set accessor to get the 'value' being passed.
             *   Usually used in the 'set' accessor.  C# will know whether you are trying to either read or write
             *   and invoke the relative get or set accessor.
             *   
             *   https://www.youtube.com/watch?v=iGR425gMKeA&list=PLAC325451207E3105&index=27
             *   
             * 
             */

        }
        static void Auto_Implmented_Properites()
        {
            /* Auto Implemented Properites
             * - If there is no additional logic in the property accessors, then we can make use of 
             *   auto implemented introduced in C# 3.0
             * - Auto-implmented properties redude the amount of code that we have to write.
             *   When you use auto-implemented properties, the compiler creates a private,
             *   anonymous field that can be accessed through the property's get and set
             *   accessors.  So you still create the public field, but the private field will
             *   be created automatically in C# 3.0.   You still have to write the get and set
             *   on the pulic fields.  
             *   
             *   Example public string Email {get;set;} is same as
             *   
             *   private string _Email;
             *   public string Email
             *   set  
             *   {
             *     _Email = value;
             *   }
             *   get
             *   {
             *     return this._Email;
             *   }
             *   
             *   If there is no additional logic in the property accessors , then we can make use of auto 
             *   implemented properties introduced in C# 3.0.  Auto implemented properties reduce the 
             *   amount of code we have to write.  When you use the auto-implemented properies, the 
             *   compiler creates a private anonymous field that can be accessed through the property's
             *   get and set accessor.
             * 
             */
        }
    }
}
