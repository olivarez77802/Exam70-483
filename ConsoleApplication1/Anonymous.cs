using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    /* 
     * Anonymous Methods and Types
     * See Also:
     * EnumerableMethods.cs
     * MPF3_1_Methods.cs
     * GenericExamples.cs
     * 
     * Anonymous Types
     * https://www.tutorialsteacher.com/csharp/csharp-anonymous-type
     * 
     * Anonymous type, as the name suggests, is a type that doesn't have any name. C# allows you to create an object 
     * with the new keyword without defining its class. The implicitly typed variable- var is used to hold the reference
     * of anonymous types.
       Example: Anonymous Type
         var myAnonymousType = new { firstProperty = "First", 
                                     secondProperty = 2, 
                                     thirdProperty = true 
                                   };
       Points to Remember :
         Anonymous type can be defined using the new keyword and object initializer syntax.
         The implicitly typed variable- var, is used to hold an anonymous type.
         Anonymous type is a reference type and all the properties are read-only.
         The scope of an anonymous type is local to the method where it is defined.
     *
     Example of Anonymous type  - new keyword defines Anonmyous type
     Anonymous type are great for defining types on the fly that can be used for processing or binding scenarios but these types
               are only useful in the method they are declared - don't try to pass anonymous types from a function. 
     dynamic - allows you bypass compile time type checking allowing you to return an anonymous type.
         However if we called this method and got back the dynamic there would be no way to convert back to our query so it is not recommended technique
     The recommened use of dynamic types is to add this code where you need it, for example you can put this code to the UI Layer and bind directly to the
     results of the query.

     public dynamic GetNamesandEmail(List<Customer> customerList)
     {
        var query = customerList.Select(c => new
        {
            Name = c.LastName + ", " + c.FirstName,
            c.EmailAddress
        });
        return query;

     } 

     Anonymous Methods introduced in C# 2.0
     https://www.tutorialsteacher.com/csharp/csharp-anonymous-method

     As the name suggests, an anonymous method is a method without a name. Anonymous methods in C# 
     can be defined using the delegate keyword and can be assigned to a variable of delegate type.
     Points to Remember :
       Anonymous method can be defined using the delegate keyword
       Anonymous method must be assigned to a delegate.
       Anonymous method can access outer variables or functions.
       Anonymous method can be passed as a parameter.
       Anonymous method can be used as event handlers.

    Anonymous Methods and Lambda Expressions
    https://www.c-sharpcorner.com/article/anonymous-methods-and-lambda-expressions-in-c-sharp/

   Anonymous Methods were developed in C# 2.0.   Anonymous syntax is a bit
   harder to write and manage.  In C# 3.0 Lambda expressions are introduced, it provides a simple,
   more concise syntax to write lambda methods.
    
    See also NamedMethods - Anonymous methods replaced Named Methods.   Lambda Expressions (C# 3.0) are 
    better alternative to anonymous methods (C# 2.0).
    https://www.tutorialspoint.com/csharp/csharp_anonymous_methods.htm

    */

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int age { get; set; }
    }
    class Anonymous
    {
        public delegate void Print(int value);

        public static List<Student> studentList = new List<Student>() {
                        new Student() { StudentID = 1, StudentName = "John", age = 18 } ,
                        new Student() { StudentID = 2, StudentName = "Steve",  age = 21 } ,
                        new Student() { StudentID = 3, StudentName = "Bill",  age = 18 } ,
                        new Student() { StudentID = 4, StudentName = "Ram" , age = 20  } ,
                        new Student() { StudentID = 5, StudentName = "Ron" , age = 21 }
                    };
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Anonymous Menu \n ");
                Console.WriteLine(" 0.  Return Anonymous Types from LINQ Query \n ");
                Console.WriteLine(" 1.  Anonymous Method Ex1 \n ");
                Console.WriteLine(" 2.  Anonymous Method as a Parameter \n");
                Console.WriteLine(" 3.  Anonymous Method Ex2 \n");
                Console.WriteLine(" 4.  \n");
                Console.WriteLine(" 5.  ... \n");
                Console.WriteLine(" 6.  ... \n");
                Console.WriteLine(" 7.  ... \n");
                Console.WriteLine(" 9.  Quit   \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: AnonymousType1();
                        Console.ReadLine();
                        break;
                    case 1: AnonymousMethod1();
                        Console.ReadLine();
                        break;
                    case 2:
                        /* Anonymous Method as a paramter.  Calls a method whose input parameter is a (delegate) and (int value)
                         * public static void PrintHelperMethod(Print printDel, int val)
                        */
                        PrintHelperMethod(delegate (int val) { Console.WriteLine("Anonymous method: {0}", val); }, 200);
                        Console.ReadLine();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        } // End Menu()
        static void AnonymousType1()
        {
            /* Anonymous Types allow you to cut down on the column list, the number
             * of columns may be in the 100's, anonymous types let you trim so that
             * you only work with what you need.   Anonymous types are also beneficial when
             * you use the Linq join operator and have data from two tables that you want
             * to show, anonymous types allow you to combine for one neat result.  The below
             * is query syntax, Anonymous types can also be used with method syntax, in this 
             * case the select is not used just the new { } operator.  Anonymous types are 
             * sometimes described as projections.
             */
            var studentNames = from s in studentList
                               select new
                               {
                                   s.StudentID,
                                   s.StudentName
                                /*  Alternative syntax
                                   StudentID = s.StudentID,
                                   StudentName = s.StudentName
                                */
                               };

            foreach (var name in studentNames)
            {
                // Console.WriteLine("Student Names {0}", name);
                Console.WriteLine("ID {0} Name {1}", name.StudentID, name.StudentName);
            }
        }
        static void AnonymousMethod1()
        {
            Print print = delegate (int val)
            {
                Console.WriteLine("Inside Anonymous method. Value: {0}", val);
            };

            print(100);
        }

        public static void PrintHelperMethod(Print printDel, int val)
        {
            val += 10;
            printDel(val);
        }
        static void AnonymousMethod2()
        {
            /* Find takes a predicate.  Using the anonymous method which is preceded by the delegate keyword.
            */
            Student student = studentList.Find(
                delegate (Student stud)
                {
                    return stud.StudentID == 3;
                }
                );
            if (student!=null)
            {
                Console.WriteLine("ID={0}, Name={1}", student.StudentID, student.StudentName);
            }
        }
    }
    
}
