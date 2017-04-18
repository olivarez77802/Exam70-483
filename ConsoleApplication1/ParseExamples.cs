using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace JesseTesting.App
{
    class ParseExamples
    {

        public static void Main_Mod()
        {
            // Parse the string as a hex value and display the value as a decimal.
            String num = "A";
            int val = int.Parse(num, NumberStyles.HexNumber);
            Console.WriteLine("{0} in hex = {1} in decimal.", num, val);

            // Parse the string, allowing a leading sign, and ignoring leading and trailing white spaces.
            num = "    -45   ";
            val = int.Parse(num, NumberStyles.AllowLeadingSign |
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite);
            Console.WriteLine("'{0}' parsed to an int is '{1}'.", num, val);

            // Parse the string, allowing parentheses, and ignoring leading and trailing white spaces.
            num = "    (37)   ";
            val = int.Parse(num, NumberStyles.AllowParentheses | NumberStyles.AllowLeadingSign | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite);
            Console.WriteLine("'{0}' parsed to an int is '{1}'.", num, val);
            Console.ReadKey();

            string rawNumber = "$(14)";
            int parsedNumber = int.Parse(rawNumber, NumberStyles.AllowParentheses | NumberStyles.AllowCurrencySymbol);
            Console.WriteLine("'{0}' parsed to an int is {1}'.", rawNumber, parsedNumber);

            int parsedNumber2 = int.Parse(rawNumber, NumberStyles.Currency);
            Console.WriteLine("'{0}' parsed to an int is {1}'.", rawNumber, parsedNumber2);


            // http://www.tutorialspoint.com/csharp/csharp_data_types.htm
            Console.WriteLine("Size of int in bytes: {0}", sizeof(int));
            Console.WriteLine("Size of Long in bytes: {0}", sizeof(long));
            Console.WriteLine("Size of char in bytes: {0}", sizeof(char));
            Console.WriteLine("Size of byte in bytes: {0}", sizeof(byte));
            Console.WriteLine("Size of float in bytes: {0}", sizeof(float));
            Console.WriteLine("Size of double in bytes: {0}", sizeof(double));
            Console.ReadKey();

        }

    }
}
