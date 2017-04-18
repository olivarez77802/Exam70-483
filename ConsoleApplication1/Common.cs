using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JesseTesting.App
{
    class Common
    {
        public static string readString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();

            } while (result == "");
            return result;
        }

        // The readInt mthod reads a number within a particular range.   The
        // method uses the readString method in the readInt one, so that the 
        // user can't enter an empty string when a number is required.
        public static int readInt(string prompt, int low, int high)
        {
            int result;
            do
            {
                string intString = readString(prompt);
                try
                {
                    result = int.Parse(intString);
                }
                catch
                {
                    result = 11;
                    Console.WriteLine("Invalid number entered {0}, try again ", intString);
                    Console.ReadKey();
                }
            } while ((result < low || result > high));
            return result;

        }
    }
    
}
