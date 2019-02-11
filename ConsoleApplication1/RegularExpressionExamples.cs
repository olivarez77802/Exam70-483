using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Globalization;

namespace Exam70483
{
    class RegularExpressionExamples
    {
        /*
        ^ - Anchors the regular expression to the beginning of string
        $ - Marks end of regular expression
        ? - Matches the previous element Zero or 1 times.  Anchors regular expression to end of string.
        * - Matches the previous element Zero or more times
        + - Match the previous element 1 or more times
        \d - Matches decimal digit
        [] - Define allowable characters, numbers
        {6} -The number of allowable characters, numbers
        {6,} - Matches the previous elmemet 6 or more times
        {1,3} - Specifies the minumum number charcters, numbers is 1 and the max is 3
         |  - Indicates 'OR'
         \  - Backslash means escaping- Remove special meaning from metacharacter or 
                                        Give special meaning to ordinary characters
        (?!expr) - Continue matching only if expression doesn't 
                   match on right (negative lookahead).
        (?:expr) - Non capturing group
       
       
         public const string Pattern = ";
          ^([9][0-9][0-9][7][0-9]|[9][0-9][0-9][8][1-8]|[9][0-9][0-9][9][0-2])
         public const string Pattern = ^(?!(?:(\d)\1{8}))
                                        (?!000)
                                        (?!666)
                                        (?:[0-8]\d{2}|7[0-7][0-2])
                                        (?:[ -]?)
                                        ((?!00)\d{2})
                                        (?:[ -]?)
                                        ((?![0]{4})\d{4})$
       
         http://regexr.com
           
         https://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex(v=vs.110).aspx
 
    
       
       */

        public static void Menu()
        {



            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Regular Expression Examples \n ");
                Console.WriteLine(" 0.  Regex.Match .IsMatch .Split \n ");
                Console.WriteLine(" 1.  Regex.IsMatch \n");
                Console.WriteLine(" 2.  RegexOptions (.Compiled.IgnoreCase) Regex.Matches \n");
                Console.WriteLine(" 3.  Dynamic Regular Expression \n");
                Console.WriteLine(" 4.  Value of Anchors");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        string txt = "979797171";
                        Print_phone(txt);
                        string txt2 = "7754132";
                        Print_phone(txt2);
                        string txt3 = "775-4132";
                        Print_phone(txt3);
                        Console.ReadKey();
                        break;
                    case 1:
                        string tempssn = "123456789";
                        Matchssn(tempssn);
                        string tempssn2 = "811111111";
                        Matchssn(tempssn2);
                        Console.ReadKey();
                        break;
                    case 2:
                        CompiledIgnoreCase();
                        Console.ReadKey();
                        break;
                    case 3:
                        DynamicRegularExpression();
                        Console.ReadKey();
                        break;
                    case 4:
                        Anchors();
                        Console.ReadKey();
                        break;
                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);  // end do

        }  // end Menu()

