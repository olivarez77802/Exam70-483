using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace Exam70483
{
    /* CreateAndUseTypes/CreateTypes/Methods.cs */

    class Methods
    {
        private enum eMenu
        {
            ConstructorsandFinalizers,
            Overloading,
            Parameters,
            dummy,
            UserDefinedConversions,
            EnumerableMethods,
            GetPropertyMethods,
            ClassVsStruct,
            Eight,
            Quit
        }
        #region Menu

        public static void Menu()
        {
            int x = 0;
            do
            {
                /*
                 *  Every method has zero or more parameters
                 *  Use params keyword to accept a variable number of parameters 
                 *  The params parameter must be the last parameter in a parameter list
                 *  The params keyworkd must be applied to an array modifiers.
                 *  The params parameter must always be the last modifier.
                 *  
                 *  Example
                 *  private void WriteDebug(string message, params object[] objects)
                 *  {
                 *     Debug.WriteLine(message);
                 *     foreach (var o in objects)
                 *     {
                 *       Debug.WriteLine(o);
                 *     }
                 *     
                 *  }
                 *  
                 */
                Console.Clear();
                Console.WriteLine(" Methods Menu \n ");
                Console.WriteLine(" 0.  Constructors and Finalizers \n ");
                Console.WriteLine(" 1.  Overloading \n ");
                Console.WriteLine(" 2.  Parameters and Extension Methods\n");
                Console.WriteLine(" 3.  ... \n");
                Console.WriteLine(" 4.  User Defined Conversions \n");
                Console.WriteLine(" 5.  ....");
                Console.WriteLine(" 6.  GetProperty Method \n");
                Console.WriteLine(" 7.  Class versus Struct \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");

                eMenu selection = (eMenu)(Common.readInt("Enter Number to Execute Routine : ", 0, 9));
                switch (selection)
                {
                    case eMenu.ConstructorsandFinalizers:
                        ConstructorsFinalizers();
                        break;

                    case eMenu.Overloading:
                        overloadingsub();
                        break;

                    case eMenu.Parameters:
                        Parameters();
                        break;

                    //case eMenu.Pinvoke:
                    //    PreProcessing();
                    //    break;

                    //case eMenu.EnumerableMethods:
                    //    EnumerableMethods.Menu();
                    //    Console.ReadKey();
                                     
                    //    break;

                    case eMenu.GetPropertyMethods:
                        MyTypeClass.MainMTC();
                        Console.ReadKey();
                        break;
                    case eMenu.ClassVsStruct:
                        // TestClassAndStruct.TCAS_Main();
                        Struct1.Menu();
                        Console.ReadKey();
                        break;
                    case eMenu.Quit:
                        x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);

        }  // End Menu
        #endregion
        #region Methods
        static void ConstructorsFinalizers()
        {
            Console.WriteLine(" ConstructorsFinalizers is Empty ");
            Console.ReadKey();
        }
        static void KeyWordsLiterals()
        {
            Console.WriteLine(" KeyWords Literals is Empty ");
            Console.ReadKey();
        }
        static void Parameters()
        {
            Console.Clear();
            // Console.WriteLine(" See Web Site http://msdn.microsoft.com/en-us/library/ty67wk28.aspx ");
            // Process.Start("http://msdn.microsoft.com/en-us/library/ty67wk28.aspx");
            Process.Start("https://msdn.microsoft.com/en-us/library/0f66670z.aspx");
            Console.ReadKey();
            
        }
        //static void PreProcessing()
        //{
        //    Console.WriteLine(" PreProcessing is Empty ");
        //    Console.ReadKey();
        //}



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

        static void overloadingsub()
        {
            Box Box1 = new Box();
            Box Box2 = new Box();
            Box Box3 = new Box();
            double volume = 0.0;

            // box 1 Specification
            Box1.setLength(6.0);
            Box1.setBreadth(7.0);
            Box1.setHeight(5.0);

            // Box 2 Specification
            Box2.setLength(12.0);
            Box2.setBreadth(13.0);
            Box2.setHeight(10.0);

            //volume of box 1
            volume = Box1.GetVolume();
            Console.WriteLine("Volume of Box1 : {0}", volume);

            //volume of box 2
            volume = Box2.GetVolume();
            Console.WriteLine("Volume of Box2: {0}", volume);

            //Add two object as follows
            Box3 = Box1 + Box2;

            // Volume of Box3
            volume = Box3.GetVolume();
            Console.WriteLine("Volume of Box3 : {0}", volume);
            Console.ReadKey();
        }
        #endregion
        #region Myclass
        class Myclass
        {
            private int myProperty;
            // Declare MyProperty.
            public int MyProperty
            {
                get
                {
                    return myProperty;
                }
                set
                {
                    myProperty = value;
                }
            }
        }
        #endregion
        #region MyTypeClass
        public class MyTypeClass
        {
            public static void MainMTC()
            {
                try
                {
                    // Get the Type object corresponding to MyClass
                    Type myType = typeof(Myclass);
                    // Get the PropertyInfo object by passing the property
                    PropertyInfo myPropInfo = myType.GetProperty("MyProperty");
                    // Display the property name.
                    Console.WriteLine("The {0} property exists in MyClass.", myPropInfo.Name);
                    Console.WriteLine(" Attributes are ", myPropInfo.Attributes);
                    Console.WriteLine(" Property Type is ", myPropInfo.PropertyType);
                    Console.WriteLine(" Can Read  ", myPropInfo.CanRead);
                    Console.WriteLine(" Declaring Type  ", myPropInfo.DeclaringType);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("The property does not exist in MyClass ", e.Message);
                }
            }
        }
        #endregion
        
    }  // End Class Methods
    
}  // End Namespace
