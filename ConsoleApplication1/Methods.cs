using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace Exam70483.App.App
{
    

    class Methods
    {
        private enum eMenu
        {
            ConstructorsandFinalizers,
            Overloading,
            Parameters,
            Pinvoke,
            UserDefinedConversions,
            EnumerableMethods,
            GetPropertyMethods,
            StringMethods,
            Eight,
            Quit
        }


        public static void Menu()
        {
            int x = 0;
            do
            {
                /*
                 *  Every method has zero or more parameters
                 *  * Use params keyword to accept a variable number of parameters 
                 */
                Console.Clear();
                Console.WriteLine(" Methods Menu \n ");
                Console.WriteLine(" 0.  Constructors and Finalizers \n ");
                Console.WriteLine(" 1.  Overloading \n ");
                Console.WriteLine(" 2.  Parameters and Extension Methods\n");
                Console.WriteLine(" 3.  Pinvoke \n");
                Console.WriteLine(" 4.  User Defined Conversions \n");
                Console.WriteLine(" 5.  Enumerable Methods (System.Linq Namespace\n");
                Console.WriteLine(" 6.  GetProperty Method \n");
                Console.WriteLine(" 7.  String Methods (System.Namespace String Class \n");
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

                    case eMenu.Pinvoke:
                        PreProcessing();
                        break;

                    case eMenu.EnumerableMethods:
                        EnumerableMethods.Menu();
                        Console.ReadKey();
                                     
                        break;

                    case eMenu.GetPropertyMethods:
                        MyTypeClass.MainMTC();
                        Console.ReadKey();
                        break;
                    case eMenu.StringMethods:
                        Process.Start("https://msdn.microsoft.com/en-us/library/system.string_methods(v=vs.110).aspx");
                        StringMethodExamples.SMEMain();
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
            TestClassAndStruct.TCAS_Main();
        }
        static void PreProcessing()
        {
            Console.WriteLine(" PreProcessing is Empty ");
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

        static void overloadingsub()
        {
            Box Box1 = new Box();
            Box Box2 = new Box();
            Box Box3 = new Box();
            double volume = 0.0;

            // box 1 Spefication
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
    }  // End Class Methods
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
    class TheClass
    {
        public string willIChange;
    }
    struct TheStruct
    {
        public string willIChange;
    }
    public static class TestClassAndStruct
    {
        static void ClassTaker(this TheClass c)
        {
            c.willIChange = "Changed";
        }
        static void StructTaker(this TheStruct s)
        {
            s.willIChange = "Changed";
        }
        public static void TCAS_Main()
        {
            TheClass testClass = new TheClass();
            TheStruct testStruct = new TheStruct();

            testClass.willIChange = "Not Changed";
            testStruct.willIChange = "Not Changed";
            
            // made extension methods
            // extension methods require class to be static and parameter to have 'this'
            //
            testClass.ClassTaker();
            testStruct.StructTaker();
            
            // Could also call it this way, however extension methods is preferrred
            //ClassTaker(testClass);
            //StructTaker(testStruct);

            Console.WriteLine("Class field = {0}", testClass.willIChange);
            Console.WriteLine("Struct field = {0}", testStruct.willIChange);

            Console.WriteLine(" Press any key to exit");
            Console.ReadKey();

        }
    }

}  // End Namespace
