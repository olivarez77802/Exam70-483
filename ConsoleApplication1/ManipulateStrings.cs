using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Exam70483
{
    /*
     * StingBuilder versus String
     * https://www.youtube.com/watch?v=hF-6eudOD0M
     * 
     * String was designed to be immutable (not able to be changed).  It was designed this way primarily
     * for thread saftey.  New allocations are created rather than reusing the old one.  
     * 
     * String Builder will not create new space allocations
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
     * 
     */
    class ManipulateStrings   // and String Examples
    {
        #region SBMain1 - Example of using Append
        static void SBMain1()
        {
            StringBuilder builder = new StringBuilder();
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
            Console.WriteLine("{0}",innerString);
        }
        #endregion

        static void SBMain3 ()
        {
            StringBuilder builder = new StringBuilder(
                "This is an example string that is an example.");
            builder.Replace("an", "the"); // Replaces 'an' with 'the'.
            Console.WriteLine(builder.ToString());
            Console.ReadLine();
        }

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
        
        public static void Menu()
        {

            int x = 0;
            do
            {
                //Process.Start("http://msdn.microsoft.com/en-us/library/z2kcy19k.aspx");
                //Process.Start("http://www.dotnetperls.com/stringbuilder");
                Console.Clear();
                Console.WriteLine("Manipulate Strings");
                Console.WriteLine("  Maniuplate strings using StringBuilder, StringWriter, and  ");
                Console.WriteLine("  StringReader classes; search strings; enumerate string");
                Console.WriteLine("  methods; format strings; use string interpolation ");

                Console.WriteLine(" 0.  StringBuilder");
                Console.WriteLine(" 1.  StringWriter");
                Console.WriteLine(" 2.  StringReader");
                Console.WriteLine(" 3.  StringWriter");
                Console.WriteLine(" 4.  ...");
                Console.WriteLine(" 5.  ...");
                Console.WriteLine(" 6.  ...");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        StringBuilder_Ex();
                        break;
                    case 1:
                        break;
                    case 2:
                        StringReaderExamples.Menu();
                        break;
                    case 3:
                        StringWriter_Ex();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
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

        static void StringBuilder_Ex()
        {
            Console.WriteLine(" SBMain1 ");
            ManipulateStrings.SBMain1();
            Console.ReadKey();
            Console.WriteLine(" SBMain2 - Uses AppendLine");
            ManipulateStrings.SBMain2();
            Console.ReadKey();
            Console.WriteLine(" SBMain3 - Replaces an with the");
            ManipulateStrings.SBMain3();
            Console.ReadKey();
            Console.WriteLine(" SBMain4 - Uses AppendLine");
            ManipulateStrings.SBMain4();
            Console.ReadKey();
        }
        static void StringWriter_Ex()
        {
            /*
             * https://www.youtube.com/watch?v=uEcwwjB7Fg4
            */
                        
        }

    }
}
