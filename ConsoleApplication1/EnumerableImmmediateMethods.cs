using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace JesseTesting.App
{
    class EnumerableImmmediateMethods
    {
        private enum eMenu
        {
            WebSite,
            MethodToList,
            MaxMinMethod,
            AllMethod,
            CountMethod,
            DistinctMethod,
            ExceptMethod,
            FirstMethod,
            IntersectMethod,
            Quit
        }
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Enumerable Methods Menu - Immediate Operators\n ");
                Console.WriteLine(" 0.  Website \n ");
                Console.WriteLine(" 1.  MethodToList \n ");
                Console.WriteLine(" 2.  MaxMinMethod \n");
                Console.WriteLine(" 3.  AllMethod \n");
                Console.WriteLine(" 4.  CountMethod \n");
                Console.WriteLine(" 5.  Distinct Method \n");
                Console.WriteLine(" 6.  Except Method \n");
                Console.WriteLine(" 7.  First Method \n");
                Console.WriteLine(" 8.  Intersect Method \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");

                eMenu selection = (eMenu)(Common.readInt("Enter Number to Execute Routine : ", 0, 9));
                switch (selection)
                {
                    case eMenu.WebSite:
                        Website();
                        break;

                    case eMenu.MethodToList:
                        MethodToList();
                        break;

                    case eMenu.MaxMinMethod:
                        MaxMinMethod();
                        break;

                    case eMenu.AllMethod:
                        ALLMethod();
                        break;
                    case eMenu.CountMethod:
                        CountMethod();
                        break;

                    case eMenu.DistinctMethod:
                        DistinctMethod();
                        Console.ReadKey();
                        break;
                    case eMenu.ExceptMethod:
                        ExceptMethod();
                        Console.ReadKey();
                        break;
                    case eMenu.FirstMethod:
                        FirstMethod();
                        Console.ReadKey();
                        break;
                    case eMenu.IntersectMethod:
                        IntersectMethod();
                        Console.ReadKey();
                        break;
                    case eMenu.Quit:
                        x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);

        }  // End Menu

        private static void Website()
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/vstudio/bb342261(v=vs.100).aspx");
        }
        private static void MethodToList()
        {
            Console.WriteLine(" To List (.ToList) ");
            string[] fruits = { "apple", "passionfruit", "banana", "mango",
                                  "orange", "blueberry", "grape", "strawberry" };
            List<int> lengths = fruits.Select(fruit => fruit.Length).ToList();
            int i = 0;
            foreach (int length in lengths)
            {
                // Console.WriteLine("Length of ", fruits[i++], "is ", + length);

                string output = string.Format("\n Length of {0} is {1} ",
                                fruits[i++], length);
                Console.Write(output);
            }
        }
        private static void MaxMinMethod()
        {
            Console.WriteLine("Max / Min .Max() or .Min() ");
            List<long> longs = new List<long> { 4294967296L, 466855135L, 81125L };
            List<int> ints = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            long max = longs.Max();
            long min = longs.Min();
            int max2 = ints.Max();
            int min2 = ints.Min();

            Console.WriteLine("The largest number in longs is {0}", max);
            Console.WriteLine("The smallest number in longs is {0} ", min);
            Console.WriteLine("The largest number in ints is {0}.", max2);
            Console.WriteLine("The smallest number in ints is {0}", min2);

        }


        class Pet
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        private static void ALLMethod()
        {
            // Create an array of pets.
            Console.WriteLine(" .All Method = Compares all elements ");
            Pet[] pets = { new Pet { Name = "Barley", Age = 10 },
                               new Pet { Name = "Boots", Age = 4 },
                               new Pet { Name = "Whiskers", Age = 6 },
                               new Pet { Name = "Whiskey", Age = 10}};

            bool allStartwithB = pets.All(pet => pet.Name.StartsWith("B"));


            Console.WriteLine("{0} pet names start with 'B'. ",
                allStartwithB ? "All" : "Not all");
        }
        private static void CountMethod()
        {
            Console.WriteLine(" Counts all elements in List ");
            string[] fruits = { "apple", "bamama", "mango", "orange", "passionfruit", "grape" };
            try
            {
                int numberOfFruits = fruits.Count();
                Console.WriteLine(" There are {0} fruits in the collection.", numberOfFruits);

            }
            catch (OverflowException)
            {
                Console.WriteLine("The count is too large to store as an Int 32.");
                Console.WriteLine("Try using the LongCount() method instead.");
            }
        }
        private static void DistinctMethod()
        {
            Console.WriteLine(" Identifies distint element in List ");
            List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };
            IEnumerable<int> distinctAges = ages.Distinct();
            Console.WriteLine("Disting ages: ");

            foreach (int age in distinctAges)
            {
                Console.WriteLine(age);
            }
        }
        private static void ExceptMethod()
        {
            Console.WriteLine(" Writes all elements EXCEPT one (.Except(xxxx) ");
            double[] numbers1 = { 2.0, 2.1, 2.2, 2.3, 2.4, 2.5 };
            double[] numbers2 = { 2.2 };

            IEnumerable<double> onlyInFirstSet = numbers1.Except(numbers2);
            foreach (double number in onlyInFirstSet)
                Console.WriteLine(number);
        }
        private static void FirstMethod()
        {
            Console.WriteLine("Identifies First Element in List");
            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54, 83, 23, 87, 435, 67, 12, 19 };
            int first = numbers.First();

            Console.WriteLine(first);

            int first2 = numbers.First(xxnumber3 => xxnumber3 > 80);
            Console.WriteLine(first2);
        }
        private static void IntersectMethod()
        {
            Console.WriteLine(" Intersect Method");
            int[] id1 = { 44, 26, 92, 30, 71, 38 };
            int[] id2 = { 39, 59, 83, 47, 26, 4, 30 };

            IEnumerable<int> both = id1.Intersect(id2);

            foreach (int id in both)
                Console.WriteLine(id);
        }


        private static string PrintEmployees(CommonCollections.LogonDTO e)
        {
            string output = string.Format(" EID: {0}  IPAddress {1}  DateTime {2} \n", e.EID, e.IPAddress, e.LogonTime);
            return output;
        }

    }
}
