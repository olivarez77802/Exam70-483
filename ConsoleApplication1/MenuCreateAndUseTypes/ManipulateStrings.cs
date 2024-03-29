﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Exam70483.MenuCreateAndUseTypes 
    
{
    public class ManipulateStrings : IMenu
    {
        public void MenuOpt0()
        {
            StringBuilder_Ex();
        }

        public void MenuOpt1()
        {
            StringWriter_Ex();
            
        }

        public void MenuOpt2()
        {
            StringReader_Ex();
        }

        public void MenuOpt3()
        {
            //DatetimeNow
            Process.Start("https://www.dotnetperls.com/datetime-now");
            // DateTimeFormat in C#
            Process.Start("https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1");
            // String Format
            Process.Start("https://www.dotnetperls.com/format");
        }

        public void MenuOpt4()
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/system.string_methods(v=vs.110).aspx");
            // SMEMain();

        }

        public void MenuOpt5()
        {
            SE_Main();
            Console.ReadKey();
           
        }

        public void MenuOpt6()
        {
            // DisplayCharSet();

        }

        #region SBMain1 - Example of using Append
        static void SBMain1()
        {
            StringBuilder builder = new StringBuilder(5);
            // Append to StringBuilder.
            for (int i = 0; i < 10; i++)
            {
                builder.Append(i).Append(" ");

            }
            Console.WriteLine(builder);
        }
        #endregion

        #region SBMain2 - Example of Appending a sentence
        static void SBMain2()
        {
            // Declare a new StringBuilder.
            StringBuilder builder = new StringBuilder();
            builder.Append("The list starts here:");
            builder.AppendLine();
            builder.Append("1 cat").AppendLine();

            // Get a reference to the StringBuilder's buffer content.
            string innerString = builder.ToString();

            // Display with Debug.
            Debug.WriteLine(innerString);
            Console.WriteLine("{0}", innerString);
        }
        #endregion
        #region SBMain3
        static void SBMain3()
        {
            StringBuilder builder = new StringBuilder(
                "This is an example string that is an example.");
            builder.Replace("an", "the"); // Replaces 'an' with 'the'.
            Console.WriteLine(builder.ToString());
            Console.ReadLine();
        }
        #endregion
        #region SBMain4
        static void SBMain4()
        {
            string[] items = { "Cat", "Dog", "Celebrity" };

            StringBuilder builder2 = new StringBuilder(
                "These items are required:").AppendLine();

            foreach (string item in items)
            {
                builder2.Append(item).AppendLine();
            }
            Console.WriteLine(builder2.ToString());

        }
        #endregion
        #region StringReader
        static void StringReader_Ex()
        {
            // http://www.dotnetperls.com/stringreader
            const string _input = @"Dot Net Perls
           is a website
           you are reading";

            /* Creates new StringReader instance from System.IO
               ReadLine: We can then read each line individually
               from the string data, in a way similar to reading
               a file with StreamReader.
            */
            using (StringReader reader = new StringReader(_input))
            {
                // Loop over the lines in the string.
                int count = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                    Console.WriteLine("Line {0}: {1}", count, line);
                }
            }
        }
        #endregion
        #region StringBuilder_Ex
        static void StringBuilder_Ex()
        {
            /*
             * StringBuilder is a dynamic object that allows you to expand the number of characters in a string.
             * It does create a new object in memory but dynamically expands memory to accomodate the 
             * modified string.  StringBuilder can be initialized the same way as class.
             * 
             * StringBuilder sb = new StringBuilder();
             * //or
             * StringBuilder sb = new StringBuilder("Hello World!!");
             * 
             * You can give an initial capacity of characters by passing an int value in the constructor.
             * The follow will allocate 50 characters sequentially on the memory heap.  The memory allocation
             * automatically expands once it reaches the capacity.
             * 
             * StringBuilder sb = new StringBuilder(50);
             * //or
             * StringBuilder sb = new StringBuilder("Hello World!!",50);
             * 
             * https://www.tutorialsteacher.com/csharp/csharp-stringbuilder
             * 
             * * StringBuilder versus String
             * https://www.youtube.com/watch?v=hF-6eudOD0M
             * 
             * String was designed to be immutable (not able to be changed).  It was designed this way primarily
             * for thread saftey.  New allocations are created rather than reusing the old one.  The content of 
             * a string cannot be changed after the object is created.   The compiler actually creates a new string
             * object to hold the new sequence of characters, and that new ojbect is assigned to b.   The memory that had
             * been allocated for b (when it contained the string 'h') is then eligible for garbage colllection.
             * Example: 
             * string b = 'h'
             * b += 'ello'
             * 
             * String Builder will not create new space allocations.  The StringBuilder class creates a string buffer
             * that provides better performance in the below situation.
             * 
             * Ex.  String - Resource intensive
             * static void Main()
             * {
             *   string x="";
             *   for (int i=0; i<10000; i++)
             *   {
             *      x = "Shiv" + x;
             *   }
             * }
             * Ex.  StringBuilder - Optimal - Updates the same memory location
             * static void Main()
             * {
             *   StringBuilder x= new StringBuilder;
             *   for (int i=0; i<10000; i++)
             *   {
             *      x.Append = "Shiv";
             *   }
             * }
             * 
             * CLR Profiler allows you to see the memory allocation for the managed area
             * https://www.microsoft.com/en-us/download/details.aspx?id=16273
             * 
             * StringBuilder
             * https://learning.oreilly.com/videos/programming-in-microsoft/9781771373579/9781771373579-video211210
             * 
             * StringReader and StringWriter classes provide the ability to manipulate string data inside a StringBuilder
             * object.
             *  - StringWriter writes to the StringBuilder object
             *  - StringReader reads string data from the StringBuilder Object
             *  - Use them when you are dealing with a lot of string manipulations.
             *  See also StreamExamples.cs
             */
            Console.WriteLine(" SBMain1 ");
            SBMain1();
            Console.ReadKey();
            Console.WriteLine(" SBMain2 - Uses AppendLine");
            SBMain2();
            Console.ReadKey();
            Console.WriteLine(" SBMain3 - Replaces an with the");
            SBMain3();
            Console.ReadKey();
            Console.WriteLine(" SBMain4 - Uses AppendLine");
            SBMain4();
            Console.ReadKey();
        }
        #endregion
        #region StringWriter_EX
        static void StringWriter_Ex()
        {
            /*
             * https://www.youtube.com/watch?v=uEcwwjB7Fg4
             * 
             * https://learning.oreilly.com/videos/programming-in-microsoft/9781771373579/9781771373579-video211211
            */
            StringReadWrite srw = new StringReadWrite();
        }

        #endregion
        #region StringReadWrite

        private class StringReadWrite
        {
            StringBuilder sb = new StringBuilder();
            public StringReadWrite()
            {
                WriteData();
                ReadData();
            }
            public void WriteData()
            {
                StringWriter sw = new StringWriter(sb);
                Console.WriteLine("Please enter your first and last name...");
                string name = Console.ReadLine();
                sw.WriteLine("Name: " + name);
                sw.Flush();
                sw.Close();
            }
            public void ReadData()
            {
                StringReader sr = new StringReader(sb.ToString());
                Console.WriteLine("Reading the information...");
                while (sr.Peek() > -1)
                {
                    Console.WriteLine(sr.ReadLine());
                }
                Console.WriteLine();
                Console.WriteLine("Thank You!");
                sr.Close();
            }
        }
        #endregion

        #region StringEquality
        /*
        https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-comparison-operator


        For reference types other than string, == returns true if its two operands refer to the same object.
        For the string type, == compares the values of the strings.   So String is the only refernce type
        that you can use == with.

        String implements IComparable<string>

        IComarable versus IComparer 
        IComparable as I’m comparable. which means I can be compared to another instance of the same type.
                    - used for natural comparisons
        IComparer as I’m a comparer, I simply compare which means I compare two instances. 
                    - allows for plugging in alternative comparisons
                    - Can do one thing, great example of single responsilibity principle 
        Comparers are needed to sort collections, or anything else that needs to sort objects.
        http://www.karthikscorner.com/sharepoint/icomparable-vs-icomparer-c/

        Comparer<T> Implements IComarer<T>
        Writing a comparer for non-sealed classes is problematic
        Consider using sealed class when writing a class to compare 

       Mistake #3 - Using improper or unspecified string comparison methods
       https://www.toptal.com/c-sharp/top-10-mistakes-that-c-sharp-programmers-make
       The preferred way to test for string equality is with the 'Equals' method.
       public bool Equals(string value);   <-- Same as using '=='
       public bool Equals(string value, StringComparison comparisonType);

       */

        public static void SE_Main()
        {
            // Numeric equality: True
            Console.WriteLine((2 + 2) == 4);

            // Reference equality: different objects, 
            // same boxed value: False.
            object s = 1;
            object t = 1;
            Console.WriteLine(s == t);

            // Define some strings:
            string a = "hello";
            string b = String.Copy(a);
            string c = "hello";

            // Compare string values of a constant and an instance: True
            Console.WriteLine(a == b);

            // Compare string references; 
            // a is a constant but b is an instance: False.
            Console.WriteLine((object)a == (object)b);

            // Compare string references, both constants 
            // have the same value, so string interning
            // points to same reference: True.
            Console.WriteLine((object)a == (object)c);

            /* 
             * C# also includes String.Compare() and String.CompareTo() method, but these methods
             * are not meant to compare string equality but rather meant to check the relative
             * positions of strings in sorted order. 
             * https://www.tutorialsteacher.com/articles/compare-strings-in-csharp
             *  
             * Compare two strings and ignore casing
             * Returns an integer that give the relative position in sort order
             * See InterfacesMenu.cs  1 means greater than; 0 means equal to; -1 means less than.
             * https://docs.microsoft.com/en-us/dotnet/api/system.string.compare?view=netcore-3.1
            */
            string t0 = "HELLO";
            string t1 = "hello";
            var honorcaset0t1 = String.Compare(t0, t1, false );   // Same as String.Compare(t0,t1);
            var honorcaset1t0 = String.Compare(t1, t0, false);    // Same as String.Compare(t1,t0);
            var ignorecase = String.Compare(t0, t1,true);
            var honorcaset0t1No3rdParm = String.Compare(t0, t1);
            var honorcaset1t0No3rdParm = String.Compare(t1, t0);
            Console.WriteLine("Honour case when comparing strings {0}", honorcaset0t1);  //Outputs 1
            Console.WriteLine("Honour case when comparing strings {0}", honorcaset1t0);  //Outputs -1
            Console.WriteLine("Ignore case when comparing strings {0}", ignorecase); //Outputs 0
            Console.WriteLine("Honour case(No 3rd Parm, default is false) when comparing strings {0}", honorcaset0t1No3rdParm);  //Outputs 1
            Console.WriteLine("Honour case(No 3rd Parm, default is false) when comparing strings {0}", honorcaset1t0No3rdParm);  //Outputs -1

        }
        #endregion

    }
}
