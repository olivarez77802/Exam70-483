using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483.App.App
{
    class StringMethodExamples
    {
        private static bool RemoveString(string source, string search)
        {
            bool replaced = false;

            int position = source.IndexOf(search);
            if (position >= 0)
            {
                string removedsource = source.Remove(position, search.Length);
                replaced = true;
                Console.WriteLine("New string is {0}", removedsource);
            }

            return replaced;
        }


        private static void SubstringMethod()
        {
            String[] pairs = { "Color1=red", "Color2=green", "Color3=blue",
                         "Title=Code Repository" };
            foreach (var pair in pairs)
            {
                // The substring starts at a specified character position and continues to the end of the string.
                int position = pair.IndexOf("=");
                if (position < 0)
                    continue;
                Console.WriteLine("Key: {0}, Value: '{1}'",
                                  pair.Substring(0, position),
                                  pair.Substring(position + 1));
            }
        }

        // The example displays the following output:
        //     Key: Color1, Value: 'red'
        //     Key: Color2, Value: 'green'
        //     Key: Color3, Value: 'blue'
        //     Key: Title, Value: 'Code Repository'

        private static void TrimMethod()
        {

            // TRIM Removes all leading and trailing white-space characters from the current String object.

            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter your middle name or initial: ");
            string middleName = Console.ReadLine();

            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("You entered '{0}', '{1}', and '{2}'.",
                              firstName, middleName, lastName);

            string name = ((firstName.Trim() + " " + middleName.Trim()).Trim() + " " +
                          lastName.Trim()).Trim();
            Console.WriteLine("The result is " + name + ".");
        }

        // The following is possible output from this example:
        //       Enter your first name:    John
        //       Enter your middle name or initial:
        //       Enter your last name:    Doe
        //       
        //       You entered '   John  ', '', and '   Doe'.
        //       The result is John Doe.



        private static void IsNullOrWhiteSpaceMethod()
        {
            //White space is defined as any character with Unicode class Zs (which includes the space character) as well as the horizontal tab character, the vertical tab character, and the form feed character.
            //whitespace:
            //Any character with Unicode class Zs
            //Horizontal tab character (U+0009)
            //Vertical tab character (U+000B)
            //Form feed character (U+000C)

            //IsNullOrWhiteSpace is a convenience method that is similar to the following code, except that it offers superior performance:
            //return String.IsNullOrEmpty(value) || value.Trim().Length == 0;
            //White-space characters are defined by the Unicode standard. The IsNullOrWhiteSpace method interprets any character that returns a value of true
            //when it is passed to the Char.IsWhiteSpace method as a white-space character.

            string[] values = { null, String.Empty, "ABCDE", 
                          new String(' ', 20), "  \t   ", 
                          new String('\u2000', 10), " ABCDE" };
            foreach (string value in values)
            {
                Console.WriteLine("IsNullorWhiteSpace {0} {1} ", value, String.IsNullOrWhiteSpace(value));
                Console.WriteLine("IsNullorEmpty {0} {1}", value, String.IsNullOrEmpty(value));
            }
                

        }

        // The example displays the following output:
        //       True
        //       True
        //       False
        //       True
        //       True
        //       True
        //       False


        private static void IndexOfMethod()
        {
            String str = "animal";
            String toFind = "n";
            int index = str.IndexOf("n");
            Console.WriteLine("Found '{0}' in '{1}' at position {2}",
                              toFind, str, index);
        }

        // The example displays the following output:
        //        Found 'n' in 'animal' at position 1

        private static void DisplayCharSet()
        {
            char Bell = '\x07';
            char Bell2 = (char)7;
            Console.WriteLine("{0}", Bell);
            for (int ix = 0; ix <= 255; ix++)
            {
                Console.WriteLine("{0} {1:x}  {2} \n", ix, ix, (char)ix);

                int result = ix % 10;
                if (result == 0)
                    Console.ReadKey();

            }
            Console.WriteLine("{0}", Bell2);
        }

        public static void SMEMain()
        {
            string Source = "Learning C# is time consuming";
            bool result = RemoveString(Source, "time");
            if (result)
                Console.WriteLine("time removed from string");
            else
                Console.WriteLine("time was not removed");

            SubstringMethod();
            TrimMethod();
            IsNullOrWhiteSpaceMethod();
            IndexOfMethod();
            DisplayCharSet();

        }
    }
}
