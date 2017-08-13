using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Exam70483.App.App
{
    abstract class StringBuilderExamples   // and String Examples
    {
        #region SBMain1 - Example of using Append
        private static void SBMain1()
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
        private static void SBMain2()
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

        private static void SBMain3 ()
        {
            StringBuilder builder = new StringBuilder(
                "This is an example string that is an example.");
            builder.Replace("an", "the"); // Replaces 'an' with 'the'.
            Console.WriteLine(builder.ToString());
            Console.ReadLine();
        }

        private static void SBMain4()
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
        
        public static void PrimaryMain()
        {

            Process.Start("http://msdn.microsoft.com/en-us/library/z2kcy19k.aspx");
            Process.Start("http://www.dotnetperls.com/stringbuilder");
            Console.WriteLine(" SBMain1 ");
            StringBuilderExamples.SBMain1();
            Console.ReadKey();
            Console.WriteLine(" SBMain2 - Uses AppendLine");
            StringBuilderExamples.SBMain2();
            Console.ReadKey();
            Console.WriteLine(" SBMain3 - Replaces an with the");
            StringBuilderExamples.SBMain3();
            Console.ReadKey();
            Console.WriteLine(" SBMain4 - Uses AppendLine");
            StringBuilderExamples.SBMain4();
            Console.ReadKey();


       }

    }
}
