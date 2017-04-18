using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace JesseTesting.App
{
    class IterationStatements
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Iteration Statements Menu \n ");
                Console.WriteLine(" 0.  Web Page \n ");
                Console.WriteLine(" 1.  Run foreach Example 1  \n ");
                Console.WriteLine(" 2.  Run Example 2 \n");
                Console.WriteLine(" 3.  Run Example 3 \n");
                Console.WriteLine(" 4.  Run Example 4 \n");
                Console.WriteLine(" 5.  Run Example 5 \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: WebPage();
                        break;
                    case 1: foreach_1();
                        break;
                    case 2: Operators();
                        break;
                    case 3: PreProcessing();
                        break;
                    case 4: ProgramFlow();
                        break;
                    case 5: StatementKeywords();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
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
            foreach_performance();
                        
            //Program p = new Program();
            //p.Program_Main();
            Console.WriteLine("Using Collections");            
            Collections.Using_Collections();

        }
        static void one_dim_array()
        {
            Console.WriteLine("One Dimensional Array");
            //**
            int[] fibarray = new int[] { 0, 1, 1, 2, 3, 5, 8, 13 };
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
        static void foreach_performance()
        {
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

        public class Program
        {

            const int _max = 100000000;
            public void Program_Main()
            {
            Program program = new Program();
            var s1 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
             {
               program.Method1();
             }
                s1.Stop();
                var s2 = Stopwatch.StartNew();
                for (int i = 0; i < _max; i++)
                {
                    program.Method2();
                }
                s2.Stop();
                Console.WriteLine(((double) (s1.Elapsed.TotalMilliseconds * 1000 * 1000) /
                    _max).ToString("0.00 ns"));
                Console.WriteLine(((double) (s2.Elapsed.TotalMilliseconds * 1000 * 1000) /
                    _max).ToString("0.00 ns"));
                Console.Read();
            }

            int[] _values = { 1, 2, 3 };

            int Method1()
            {
                //Access the field directly in the foreach expression
                int result = 0;
                foreach (int value in this._values)
                {
                    result += value;
                }
                return result;
            }

            int Method2()
            {
                // Store the field into a local variable and then iterate.
                int result = 0;
                var values = this._values;
                foreach (int value in values)
                {
                    result += value;
                }
                return result;
            }
        }
       
    }

}
