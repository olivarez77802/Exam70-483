using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483.MenuImplementDataAccess
{
    class ImplementDataAccess
    {
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Implement Data Access \n ");
                Console.WriteLine(" 0.  Perform I/O Operations  - Read and write files and streams;\r ");
                Console.WriteLine("     read and write from the network by using classes in the  \r ");
                Console.WriteLine("     System.Net namespace; implement asynchronous I/O operations \r");
                Console.WriteLine(" 1.  Consume Data \r ");
                Console.WriteLine("     Retrieve data from a database; update data in a database; consume JSON \r");
                Console.WriteLine("     and XML data; retrieve data by using web services \r");
                Console.WriteLine(" 2.  Query and Manipulate data and Objects using LINQ \r ");
                Console.WriteLine("     Query data by using operators, including projection, join, group \r");
                Console.WriteLine("     take, skip, aggregate; create method based LINQ Queries \r");
                Console.WriteLine("     query data by using query comprehension syntax; select data by using \r");
                Console.WriteLine("     anonymous types; force execution of a query; read, filter, create, and \r");
                Console.WriteLine("     modify data structures by using LINQ to XML \r");
                Console.WriteLine(" 3.  Serialize and Deserialize Data  \r ");
                Console.WriteLine("     Serialize and deserialize data by using binary serialization; custom \r");
                Console.WriteLine("     serialization, XML Serializer, JSON Serializer, and Data Contract \r");
                Console.WriteLine("     Serializer");
                Console.WriteLine(" 4.  Store Data and Retrieve Data from Collections \r ");
                Console.WriteLine("     Store and retrieve data by using dictionaries, arrays, lists, sets, \r");
                Console.WriteLine("     and queues; choose a collection type; initialize a collection; add items \r");
                Console.WriteLine("     and remove items from a collection; use typed vs. non-typed collections; \r");
                Console.WriteLine("     implement custom collections; implement collection interfaces \r");
                Console.WriteLine(" 9.  Quit            \r\r ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: PerformIOoperations.Menu();
                           break;
                    case 1:
                        ConsumeData.Menu();
                        break;
                    case 2:
                        QueryLINQ.Menu();
                        break;
                    case 3: SerializeAndDeSerialize.Menu();
                        Console.ReadKey();
                        break;
                    case 4: Collections.Menu();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;

                }


            } while (x < 9);
        }
    }
}
