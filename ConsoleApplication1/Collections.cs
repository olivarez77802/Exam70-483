using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Collections;


namespace JesseTesting.App
{

    public class Collections
    {
        public static void CollectionsMenu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Collections Menu \n ");
                Console.WriteLine(" 0.  Print Obect Array \n ");
                Console.WriteLine(" 1.  Print Generic List  \n ");
                Console.WriteLine(" 2.  Print Generic List Two  \n ");
                Console.WriteLine(" 3.  Print Generic List Three \n");
                Console.WriteLine(" 4.  Class return List in Descending Order\n");
                Console.WriteLine(" 5.  Website \n");
                Console.WriteLine(" 6.  Take Verb\n");
                Console.WriteLine(" 7.  Sort Ascendingz-Descending\n");
                Console.WriteLine(" 8.  Dictionary and other Iterations");
                Console.WriteLine(" 9.  Quit            \n\n ");
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
            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };
            IEnumerable<int> topThreeGrades =
            grades.OrderByDescending(grade => grade).Take(3);

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
