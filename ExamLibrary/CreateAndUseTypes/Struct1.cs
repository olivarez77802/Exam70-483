using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace ExamLibrary.CreateAndUseTypes
namespace Exam70483
{
    //class Struct1
    //{
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
        //public static class TestClassAndStruct
        public static class Struct1
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
    }
//}
