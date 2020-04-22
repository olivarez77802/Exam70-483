using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;

namespace Exam70483
{
    /* 
     * Manage Program Flow / Implement Program Flow 
    */
    class IterationStatements
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Iteration Statements Menu \n ");
                Console.WriteLine(" 0.  Web Page ");
                Console.WriteLine(" 1.  Run foreach Example 1  ");
                Console.WriteLine(" 2.  Run Example 2 ");
                Console.WriteLine(" 3.  Run Example 3 ");
                Console.WriteLine(" 4.  Run Example 4 ");
                Console.WriteLine(" 5.  Statement Keywords ");
                Console.WriteLine(" 6.  While, do-while ");
                Console.WriteLine(" 7.  Prefix and Postfix Operator ");
                Console.WriteLine(" 8.  Yield Return");
                Console.WriteLine(" 9.  Quit  ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        WebPage();
                        break;
                    case 1:
                        foreach_1();
                        break;
                    case 2:
                        Operators();
                        break;
                    case 3:
                        PreProcessing();
                        break;
                    case 4:
                        ProgramFlow();
                        break;
                    case 5:
                        StatementKeywords();
                        break;
                    case 6:
                        WhiledoWhile();
                        break;
                    case 7:
                        Prefix_and_Postfix_Operator();
                        Console.ReadKey();
                        break;
                    case 8:
                        Yield_Return();
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

        static void WebPage()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/32dbftby.aspx");

        }
        static void foreach_1()
        {
            //** Examples of using foreach statement
            string_array();
            one_dim_array();
            two_dim_array();
            LINQ_Query();
            Key_Value_Pair();
            Dictionary_Key_Value_Pair();
            List_Remove();
          

            Program p = new Program();
            Console.WriteLine("Using Collections");
            Collections.Using_Collections();

        }
        public static void SerializeFibArray()
        {
            /*
             * This was just put in this module to get practice Serializing and Desearializing JSON and XML.
             * 
             * Notice prefix heading for JSON is not required, the output is simply
             * [0,1,1,2,3,5,8,13]  and not 'fib:[0,1,1,2,3,5,8,13]'
             *
             */
            int[] fibarray = new int[] { 0, 1, 1, 2, 3, 5, 8, 13 };
            Console.WriteLine("\n Serialize fib array into Raw Jason");
            string ExJsonSerialized = JsonConvert.SerializeObject(fibarray);
            Console.WriteLine(ExJsonSerialized);

            Console.WriteLine("\n DeSerialize - Takes JSON Raw Text and loads to array ");
            int[] exJson = JsonConvert.DeserializeObject<int[]>(ExJsonSerialized);
            foreach (int element in exJson)
            {
                System.Console.WriteLine(element);
            }
            /* 
             * XML Serialization
             * https://support.microsoft.com/en-us/help/815813/how-to-serialize-an-object-to-xml-by-using-visual-c
             */
            Console.WriteLine("XML Serialization");
            var XML = new XmlSerializer(typeof(int[]));
            XML.Serialize(Console.Out,fibarray);

            /*
             * XML - Assign to string variable 
            */
            StringWriter sw = new StringWriter();
            XML.Serialize(sw, fibarray);
            string result = sw.ToString();
            Console.WriteLine("XML to variable result {0}", result);
            /*
             * DeSerialize XML
             */
            Console.WriteLine("\n DeSerialize fibds - Takes XML and loads to object");
            StringReader stringReader = new StringReader(result);
            int[] fibds = (int[])XML.Deserialize(stringReader);
            foreach (int element in fibds)
            {
                System.Console.WriteLine(element);
            }
            Console.WriteLine("End of XML Serialization");

        }

        
        static void one_dim_array()
        {
            SerializeFibArray();
            Console.WriteLine("One Dimensional Array");
            /*
             * Three different ways of writing
             * 1. JSON using variable JSONFib
             * 2. Have JSON Embedded
             * 3. Use regular method.
            */
            // 1.
            // string JSONfib = "[0,1,1,2,3,5,8,13]";
            // int[] fibarray = JsonConvert.DeserializeObject<int[]>(JSONfib);
            // 2.
             int[] fibarray = JsonConvert.DeserializeObject<int[]>("[0,1,1,2,3,5,8,13]");
            // 3.
            // int[] fibarray = new int[] { 0, 1, 1, 2, 3, 5, 8, 13 };
            foreach (int element in fibarray)
            {
                System.Console.WriteLine(element);
            }
            System.Console.WriteLine();
            Console.ReadKey();
            // Compare the previous loop to a similar for loop
            for (int i = 0; i < fibarray.Length; i++)
            {
                System.Console.WriteLine(fibarray[i]);
            }
            Console.WriteLine();
            // You can maintain a count of the elements in the collection
            int count = 0;
            foreach (int element in fibarray)
            {
                count += 1;
                Console.WriteLine("Element #{0}: {1}", count, element);
            }
            System.Console.WriteLine("Number of Elements in the array: {0}", count);
            Console.ReadKey();
        }
        static void string_array()
        {
            Console.WriteLine(" String Array ");
            string[] pets = { "dog", "cat", "bird" };
            foreach (string value in pets)
            {
                Console.WriteLine(value);
            }
            Console.ReadKey();
        }
        static void two_dim_array()
        {
            //**
            Console.WriteLine(" Two Diminesional Array ");
            //**
            int[,] numbers2D = new int[3, 2] { { 9, 99 }, { 3, 33 }, { 5, 55 } };
            // or use the short form:
            // int[,] numbers2D = { {9,99}, {3,33}, {5,55} };
            foreach (int i in numbers2D)
            {
                System.Console.Write("{0} ", i);
            }
            Console.ReadKey();
            //**
        }
        static void LINQ_Query()
        {
            // An unsorted string array
            string[] letters = { "d", "c", "a", "b" };

            Console.WriteLine("UnSorted Version");
            foreach (string value in letters)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("Sorted Version using LINQ - Language Integrated Query");
            //Use LINQ - Language Integrated Query
            var sorted = from letter in letters
                         orderby letter
                         select letter;
            // Loop with foreach keyword
            foreach (string value in sorted)
            {
                Console.WriteLine(value);
            }
            Console.ReadKey();

        }
        static void Key_Value_Pair()
        {
            Dictionary<int, int> _f = new Dictionary<int, int>();
            _f.Add(1, 2);
            _f.Add(2, 3);
            _f.Add(3, 4);

            Console.WriteLine(" var pair in foreach loop ");
            // Use var in foreach loop
            foreach (var pair in _f)
            {
                Console.WriteLine("{0},{1}", pair.Key, pair.Value);
            }

            Console.ReadKey();

        }
        static void Dictionary_Key_Value_Pair()
        {
            /*
            Dictionary uses a hash table.   It is a large collection
            that will divide a collection into smaller collections.
            Each smaller collection is defined as a bucket.
            If you know what bucket the item your searching for is in,
            you only need to search that bucket.
            
            The modulo % method along with the .gethashcode method is used to determine the bucket when 
            storing or retrieving a value.
            
            If two values x and y evaluate to equal then they must evaluate to the same hash code.

            foreach (KeyValuePair<int,int> pair in _h) - Example showing KeyValuePair is a defined type that 
            can only be used with Dictionaries.
            https://www.tutorialsteacher.com/csharp/csharp-dictionary
            
            */

            Dictionary<int, int> _h = new Dictionary<int, int>();
            _h.Add(5, 4);
            _h.Add(4, 3);
            _h.Add(2, 1);

            Console.WriteLine(" KeyValuePair in for each loop ");
            foreach (KeyValuePair<int, int> pair in _h)
            {
                Console.WriteLine("{0},{1}", pair.Key, pair.Value);
            }
            Console.ReadKey();
        }
        static void List_Remove()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            // Loop over list elemements using foreach-loop
            foreach (int element in list)
            {
                Console.WriteLine(element);
            }
            // You can't remove elements in a foreach-loop
            try
            {
                foreach (int element in list)
                {
                    list.Remove(element);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            Console.ReadKey();
        }
        static void Operators()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/6a71f45d.aspx");
        }
        static void PreProcessing()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/vstudio/ed8yd1ha%28v=vs.100%29.aspx");
        }
        static void ProgramFlow()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/hh147286%28VS.88%29.aspx");
        }
        static void StatementKeywords()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/xt4z8b0f.aspx");
        }
        static void WhiledoWhile()
        {
            /*
             * while and do-while statements execute a body of code if the expression evaluates
             * to true.
             * - while evaluates the expression before
             *   executing the body, so the body may execute
             *   0 or more times.
             *   
             * - do-while evaluates the expression after the
             *   first execution of the body, so the body executes
             *   at least once.
             *   
             *   var loopcounter = 0;
             *   while (loopcounter > 0)
             *   {
             *     Console.WriteLine("This will not execute");
             *   }
             *   
             *   do
             *   {
             *     Console.WriteLine("This will execute");
             *   } while (loopcounter > 0);
             *   
            */
        }
        static void Prefix_and_Postfix_Operator()
        {
            /* For Loop Sequence.
             * 1. Initialize (int counter=0;)...Only done once.
             * .. Start Loop
             * 2. Condition (counter <=10;)
             * 3. Execute Statement (Console.WriteLine(counter))
             * 3. Iterator  (counter +=2)
             * .. End Loop
             */
            for (int counter = 0; counter <= 10; counter += 2)
            {
                Console.WriteLine("Counter value is {0}", counter);
            }
            Console.WriteLine("Example using ++Prefix Operator");
            for (int counter = 0; counter <= 5; ++counter)
            {
                Console.WriteLine("Counter value is {0}", counter);
            }
            Console.WriteLine("Example using Postfix++ Operator");
            for (int counter = 0; counter <= 5; counter++)
            {
                Console.WriteLine("Counter value is {0}", counter);
            }
        }
        #region YiedReturn
        public static IEnumerable<int> Totals(List<int> numbers)
        {
            /*
            Things to know about yield return:
                        1.We don't have to create an intermediate list to hold our variables
                        2.Does not return a list, but a promise to return a sequence of numbers when
                           asked for it(more concretely it exposes an iterator to allow us to act
                           on that promise).
                        3.Each iteration of the foreach loop calls the iterator method.  When the yield
                          return statement is reached the value is returned, and the current location 
                           in the code is retained.Execution is restarted from that location the next
                         time that the iterator function is called.
                        4.Since the method containing the yield return statement will be paused and
                           resumed where the yield statement takes place, it still maintains its state.
                        5.Yield helps exercise deferred execution.
             */
            var total = 0;
            foreach (var number in numbers)
            {
                total += number;
                yield return total;
            }

        }
        static void Yield_Return()
        {
            /*  See also Notes in InterfacesMenu.cs  IEnumerable
             *  Examples from:
             *  https://www.kenneth-truyers.net/2016/05/12/yield-return-in-c/
             *  Below outputs 1, 3, 6, 10, 15
             */

            foreach (var total in Totals(new List<int> { 1, 2, 3, 4, 5 }))
            {
                // Output is controlled by yield return
                Console.WriteLine(total);
            }
        }
        #endregion
        //public class Program
        //{

        //    const int _max = 100000000;
        //    public static void Program_Main()
        //    {
        //    Program program = new Program();
        //    var s1 = Stopwatch.StartNew();
        //    for (int i = 0; i < _max; i++)
        //     {
        //       program.Method1();
        //     }
        //        s1.Stop();
        //        var s2 = Stopwatch.StartNew();
        //        for (int i = 0; i < _max; i++)
        //        {
        //            program.Method2();
        //        }
        //        s2.Stop();
        //        Console.WriteLine(((double) (s1.Elapsed.TotalMilliseconds * 1000 * 1000) /
        //            _max).ToString("0.00 ns"));
        //        Console.WriteLine(((double) (s2.Elapsed.TotalMilliseconds * 1000 * 1000) /
        //            _max).ToString("0.00 ns"));
        //        Console.Read();
        //    }

        //    int[] _values = { 1, 2, 3 };

        //    int Method1()
        //    {
        //        //Access the field directly in the foreach expression
        //        int result = 0;
        //        foreach (int value in this._values)
        //        {
        //            result += value;
        //        }
        //        return result;
        //    }

        //    int Method2()
        //    {
        //        // Store the field into a local variable and then iterate.
        //        int result = 0;
        //        var values = this._values;
        //        foreach (int value in values)
        //        {
        //            result += value;
        //        }
        //        return result;
        //    }
        //}

    }

}
