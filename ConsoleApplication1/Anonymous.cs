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

    */
    class Anonymous
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Anonymous Menu \n ");
                Console.WriteLine(" 0.  Return Anonymous Types from LINQ Query \n ");
                Console.WriteLine(" 1.   \n ");
                Console.WriteLine(" 2.  \n");
                Console.WriteLine(" 3.  \n");
                Console.WriteLine(" 4.   \n");
                Console.WriteLine(" 5.  ...  \n");
                Console.WriteLine(" 6.  ...  \n");
                Console.WriteLine(" 7.  ... \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: AnonymousType1();
                        Console.ReadLine();
                        break;
                    case 1:
                        break;
                    case 2:
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

        }
        static void AnonymousType1()
        {
            IList<Student> studentList = new List<Student>() {
                        new Student() { StudentID = 1, StudentName = "John", age = 18 } ,
                        new Student() { StudentID = 2, StudentName = "Steve",  age = 21 } ,
                        new Student() { StudentID = 3, StudentName = "Bill",  age = 18 } ,
                        new Student() { StudentID = 4, StudentName = "Ram" , age = 20  } ,
                        new Student() { StudentID = 5, StudentName = "Ron" , age = 21 }
                    };

            var studentNames = from s in studentList
                               select new
                               {
                                   StudentID = s.StudentID,
                                   StudentName = s.StudentName
                               };

            foreach (var name in studentNames)
            {
                Console.WriteLine("Student Names {0}", name);
                Console.WriteLine("ID {0} Name {1}", name.StudentID, name.StudentName);
            }
        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int age { get; set; }
    }
}