        static void Print_phone(string phone)
        {
            const string pattern = @"^\d{3}-\d{4}$";
            const string ITINSPattern = @"^([7][0-9]|[8][0-8]|[9][0-2]|[9][4-9])";
            Match ITINSMatch = Regex.Match(phone.Substring(4, 2), ITINSPattern);
            bool ITINSuccess = ITINSMatch.Success;
            if (ITINSuccess)
                Console.WriteLine(" Pattern matches");
            else
                Console.WriteLine(" Pattern does not match ");

            bool valid = false;
            if (phone.Length == 0) valid = true;
            if (Regex.IsMatch(phone, pattern)) valid = true;
            string[] splt = (Regex.Split(phone, pattern));
            if (valid)
                Debug.WriteLine("phone number matches {0}", phone);
            else
                Debug.WriteLine("phone number does not match {0}", phone);
            foreach (var i in splt)
            {
                Debug.WriteLine("split is {0} ", splt);
            }
        }
        static void Matchssn(string ssn)
        {
            const string pattern = @"^(?!(?:(\d)\1{8}))";
            bool valid = false;
            if (Regex.IsMatch(ssn, pattern)) valid = true;
            if (valid)
                Debug.WriteLine("ssn matches pattern {0}", ssn);
            else
                Debug.WriteLine("ssn does not match pattern {0}", ssn);

        }
        static void CompiledIgnoreCase()
        {
            // Define a regular expression for repeated words.
            Regex rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b",
              RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Define a test string.        
            string text = "The the quick brown fox  fox jumped over the lazy dog dog.";

            // Find matches.
            MatchCollection matches = rx.Matches(text);

            // Report the number of matches found.
            Console.WriteLine("{0} matches found in:\n   {1}",
                              matches.Count,
                              text);

            // Report on each match.
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine("'{0}' repeated at positions {1} and {2}",
                                  groups["word"].Value,
                                  groups[0].Index,
                                  groups[1].Index);
            }
        }
        static void DynamicRegularExpression()
        {
            // Get the current NumberFormatInfo object to build the regular 
            // expression pattern dynamically.
            NumberFormatInfo nfi = NumberFormatInfo.CurrentInfo;

            // Define the regular expression pattern.
            string pattern;
            pattern = @"^\s*[";
            // Get the positive and negative sign symbols.
            pattern += Regex.Escape(nfi.PositiveSign + nfi.NegativeSign) + @"]?\s?";
            // Get the currency symbol.
            pattern += Regex.Escape(nfi.CurrencySymbol) + @"?\s?";
            // Add integral digits to the pattern.
            pattern += @"(\d*";
            // Add the decimal separator.
            pattern += Regex.Escape(nfi.CurrencyDecimalSeparator) + "?";
            // Add the fractional digits.
            pattern += @"\d{";
            // Determine the number of fractional digits in currency values.
            pattern += nfi.CurrencyDecimalDigits.ToString() + "}?){1}$";
            Console.WriteLine("Regex pattern {0}", pattern);

            Regex rgx = new Regex(pattern);

            // Define some test strings.
            string[] tests = { "-42", "19.99", "0.001", "100 USD",
                         ".34", "0.34", "1,052.21", "$10.62",
                         "+1.43", "-$0.23" };

            // Check each test string against the regular expression.
            foreach (string test in tests)
            {
                if (rgx.IsMatch(test))
                    Console.WriteLine("{0} is a currency value.", test);
                else
                    Console.WriteLine("{0} is not a currency value.", test);
            }
        }

        struct zipclass
        {
            public string zip { get; set; }
            public string pattern { get; set; }
        }
        static void Anchors()
        {
            List<zipclass> mylist = new List<zipclass>
            {
                new zipclass
                {
                    zip = "77802",
                    pattern = @"\d{5}(-d{4})?"
                },
                 new zipclass
                {
                    zip = "77802test",
                    pattern = @"\d{5}(-d{4})?"
                },
                 new zipclass
                {
                    zip = "  77802",
                    pattern = @"\d{5}(-d{4})?"
                },
                new zipclass
                {
                    zip = "  77802",
                    pattern = @"^\d{5}(-d{4})?"
                },
                new zipclass
                {
                    zip = "77802",
                    pattern = @"^\d{5}(-d{4})?$"
                },
                 new zipclass
                {
                    zip = "77802test",
                    pattern = @"^\d{5}(-d{4})?$"
                }
             }; 
            

            foreach (zipclass i in mylist)
            {
                valpattern(i);
            }
            
            
        }
        static void valpattern(zipclass zip1)
        {
            bool valid = false;
            if (Regex.IsMatch(zip1.zip, zip1.pattern)) valid = true;
            if (valid)
                Console.WriteLine("zip {0}  matches pattern {1}", zip1.zip, zip1.pattern);
            else
                Console.WriteLine("zip {0} does not match pattern {1}", zip1.zip, zip1.pattern);
        }
    }
}

