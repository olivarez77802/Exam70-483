using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Exam70483
{
    /*
     * Case for JSON
     *  - Binary Formats are cryptic
     *  - XML - Very Verbose
     *  - JSON - Fat Free Alternative to XML.  Natively supported by Web Applications.  Not natively supported by C#. Javascript
     *                                Natively supports JSON.  
     *           JSON takes developers out of syntax business.
     *           
     *   Install reference to Newtonsoft.Json  NuGet Package
     *   
     *   JSONLint - The JSON Validator
     *   https://jsonlint.com/
     *                                
     *   JSON - Java Script Object Notation.  Has a Key/ Value Pair.
     *   
     *   JSON data Types
     *   Number 
     *    "courses" : 5,
     *    "weight" : 205.5
     *    
     *   String
     *    "fullname" : "Jesse Alexander",
     *   
     *   Boolean
     *     "developer" : true
     *   
     *   Array
     *     "counts" : ["one", 2, "three", 4 ]
     *    
     *   Object
     *     "author" : {
     *          "firstName" : "Jesse",
     *          "lastName" : "Alex"
     *          } 
     *          
     *   null
     *      "healthydiet" : null,
     *      
     *   Whitespaces
     *     "spaces" :
     *     
     *    https://app.pluralsight.com/player?course=json-csharp-jsondotnet-getting-started&author=xavier-morera&name=json-csharp-jsondotnet-getting-started-m2&clip=2&mode=live
     */
    public class JSONExamples
    {
        public static string ExJson = @"{
                                'name': 'Jesse Alexander',
                                'courses' : [
                                   'Solr',
                                   'dotTrace'
                                   ],
                                'since' : '2014-01-14T00:00:00',
                                'happy' : true,
                                'issues' : null,
                                'car' : {
                                    'model': 'Land Rover',
                                    'year' : 1976
                                        },
                                'authorRelationship' : 1
                              }";
        public static void Menu()
        {
            DisplayJSON();
            DeSerializeObject();
            SerializeObject();
            SerializeIndentedObject();
        }
        static void DisplayJSON()
        {
            Console.Clear();
            Console.WriteLine("Step 1: Output JSON");
            Console.WriteLine(ExJson);
        }
        static void DeSerializeObject()
        {
            Console.WriteLine("\n Step 2.  DeSerialize - Takes JSON Raw Text and loads to Author Class ");
            Author exJson = JsonConvert.DeserializeObject<Author>(ExJson);
            Console.WriteLine(exJson.name);
        }
        static void SerializeObject()
        {
            Console.WriteLine("\n Step 3. Serialize - Take Author class and create Raw Jason");
            string ExJsonSerialized = JsonConvert.SerializeObject(ExJson);
            Console.WriteLine(ExJsonSerialized);
        }
        static void SerializeIndentedObject()
        {
            Console.WriteLine("\n Step 4. Serialize Indented Author class");
            string ExJsonSerializedIndented = JsonConvert.SerializeObject(ExJson,Formatting.Indented);
            Console.WriteLine(ExJsonSerializedIndented);
        }
    }
    public class Author
    {
        public string country;
        public int age;
        public string name { get; set; }
        public string[] courses { get; set; }
        public DateTime since { get; set; }
        public bool happy { get; set; }
        public object issues { get; set; }
        public Cars car { get; set; }
    }
    public class Cars
    {
        public string model { get; set; }
        public string year { get; set; }
    }
}
