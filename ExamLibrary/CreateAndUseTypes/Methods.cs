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
                        TestClassAndStruct.TCAS_Main();
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
    #region TestClassAndStruct
    /* When to use a Struct versus a Class  
     * (See also StaticExamples.cs for comparison of Static versus Instance fields/methods).
     * (See also BaseExamples.cs)
     * (See also ValueTypes.cs)
     * 
     * 
      A struct type is a value type that is typically used to encapsulate small groups of related variables, 
      such as the coordinates of a rectangle or the characteristics of an item in an inventory.
      public struct Book
      {
        public decimal price;
        public string title;
        public string author;
       }
       Structs can also contain constructors, constants, fields, methods, properties, indexers, operators,
       events, and nested types, although if several such members are required, you should consider making
       your type a class instead.

    Structs are mainly useful to hold small data values. A structure can be defined using the struct operator.
    
    Structure Declaration
    A structure is declared using struct keyword with public or internal modifier. The default modifer is internal
    for the struct and its members. However, you can use private or protected modifier when declared inside a class.
    struct Employee
    {
    public int EmpId;
    public string FirstName;
    public string LastName;
    }
    
    A struct object can be created with or without the new operator, same as primitive type variables. When you create a
    struct object using the new operator, an appropriate constructor is called.
    Employee emp = new Employee();
    Console.Write(emp.EmpId); // prints 0
    
    In the above code, an object of the structure Employee is created using the new keyword. So, this calls the 
    default parameterless constructor that initializes all the members to their default value.
    When you create a structure object without using new keyword, it does not call any constructor and so all
    the members remain unassigned. So, you must assign values to each member before accessing them, otherwise it will 
    give a compile time error.
    
    Employee emp;
    Console.Write(emp.EmpId); // Compile time error  

    emp.EmpId = 1;
    Console.Write(emp.EmpId); // prints 1   
    
    A struct cannot contain parameterless constructor. It can only contain parameterized constructors or a static constructor.
    A struct can include static parameterless constructor and static fields.  Example of a static parameterless constructor 
    is below.  Note! Paramterless methods are allowed, differerent from a parameterless constructor.
    
   struct Employee
    {
    public int EmpId;
    public string FirstName;
    public string LastName;
    // Static parameterless constructor
    static Employee()
    {
        Console.Write("First object created");
    }

    public Employee(int empid, string fname, string lname)
    {
        EmpId = empid;
        FirstName = fname;
        LastName = lname;
    }
   }

   Employee emp1 = new Employee(10, "Bill", "Gates");
   Employee emp2 = new Employee(10, "Steve", "Jobs");    

    A struct is a value type so it is faster than a class object. Use struct whenever you want to just store the data. 
    Generally structs are good for game programming. However, it is easier to transfer a class object than a struct. 
    So do not use struct when you are passing data across the wire or to other classes.   
    
    Difference between Struct and Class:
      Class is reference type whereas struct is value type  
      Class has a default constructor, Struct Do Not have a default constructor  
      Struct cannot declare a default constructor or destructor. However, it can have parameterized constructors.
      Struct can be instasntiated without the new operator. However, you won't be able to use any of its methods, 
      events or properties if you do so.
      Struct cannot be used as a base or cannot derive another struct or class. 
      Structs cannot inherit from another struct or class.  They can implement and interface. 
      Struct using the new keyword is optional
      https://www.youtube.com/watch?v=G5KJolM2uzs

      In general, classes are used to model more complex behavior, or data that is intended to be modified
      after a class object is created. Structs are best suited for small data structures that contain primarily
      data that is not intended to be modified after the struct is created.
      https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/

      If you find your self using getter and setters, abstract and virtual method you 
      should probably use a class instead of struct
      http://geekswithblogs.net/BlackRabbitCoder/archive/2010/07/29/c-fundamentals-the-differences-between-struct-and-class.aspx
    
    DateTime.Now is an example of a struct.  DateTime is a struct and Now is a static type.
    https://www.dotnetperls.com/datetime-now
    https://www.tutorialsteacher.com/csharp/csharp-struct
    https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-structs
    https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct

    */
    class TheClass
    {
        public string willIChange;
    }
    struct TheStruct
    {
        // It is an error to initialize an instance field in a struct body.
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
            //Note!!! - Both class and struct use the 'new' keyword
            TheClass testClass = new TheClass();
            TheStruct testStruct = new TheStruct();

            /* Initialize both Class and Struct to 'Not Changed' */
            testClass.willIChange = "Not Changed";
            testStruct.willIChange = "Not Changed";

            /*
             Made extension methods
             Extension methods require class to be static and parameter to have 'this'
             Set both Class and Struct to 'Not Changed'
             
             
            */
            testClass.ClassTaker();
            //Struct is a value type and may create a new instance but will not change.
            testStruct.StructTaker();

            // Could also call it this way, however extension methods is preferrred
            // ClassTaker(testClass);
            // StructTaker(testStruct);
            //
            // Displays Class field "changed"
            //          Struct field "not changed"
            //
            Console.WriteLine("Class field = {0}", testClass.willIChange);
            Console.WriteLine("Struct field = {0}", testStruct.willIChange);

            
        }
    }
    #endregion
}  // End Namespace
