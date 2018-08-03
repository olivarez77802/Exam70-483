using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Collections;


namespace Exam70483
{

    public class Collections
    {
        /* Called by ReferenceTypes.cs
        */
        public static void Menu()
        {
            int x = 0;
            do
            {
                /*
                 * 
                 * For Each versus using 'For' loop
                 * 
                 A foreach is readonly
                 If you want to make modifications you have to use a for loop instead of a foreach
                 
                 But that does'n't mean individual elements are readonly, if the element contains
                 reference types you can still modify their values, can't demonstrate that with strings
                 because strings are immutable(unable to be changed or a value type, even though a string
                 is a reference type).   But can be done with an an array     
                 of a reference type that is mutable (able to be changed).
                
                 for each loop
                  - can't replace elements
                  - can modify values of elements - Array/Lists elements are read only.  But the element
                     properties can be modified e.g. You can change a word from lowercase to uppercase
                  - cannot modify the index
                  - only need one loop
                  - Must iterate through all elements of a list

                 for loop
                   - can replace elements
                   - Needed for nested loops
                
                 
                
                Arrays versus Lists
                
                Arrays.
                    1.  Fixed Length.  Are Definined, so you cannot add to array on the fly.
                        If you want to add on the fly you have to use a List.
                    2.  Single Dimension array can be used with a foreach
                    3.  Strongly typed
                Lists.
                    1. Expandable - can add, insert, or remove elements 
                    2. Multi-Dimensional.  A List cannot have more than one index. 
                       Have to use a Multi-Dimensional Array if you want more than one index.
                    3. A list can be used with a foreach.
                    4. Strongly typed
                
                Multi-Diminesional Arrays.
                    1.  Can have more than one index.
                    2.  Follow the x,y coordinates for a 2 dimensional array.  Great for grid based data
                    3.  Must use a 'for' loop for nested loops
                    4.  float [ , ] array1  -  defines a 2 dimensional array
                    5.  float [ , , ] array1 - defines a 3 dimesion array
                    6.  Multi-Dimensional Arrays are Simpler when compared to Jagged Arrays.
                    7.  The second, third dimension can only be arrays.  Can be any collection with Jagged Arrays
                
                Jagged Arrays.
                    1. Concept - You can put an Array into an Array
                    2. float [ ][ ] array1  - defines this as an array of arrays of floats.
                    3. float [ ][ ][ ] array1 - defines this as an array of arrays or arrays
                    4. float[ ][ ] array1 = new array1[4][]   -  you always have to set the first elment - says we will store 4 sets of arrays
                    5. Inner arrays (which is defined by the second element) do not have to be the same length, which is why they are called jagged.
                    6. The inner array can be any collections (.i.e. can be a List<int>)
                 
                
                */
                Console.Clear();
                Console.WriteLine(" Store data in and retrieve data from Collections  ");
                Console.WriteLine("     Store and retrieve data by using dictionaries, arrays, lists, sets,  ");
                Console.WriteLine("     and queues; hoose a collection type; initialize a collection; add    ");
                Console.WriteLine("     and remove items from a collection; use typed versus non-typed  ");
                Console.WriteLine("     collections; implement custom collections; implement collection interfaces. \n ");
                Console.WriteLine(" 0.  Print Obect Array  ");
                Console.WriteLine(" 1.  Print Generic List   ");
                Console.WriteLine(" 2.  Print Generic List Two   ");
                Console.WriteLine(" 3.  Print Generic List Three ");
                Console.WriteLine(" 4.  Class return List in Descending Order");
                Console.WriteLine(" 5.  Website ");
                Console.WriteLine(" 6.  Take Verb");
                Console.WriteLine(" 7.  Sort Ascendingz-Descending ");
                Console.WriteLine(" 8.  Dictionary and other Iterations");
                Console.WriteLine(" 9.  Quit            \n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                int[] J = { 1, 2, 3 };
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        PrintObjectArray(new { i = J[2] });
                        break;
                    case 1: PrintGenericList();
                        break;
                    case 2: PrintGenericList2();
                        break;
                    case 3: new PrintGenericList3().Print();
                        break;
                    case 4: List<CommonCollections.Cat> threecats = CommonCollections.GetSomeCats(3);
                        Console.WriteLine(" Listed in Descending Order ");
                        Console.WriteLine(" Example of a Class returning three Cats");
                        foreach (CommonCollections.Cat c in threecats)
                        {
                            Console.WriteLine(SortingExamples.PrintCats(c));
                        }
                        Console.ReadKey();
                        //
                        // Returning Full List
                        //
                        List<CommonCollections.Cat> dbcats = CommonCollections.GetAllCats();
                        Console.WriteLine(" Example of a Class returning a Full List");
                        foreach (CommonCollections.Cat c in dbcats)
                        {
                            Console.WriteLine(SortingExamples.PrintCats(c));
                        }
                        Console.ReadKey();
                        break;

                    case 5:
                        Arrays_Collections();
                        break;
                    case 6:
                        Test_To_take.TopThree();
                        break;
                    case 7:
                        SortingExamples.Sort_Ascending_Descending();
                        SortingExamples.Sort_A_Class();
                        break;
                    case 8: IterationStatements.Menu();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);  // end do

        }  // end Collections Menu()

        static void Arrays_Collections()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/9ct4ey7x(v=vs.90).aspx");
        }
        static void PrintObjectArray(object obj)
        {
            Console.WriteLine("ObjectArray.Print");
            string[] myArray = { "str 0", "str 1", "str 2", "str 3" };
            Console.WriteLine(" Object obj is {0} ", obj);

            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine("-" + myArray[i]);
            }
            Console.ReadKey();
        }
        static void PrintGenericList()
        {
            Console.WriteLine("GenericList.Print");
            List<string> myList = new List<string>();
            myList.Add("str 0");
            myList.Add("str 1");
            myList.Add("str 2");
            myList.Add("str 3");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine("-" + myList[i]);
            }
            Console.ReadKey();
        }
        static void PrintGenericList2()
        {
            Console.WriteLine("GenericList2.Print");


            List<string> myArray = new List<string> { "str 0", "str 1", "str 2", "str 3" };

            foreach (string myString in myArray)
            {
                Console.WriteLine(" - " + myString);
            }

            Console.ReadKey();
        }

        public static void Using_Collections()
        {
            //**
            Console.WriteLine(" for each with Collection Class ");
            //**
            char[] c = new char[] { ' ', '-' };
            string s = ("This is a sample sentence");
            //s - type string; c - delimiter
            Tokens f = new Tokens(s, c);
            Console.WriteLine("Example of using split");
            //Display the tokens.
            foreach (string item in f)
            {
                System.Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    } // end Collections Class


    class PrintGenericList3
    {
        public void Print()
        {
            Console.WriteLine("GenericList3.Print");

            List<Person> myList = new List<Person>
            {
                new Person { 
                    FirstName = "Jesse",
                    MiddleInitial = "N", 
                    LastName = "Olivarez", 
                    UIN = "111001111", 
                    EmailAddress = "jesseolivarez@tamus.edu",
                    HomeAddress = new DomesticAddress
                    {
                        Line1 = "1234 Main Street",
                        Line2 = "#503b",
                        City = "Bryan",
                        StateCode = "TX",
                        ZipCode = "77801"
                    }
                },
                    new Person
                    { 
                    FirstName = "Billy",
                    MiddleInitial = "N", 
                    LastName = "Thompson", 
                    UIN = "222002222", 
                    EmailAddress = "billyThomposon@tamus.edu",
                    HomeAddress = new DomesticAddress
                    {
                        Line1 = "634 Billy Street",
                        Line2 = "#980b",
                        City = "Bryan",
                        StateCode = "TX",
                        ZipCode = "77802"
                    }

                },
                 new Person
                    { 
                    FirstName = "Joe",
                    MiddleInitial = "N", 
                    LastName = "Aggie", 
                    UIN = "333003333", 
                    EmailAddress = "joeAggie@tamus.edu",
                    HomeAddress = new DomesticAddress
                    {
                        Line1 = "1234 Agggie Street",
                        Line2 = "#411b",
                        City = "Bryan",
                        StateCode = "TX",
                        ZipCode = "77845"
                    }

                }

                
            };  //end List Person

            foreach (Person p in myList)
            {
                Console.WriteLine(PrintPerson(p));
            }
        } // End Void Print()


        private string PrintPerson(Person p)
        {
            string homeAddress = p.HomeAddress != null
                  ? p.HomeAddress.GetPrintFormat()
                  : "";

            string output = string.Format(
                " - Name: {0}, {1}, {2} \n\t UIN: {3}\n\t Email: {4} \n\t {5} ",
                p.LastName,
                p.FirstName,
                p.MiddleInitial,
                p.UIN,
                p.EmailAddress,
                 homeAddress);

            return output;

        }

    } // end Class GenericList3 

    public class Person
    {
        public string UIN { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DomesticAddress HomeAddress { get; set; }

        public string FullName
        {
            get
            {
                // if ((MiddleInitial) != null)
                // return LastName + ", " + FirstName + " " + MiddleInitial;
                // else
                //  return LastName + ", " + FirstName;
                // string lastName = LastName;

                //this: 
                string lastName = !string.IsNullOrWhiteSpace(LastName)
                    ? !string.IsNullOrWhiteSpace(FirstName)
                    ? LastName + ", "
                    : LastName
                    : "";

                // is the same as this:
                if (!string.IsNullOrWhiteSpace(LastName))
                {
                    if (!string.IsNullOrWhiteSpace(FirstName))
                        lastName = LastName + ", ";
                    else
                        lastName = LastName;
                }
                else
                    lastName = "";

                if (!string.IsNullOrWhiteSpace(MiddleInitial))
                    return lastName + FirstName + " " + MiddleInitial;
                else
                    return lastName + FirstName;
            }
        }
    }

    public class DomesticAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }

        public string GetPrintFormat()
        {

            string output = " ";

            if (!string.IsNullOrWhiteSpace(Line2))
            {
                output = string.Format("{0}\n{1}\n{2}", Line1, Line2, City + ", " + StateCode + " " + ZipCode);
            }
            else
            //  line 2 is Empty
            {
                output = string.Format("{0}\n{1}", Line1, City + ", " + StateCode + " " + ZipCode);
            }

            return output;

        }
    }
   
   
    public class Test_To_take
    {

        public static void TopThree()
        {
            /*
             * Lambda expression - (gradeornamemeanything => gradeornamemeanything).Take(3);
             * gradeornamemeanything gets its type from grades
             * could have written (x => x).Take(3); 
            */
            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };
            IEnumerable<int> topThreeGrades =
            // grades.OrderByDescending(gradeornamemeanything => gradeornamemeanything).Take(3);
            grades.OrderByDescending(x => x).Take(3);
            
            Console.WriteLine("All Grades are:");
            foreach (int grade in grades)
            {
                Console.WriteLine(grade);
            }
            Console.WriteLine("Top Three are:");
            foreach (int grade in topThreeGrades)
            {
                Console.WriteLine(grade);
            }
            Console.ReadKey();
        }

    }

   

    public class Tokens : IEnumerable
    {
        private string[] elements;
        public Tokens(string source, char[] delimiters)
        {
            // The constructor parses the string argument into tokens
            elements = source.Split(delimiters);
        }

        // The IEnumerable interface requires implementation of method GetEnumerator.
        public IEnumerator GetEnumerator()
        {
            return new TokenEnumerator(this);
        }

        // Declare an inner class that implements the IEnumerator interface
        private class TokenEnumerator : IEnumerator
        {
            private int position = -1;
            private Tokens t;

            public TokenEnumerator(Tokens t)
            {
                this.t = t;
            }

            // The IEnumerator interface requires a MoveNext method.
            public bool MoveNext()
            {
                if (position < t.elements.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // The IEnumerator interface requires a Reset method
            public void Reset()
            {
                position = -1;
            }

            // The IEnumerator interface requires a Current method.
            public object Current
            {
                get
                {
                    return t.elements[position];
                }
            }

        }
    }
    
}
