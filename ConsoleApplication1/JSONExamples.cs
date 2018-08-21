using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Reflection;

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
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" JSON - JavaScript Object Notation \n ");
                Console.WriteLine(" 0.  DisplayJSON \n ");
                Console.WriteLine(" 1.  DeSerialize Object \n");
                Console.WriteLine(" 2.  Serialize Object \n");
                Console.WriteLine(" 3.  Serialize Indented Object \n");
                Console.WriteLine(" 4.  Validate JSON against Schema");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        DisplayJSON();
                        Console.ReadKey();
                        break;
                    case 1:
                        DeSerializeObject();
                        Console.ReadKey();
                        break;
                    case 2:
                        SerializeObject();
                        Console.ReadKey();
                        break;
                    case 3:
                        SerializeIndentedObject();
                        break;
                    case 4:
                        ValidateJSONAgainstSchema();
                        Console.ReadKey();
                        break;
                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);  // end do

        }  // end Menu()



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
            string ExJsonSerializedIndented = JsonConvert.SerializeObject(ExJson, Formatting.Indented);
            Console.WriteLine(ExJsonSerializedIndented);
        }
        static void ValidateJSONAgainstSchema()
        {
            // https://stackoverflow.com/questions/19544183/validate-json-against-json-schema-c-sharp
            string json = "{Name:'blaha', ID:'1'}";
            /* 
             * The value passed is 'json' text
             */
            bool res = json.IsJsonValid<test>();
            Console.WriteLine("Passed validation {0} json string {1}", res,json);
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
    public class test
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public static class Test_Schema
    {
        /* Was originally TSchema change to T to show that it could be anything
         * and doesn't not have to be TSchema just creating an ordinary
         * generic class
         */
        // public static bool IsJsonValid<TSchema>(this string value)
        public static bool IsJsonValid<T>(this string value)
            where T : new()
        {
            bool res = true;
            //this is a .net object look for it in msdn
            JavaScriptSerializer ser = new JavaScriptSerializer();
            //first serialize the string to object.
            // T - is the Test class
            // value is the JSON text
            // Deserializing is loading JSON Text to object (or class Test)
            var obj = ser.Deserialize<T>(value);
            Console.WriteLine("obj is {0}", obj);
            Console.WriteLine("Deserialized - JSON Text loaded to object");

            //get all properties of schema object
            var properties = typeof(T).GetProperties();
            //iterate on all properties and test.
            foreach (PropertyInfo info in properties)
            {
                Console.WriteLine(" info.Name {0}", info.Name);
                // i went on if null value then json string isnt schema complient but you can do what ever test you like her.
                var valueOfProp = obj.GetType().GetProperty(info.Name).GetValue(obj, null);
                Console.WriteLine(" valueofProp {0}", valueOfProp);
                if (valueOfProp == null)
                    res = false;
            }

            return res;
        }
    }
}
