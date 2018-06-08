using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
   /*
    * Indexers helps us simplify how we access a collection from a class.
    * 
    * There are two things to remember about indexer:
    * 1.  Indexer is defined using 'this' keyword
    * 2.  Indexer is a property so we need to define the set and get for the same.
    * 
    * Most important goal of indexer is to simplify your interface..it's just syntactic sugar
    */
    public class Indexer
    {
        public static void Indexer_Main()
        {
            var stock = new Dictionary<string, int>()
            {
                {"jdays", 4 },
                {"technologyhour", 3 }

            };
            Console.WriteLine(string.Format("No of shirts in stock = {0} ", stock.Count));
            stock.Add("pluralsight", 6);
            stock["buddahistgeeks"] = 5;
            stock["pluralsight"] = 7;
            Console.WriteLine(string.Format("\r\nstock[pluralsight] = {0}", stock["pluralsight"]));

            stock.Remove("jdays");

            Console.WriteLine("\r\nEnumerating");
            foreach  (var keyValuePair in stock)
            {
                Console.WriteLine("{0}, {1}", keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}
