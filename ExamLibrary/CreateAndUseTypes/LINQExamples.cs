using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Exam70483
{


    /*
     * See also EnumerableMethods.cs for more information about LINQ.
     * 
     * LINQ: Query Syntax versus Method Syntax
     * 
     * Query Syntax always start with 'from'.  Query ends with 'select' or 'group'
     * Query Syntax Examples:
     * var qNames = from name in listOfNames where name.Length <= 8 select name;
     * 
     * Method Syntax Examples:
     * var mNames = listOfNames.Where(name => name.Length <= 8);
     * 
     * Note! - Method Syntax uses Lambda Expressions (see Lambda.cs).  Extension methods are also 
     * reliant on Extension methods.   The Extension methods do not require you to supply a value.
     * Extension methods can extend any type this includes interfaces, class, sealed class (like string),
     * object type (in this case extension method would be available everywhere).  You can extend an 
     * instance method on an object, e.g. cannot replace an object method named .ToString() since every
     * object already has this method.  The namespace is important with extension methods since he can
     * either add or take away the methods that are available.
     * 
     * https://csharp.net-tutorials.com/linq/linq-query-syntax-vs-method-syntax/
     * 
     * 
     * 
     * LINQ can use any type of IEnumerable or IEnumerable<T> as a datasource
     * 
     LINQ Operators categories based on execution behavior, divided into 2 groups.
    
     1. Deferred or Lazy Operators - These query's use deferred executuion.
        Examples - select, where, Take, Orderby, Skip, etc.
     2. Immediate or Greedy Operators - These query operators use immediate execution.
        Examples - count, average, min, max, ToList, etc.

     Classification of Standard Query Operators by Manner of Execution
     https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/classification-of-standard-query-operators-by-manner-of-execution
     It may be best to use the greed operator ToList to put the data in memory, rather than wait and use the deferred operators especially if this
     happens more than once.   This is especially true when using IQueryable or datasets that are stored in SQL. 
     
     IEnumerable - specifies that datasource it always an in memory.
     IQueryable -  specifies that Lamda statements are translated in expressions that query datasource via SQL.   
     See IQueryable in InterfacesMenu.cs.
    
     IEnumerable - A List, Array, Query implements IEnumerable.
     An IEnumerable Interface specifies that the underlying type implements IEnumerable
    
     Deferred Execution An important feature of most query operators is that they execute
     not when constructed, but when enumerated (in other words, when MoveNext is called on 
     its enumerator). 
    
    Deferred Execution.
    The entire LINQ part of C# is built around deferred execution.  Deferred execution can make
    things more effectient.  The yield keyword is what's powering deferred execution used in 
    LINQ and allows us to use in our code.

    See also how Deferred Execution is done with the Yield Statement (See IterationStatements.cs)
    https://www.kenneth-truyers.net/2016/05/12/yield-return-in-c/
    */

    public class LINQExamples
    {
        /* Example of a class within a class.   All classes within LINQExamples can use the private classes.
         * GetAllDepartment is an example of an accessor that needs to be made public within a private class.
         * Another class within LINQExamples can use the private classes and also access any public properties.
        */
        // Had to make Department public in order to use 'new XmlSerializer(typeof(List<Department>));'
        public class Department
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public static List<Department> GetAllDepartments()
            {
                return new List<Department>
                   {
                       new Department { ID = 1, Name = "IT"},
                       new Department { ID = 2, Name = "HR"},
                       new Department { ID = 3, Name = "Payroll"},
                   };
            }
            // public var XML = new XmlSerializer(typeof(List<Department>));
            //public string JsonSerializedDept = JsonConvert.SerializeObject(GetAllDepartments());

        }

        private class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int DepartmentID { get; set; }
            public static List<Employee> GetAllEmployees()
            {
                return new List<Employee>()
               {
                   new Employee {ID = 1, Name = "Mark", DepartmentID = 1},
                   new Employee {ID = 2, Name = "Steve", DepartmentID = 2},
                    new Employee {ID = 3, Name = "Steve", DepartmentID = 1},
                    new Employee {ID = 4, Name = "Philip", DepartmentID = 1},
                   new Employee {ID = 5, Name = "Mary", DepartmentID = 2},
                    new Employee {ID = 6, Name = "Valarie", DepartmentID = 2},
                    new Employee {ID = 7, Name = "John", DepartmentID = 1},
                    new Employee {ID = 8, Name = "Pam", DepartmentID = 1},
                   new Employee {ID = 9, Name = "Staley", DepartmentID = 2},
                    new Employee {ID = 10, Name = "Andy"}
               };

            }


        }
        private class Hometown
        {
            public string City { get; set; }
            public string State { get; set; }
            public string CityCode { get; set; }

            public static List<Hometown> GetHometown()
            {
                return new List<Hometown>()
                {
                   new Hometown()
                   {
                       City = "Haverton",
                       State = "PA",
                       CityCode = "1234"
                   },
                   new Hometown
                   {
                       City = "Ewing",
                       State = "NJ",
                       CityCode = "5678"
                   },
                   new Hometown
                   {
                       City = "Fort Washington",
                       State = "PA",
                       CityCode = "9012"
                   }

              };  // End List
            } //End GetHometown
        }
        private class Employ
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }
            public string State { get; set; }

            public static List<Employ> GetAllEmploy()
            {

                return new List<Employ>()
                {
                  new Employ()
                  {
                   FirstName = "John",
                   LastName = "Smith",
                   City = "Haverton",
                   State = "PA"
                  },
                  new Employ()
                  {
                   FirstName = "Jane",
                   LastName = "Doe",
                   City = "Ewing",
                   State = "NJ"
                  },
                 new Employ()
                 {
                   FirstName = "Jack",
                   LastName = "Jones",
                   City = "Fort Washington",
                   State = "PA"
                 },
              };

            } // End GetAllEmploy


        }  // End Class Employ

        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" 0.  LINQ Add to Array before Deferred Execution ");
                Console.WriteLine(" 1.  LINQ Deferred versus Immediate Execution ");
                Console.WriteLine(" 2.  LINQ Projection - Query Syntax ");
                Console.WriteLine(" 3.  LINQ Query Syntax ");
                Console.WriteLine(" 4.  LINQ Comprehension - Query Syntax");
                Console.WriteLine(" 5.  Deferred Execution of LINQ Query using yield return");
                Console.WriteLine(" 6.  ... ");
                Console.WriteLine(" 7.  ... ");
                Console.WriteLine(" 8.  Serialize/DeSerialize Class Department");
                Console.WriteLine(" 9.  Quit            \n\n ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        LQDeferred_Exec();
                        break;
                    case 1:
                        LQDeferred_Exec2();
                        break;
                    case 2:
                        LQProjection();
                        break;
                    case 3:
                        LQ_QuerySyntax2();
                        break;
                    case 4:
                        LQComprehensionQuery();
                        Console.ReadKey();
                        break;
                    case 5:
                        Deferred_Exec_using_yield();
                        Console.ReadKey();
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        Serialize_DeSerialize_Class_Department();
                        Console.ReadKey();
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

        #region LQDeferredExec 
        private static void LQDeferred_Exec()
        {
            Tuple<int, int>[] tuples = new Tuple<int, int>[4];
            tuples[0] = new Tuple<int, int>(3, 6);
            tuples[1] = new Tuple<int, int>(6, 4);
            tuples[2] = new Tuple<int, int>(0, 60);

            // Order by descending on Item1
            var result = tuples.OrderByDescending(a => a.Item1);
            //* we can add here, because of deferrred execution
            tuples[3] = new Tuple<int, int>(4, 65);
            Console.WriteLine("Example of deferred Excution");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        #endregion
        #region LQDeferred_Exec2
        private static void LQDeferred_Exec2()
        {
            int[] myArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Deferred
            var evenNumbers = from i in myArray
                              where i % 2 == 0
                              select i;

            // Immediate because of .ToList
            List<int> evenNumberNOW = (from i in myArray
                                       where i % 2 == 0
                                       select i).ToList();

            foreach (int i in evenNumbers)
            {
                Console.WriteLine(" i is {0}", i);
            }
            Console.WriteLine("Second foreach myArray[1] = 12");
            myArray[1] = 12;
            foreach (int i in evenNumbers)
            {
                Console.WriteLine(" i is {0}", i);
            }
            Console.WriteLine("Immediate Execution because of ToList() ");
            foreach (int i in evenNumberNOW)
            {
                Console.WriteLine(" i is {0}", i);
            }
            Console.ReadKey();
        }
        #endregion
        #region LQProjection

        private static void LQProjection()
        {
            var result = from e in Employee.GetAllEmployees()
                         join d in Department.GetAllDepartments()
                         on e.DepartmentID equals d.ID
                         select new
                         {
                             EmployeeName = e.Name,
                             DepartmentName = d.Name
                         };

            string SQLQuery = result.ToString();
            Console.WriteLine(SQLQuery);
            Console.ReadKey();

            foreach (var employee in result)
            {
                Console.WriteLine(employee.EmployeeName + "\t" +
                                  employee.DepartmentName);

            }
            Console.ReadKey();

        }
        #endregion
        #region LQMethod 

        private static void LQ_QuerySyntax2()
        {
            var result = from e in Employee.GetAllEmployees()
                         join d in Department.GetAllDepartments()
                         on e.DepartmentID equals d.ID into EGroup
                         from d in EGroup.DefaultIfEmpty()
                         select new
                         {
                             EmployeeName = e.Name,
                             DepartmentName = d == null ? "No Department" : d.Name
                         };



            foreach (var v in result)
            {
                Console.WriteLine(v.EmployeeName + "\t" +
                                  v.DepartmentName);

            }
            Console.ReadKey();

        }
        #endregion
        #region LQComprehensionQuery
        /* 
         * Comprehension Queries
         * https://learning.oreilly.com/library/view/linq-pocket-reference/9780596519247/ch01s03.html
         * 
         * C# provides a syntatic shortcut for writing LINQ queries, called query comprehension syntax,
         * or simply query syntax.
         * 
         * A comprehnsion query always starts with a 'from' clause and end with either a 'select or group'
         * clause.  The 'from' clause declares an iteration variable.   The compiler processes comprehension
         * queries by translating them to lambda syntax this is similar to what it does to the 'foreach' statements
         * translating them into calls to GetEnumerator and MoveNext.  This means anything you can write in 
         * comprehension syntax you can also write in lambda syntax.
         */

        private static void LQComprehensionQuery()
        {

            var employeeByState = from e in Employ.GetAllEmploy()
                                  join h in Hometown.GetHometown()
                                on new { City = e.City, State = e.State }
                                equals
                                new { City = h.City, State = h.State }
                                  select new { e.LastName, h.CityCode };
            foreach (var employee in employeeByState)
            {
                Console.WriteLine(employee.LastName + ", " + employee.CityCode);
            }

        } // End LQComprehensionQuery 
        #endregion
        private static void Serialize_DeSerialize_Class_Department()
        {
            Department SDept = new Department();
            Console.WriteLine("\n Serialize Class Dept into Raw Jason");
            string ExJsonSerialized = JsonConvert.SerializeObject(SDept);
            Console.WriteLine(ExJsonSerialized);
            string ExJsonSerializedList = JsonConvert.SerializeObject(Department.GetAllDepartments());
            Console.WriteLine(ExJsonSerializedList);
            Console.WriteLine("\n DeSerialize - Takes JSON Raw Text and List<Department>  ");
            List<Department> exJson = JsonConvert.DeserializeObject<List<Department>>(ExJsonSerializedList);
            foreach (var element in exJson)
            {
                System.Console.WriteLine("ID: {0} Name: {1}", element.ID, element.Name);
            }
            Console.ReadKey();

            Console.WriteLine("\n XML Serialization to Console");

            var XML = new XmlSerializer(typeof(List<Department>));
            XML.Serialize(Console.Out, Department.GetAllDepartments());
            Console.ReadKey();
            Console.WriteLine("\n XML Serialzation to String Variable");
            /*
             * XML - Serialize and Assign to string variable 
            */
            StringWriter sw = new StringWriter();
            XML.Serialize(sw, Department.GetAllDepartments());
            string result = sw.ToString();
            Console.WriteLine("XML to variable result {0}", result);
            /*
             * DeSerialize XML
             */
            Console.ReadKey();
            Console.WriteLine("\n DeSerialize- Takes XML and loads to object Department.GetAllDepartments() ");
            StringReader stringReader = new StringReader(result);
            List<Department> Departments = (List<Department>)XML.Deserialize(stringReader);
            foreach (Department element in Departments)
            {
                System.Console.WriteLine("ID is: {0} Name is: {1} ", element.ID, element.Name);
            }
            Console.WriteLine("End of XML Serialization");


        }
        static void Deferred_Exec_using_yield()
        {
            IList<Student2> studentList = new List<Student2>()
            {
                new Student2() {StudentId = 1, StudentName = "John", age = 18 },
                new Student2() {StudentId = 2, StudentName = "Steve", age = 21 },
                new Student2() {StudentId = 3, StudentName = "Bill", age = 18 },
                new Student2() {StudentId = 4, StudentName = "Ram", age = 20 },
                new Student2() {StudentId = 5, StudentName = "Ron", age = 21 },
            };
            var teenAgerStudents = from s in studentList             // Query does not execute here..being deferred
                                   where s.age > 12 && s.age < 20
                                   select s;

            foreach (Student2 teenStudent in teenAgerStudents)
            {
                Console.WriteLine("Student Name: {0}", teenStudent.StudentName);
            }

            Console.WriteLine("Enumerate using yield return \n");

            /* yield return does the deferred work
             * The number of iterations in teenAgerStudents2 is controlled by the yield return statement
            https://www.tutorialsteacher.com/linq/linq-deferred-execution
            */
            var teenAgerStudents2 = from s in studentList.GetTeenAgerStudents() select s;
            
            foreach (Student2 teenStudent in teenAgerStudents2)

            {
                Console.WriteLine("Student Name: {0}", teenStudent.StudentName);
            }

             
        }
    } // End LINQExamples

    public static class EnumerableExtensionMethods
    {
        public static IEnumerable<Student2> GetTeenAgerStudents(this IEnumerable<Student2> source)
        {
            foreach (Student2 std in source)
            {
                Console.WriteLine("Accessing Student {0}", std.StudentName);
                if (std.age > 12 && std.age < 20)
                    yield return std;
            }
        }
    }
    public class Student2
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int age { get; set; }
   }
} //End Namespace
