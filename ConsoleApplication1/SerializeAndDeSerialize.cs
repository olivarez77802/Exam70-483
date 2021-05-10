
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exam70483
{
    class SerializeAndDeSerialize
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Serialize and DeSerialize data \n ");
                Console.WriteLine("   Serialize and DeSerialize data by using binary serialization, \n ");
                Console.WriteLine("   custom serialization, XML Serialization, JSON Serializer, and \n ");
                Console.WriteLine("   Data Contract Serializer \n\n ");
                Console.WriteLine(" 0.  JSON Serialization - DeSerialization \n ");
                Console.WriteLine(" 1.  XML Serialization - DeSerialization \n ");
                Console.WriteLine(" 2.  CSV Deserialization \n ");
                Console.WriteLine(" 3.  ...... \n ");
                Console.WriteLine(" 4.  ....  \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        JSONExamples.Menu();
                        Console.ReadKey();
                        break;
                    case 1:
                        XMLExamples.Menu();
                        Console.ReadKey();
                        break;
                    case 2:
                        CSVDeSerialization();
                        Console.ReadKey();
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
        } // End Menu
        class Car
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public int Salary { get; set; }
            public int DeptID { get; set; }

            internal static Car ParsetoCSV(string line)
            {
                var columns = line.Split(',');
                return new Car
                {
                    Id = int.Parse(columns[0]),
                    FirstName = columns[1],
                    LastName = columns[2],
                    Gender = columns[3],
                    Salary = int.Parse(columns[4]),
                    DeptID = int.Parse(columns[5])

                };
            }
        }
        static void CSVDeSerialization()
        {
            /* Very cool Anonymous Type!
             */
            var cars = ProcessFile(@"C:\Users\olivarez77802\OneDrive\Documents\Jesse\Test.csv");
            var query = cars.OrderByDescending(c => c.LastName)
                            .ThenBy(c => c.FirstName);
                            
            foreach (var car in query)
            {
                Console.WriteLine($"{car.LastName} , {car.FirstName} : {car.Salary}" );
            }
        }
        private static List<Car> ProcessFile(string path)
        {
            /* The .ToList() converts the below into a concrete List.  Without .ToList() it
             * return an IEnumerable each time
             */
            return
            File.ReadAllLines(path).Skip(1).Where(line => line.Length > 1).Select(Car.ParsetoCSV).ToList();
            
        }
    }
}
