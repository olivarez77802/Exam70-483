using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JesseTesting.App
{
    // LINQ Operators categories based on execution behavior, divided into 2 groups.
    //
    // 1. Deferred or Lazy Operators - These query's use deferred executuion.
    //    Examples - select, where, Take, Skip, etc.
    // 2. Immediate or Greedy Operators - These query operators use immediate execution.
    //    Examples - count, average, min, max, ToList, etc.
    //
    // IEnumerable - A List, Array, Query implements IEnumerable.
    // An IEnumerable Interface specifies that the underlying type implements IEnumerable
    //
    // Deferred Execution An important feature of most query operators is that they execute
    // not when constructed, but when enumerated (in other words, when MoveNext is called on 
    // its enumerator). 
    //

    abstract class LINQExamples
    {
        private static void LQMain()
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

        private static void LQMain2()
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
        private class Department
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
        private static void LQMain3()
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


        private static void LQMain4()
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
        public static void Menu()
        {
            LINQExamples.LQMain();
            LINQExamples.LQMain_Composite_key();
            LINQExamples.LQMain2();
            LINQExamples.LQMain3();
            LINQExamples.LQMain4();
        }
        private class Hometown
        {
            public string City { get; set; }
            public string State { get; set; }
            public string CityCode { get; set; }
        }
        private class Employ
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }
            public string State { get; set; }

        }
        private static void LQMain_Composite_key()
        {
            List<Employ> employees = new List<Employ>()
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
            List<Hometown> hometowns = new List<Hometown>()

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

               };
            var employeeByState = from e in employees
                                  join h in hometowns
                                  on new { City = e.City, State = e.State }
                                  equals
                                  new { City = h.City, State = h.State }
                                  select new { e.LastName, h.CityCode };
            foreach (var employee in employeeByState)
            {
                Console.WriteLine(employee.LastName + ", " + employee.CityCode);
            }

        }
    }
}
