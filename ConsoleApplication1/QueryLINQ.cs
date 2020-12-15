
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exam70483
{ 
    /*  See also LINQExamples.cs, EnumerableMethods.cs, QueryLINQ.cs for more info. on LINQ
    */
    class QueryLINQ
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Query and manipulate data and objects by using LINQ \n ");
                Console.WriteLine("    Query data by using operators, including projection, ");
                Console.WriteLine("    join, group, take, skip, aggregate; create method  ");
                Console.WriteLine("    based LINQ Queries; query data by using query comprehension");
                Console.WriteLine("    syntax; select data by using anonymous types; force ");
                Console.WriteLine("    execution of a query; read, filter, create and modify  ");
                Console.WriteLine("    data structures by using LINQ to XML.  ");
                Console.WriteLine(" 0.  LINQ Examples ");
                Console.WriteLine(" 1.  Anonymous Types ");
                Console.WriteLine(" 2.  LINQ to XML Save");
                Console.WriteLine(" 3.  Query XML using LINQ");
                Console.WriteLine(" 4.  ....");
                Console.WriteLine(" 5.  ... ");
                Console.WriteLine(" 6.  ... ");
                Console.WriteLine(" 7.  ... ");
                Console.WriteLine(" 8.  ....");
                Console.WriteLine(" 9.  Quit            \n\n ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        LINQExamples.Menu();
                        break;
                    case 1:
                        Anonymous.Menu();
                        break;
                    case 2:
                        LinqXML();
                        Console.ReadKey();
                        break;
                    case 3:
                        QueryXML();
                        Console.ReadKey();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
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
        static void LinqXML()
        {
            /* Alternative way would have been 
             XNamespace ns = "http://pluralsight.com/students/2020";
            */
            var ns = (XNamespace)"http://pluralsight.com/students/2020";
            /* Note! writes <Students xmlns="http://pluralsight.com/students/2020">
             * xmmlns is written after Students and not written for elemennt Student
            */
            var document = new XDocument();
            var students = new XElement(ns + "Students",
                           from s in Anonymous.studentList
                           select new XElement(ns + "Student",
                           new XAttribute("Id", s.StudentID),
                           new XAttribute("Name", s.StudentName),
                           new XAttribute("Age", s.age))
                           );
            document.Add(students);
            /*  Click on 'Show all Files' button open bin/Debug and you should see file stored 
             *  at this location.
            */
            document.Save("Students.xml");
            Console.WriteLine(" XML Students.xml saved to bin/debug");
            
        }
        static void QueryXML()
        {
            var ns = (XNamespace)"http://pluralsight.com/students/2020";
            var document = XDocument.Load("Students.xml");
            var query =
                from element in document.Element(ns + "Students").Elements(ns + "Student")
                    // where element.Attribute("Name").Value == "Bill"

                    /* Below will give you a null reference exception since we don't have Name2 in the file */
                    // where element.Attribute("Name2").Value == "Bill"
                    /* The ?. will allow you to get to the value property if the previous expression is not Null.
                     * If the Attribute Property is Null then the ?. will return Null, and not throw an exception.
                     */
                    // where element.Attribute("Name2")?.Value == "Bill"
                where element.Attribute("Name")?.Value == "Bill"
                select element.Attribute("Name").Value;

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }

    }
}
