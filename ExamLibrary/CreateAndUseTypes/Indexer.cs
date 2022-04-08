using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483.ExamLibrary.CreateAndUseTypes
{
   /*
    * Create Types.
    * 
    * Indexers helps us simplify how we access a collection from a class.
    * 
    * There are two things to remember about indexer:
    * 1.  Indexer is defined using 'this' keyword
    * 2.  Just like properties indexers have get and set accessors
    * 3.  Indexers can also be overloaded
    * 
    * Most important goal of indexer is to simplify your interface..it's just syntactic sugar
    */
    public class Indexer
    {
        public static void Menu()
        {
            Console.WriteLine("Indexer using Dictionary");
            Indexer_using_Dictionary();

            // https://www.youtube.com/watch?v=km1hd9-dVz4&index=65&list=PLAC325451207E3105
            Console.WriteLine("Indexer using List and Properties");
            Indexer_using_Properties();


            Company company = new Company();
            Console.WriteLine("Name of Employee with Id = 2:" + company[2]);
            Console.WriteLine("Name of Employee with Id = 4:" + company[4]);
            Console.WriteLine("Name of Employee with Id = 6:" + company[6]);

            Console.WriteLine("Changing names of employees with Id = 2, 5, and 8");

            company[2] = "2nd Employee Name Changed";
            company[4] = "4th Employee Name Changed";
            company[6] = "6th Employee Name Changed";

            Console.WriteLine("Name of Employee with Id = 2:" + company[2]);
            Console.WriteLine("Name of Employee with Id = 4:" + company[4]);
            Console.WriteLine("Name of Employee with Id = 6:" + company[6]);
        }
        #region IndexerDictionary
        static void Indexer_using_Dictionary()
        {
            var stock = new Dictionary<string, int>()
            {
                {"jdays", 4 },
                {"technologyhour", 3 }

            };
            Console.WriteLine(string.Format("No of shirts in stock = {0} ", stock.Count));
            stock.Add("pluralsight", 6);
            stock["buddahistgeeks"] = 5;
            Console.WriteLine(string.Format("\r\nstock[buddahistgeeks] = {0}", stock["buddahistgeeks"]));
            stock["pluralsight"] = 7;
            Console.WriteLine(string.Format("\r\nstock[pluralsight] = {0}", stock["pluralsight"]));

            stock.Remove("jdays");

            Console.WriteLine("\r\nEnumerating");
            foreach  (var keyValuePair in stock)
            {
                Console.WriteLine("{0}, {1}", keyValuePair.Key, keyValuePair.Value);
            }
        }
        #endregion
        #region IndexerUsingList
        static void Indexer_using_Properties()
        {

        }
        class Employee
        {
            public int EmployeeId { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
        }
        class Company
        {
            private List<Employee> listEmployees;

            public Company()
            {
                listEmployees = new List<Employee>();
                listEmployees.Add(new Employee() { EmployeeId = 1, Name = "Mike", Gender = "Male" });
                listEmployees.Add(new Employee() { EmployeeId = 2, Name = "Pam", Gender = "Female" });
                listEmployees.Add(new Employee() { EmployeeId = 3, Name = "John", Gender = "Male" });
                listEmployees.Add(new Employee() { EmployeeId = 4, Name = "Maxine", Gender = "Female" });
                listEmployees.Add(new Employee() { EmployeeId = 5, Name = "Emily", Gender = "Female" });
                listEmployees.Add(new Employee() { EmployeeId = 6, Name = "Scott", Gender = "Male" });

            }

            public string this[int employeeId]
            {
                get
                {
                    return listEmployees.FirstOrDefault(emp => emp.EmployeeId == employeeId).Name;
                }
                set
                {
                    listEmployees.FirstOrDefault(emp => emp.EmployeeId == employeeId).Name = value;
                }
            }
            
        }
        #endregion
    }
}
