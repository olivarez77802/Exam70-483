using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Exam70483
{
   class RegularExpressionExamples
    {
       // ^ - Anchors the regular expression to the beginning of string
       // ? - Means Optional.   Zero or one match.  Anchors regular expression to end of string.
       // * - Match Zero or more times
       // + - Match one or more times
       // \d - Matches decimal digit
       // {6} - Match exactly 6 characters
       //  |  - Indicates 'OR'
       //  \  - Backslash means escaping- Remove special meaning from metacharacter or 
       //                                 Give special meaning to ordinary characters
       // (?!expr) - Continue matching only if expression doesn't 
       //            match on right (negative lookahead).
       // (?:expr) - Non capturing group
       //
       //
       //  public const string Pattern = ";
        //  ^([9][0-9][0-9][7][0-9]|[9][0-9][0-9][8][1-8]|[9][0-9][0-9][9][0-2])
       //  public const string Pattern = ^(?!(?:(\d)\1{8}))
       //                                 (?!000)
       //                                 (?!666)
       //                                 (?:[0-8]\d{2}|7[0-7][0-2])
       //                                 (?:[ -]?)
       //                                 ((?!00)\d{2})
       //                                 (?:[ -]?)
       //                                 ((?![0]{4})\d{4})$
       //

        // http://regexr.com
       //
       //

        public static void Menu()
        {
            string txt = "979797171";
            Print_phone(txt);
            string txt2 = "7754132";
            Print_phone(txt2);
            string txt3 = "775-4132";
            Print_phone(txt3);
            Console.ReadKey();
            string tempssn =  "123456789";
            Matchssn(tempssn);
            string tempssn2 = "811111111";
            Matchssn(tempssn2);
            Console.ReadKey();
        }
        public static void Print_phone(string phone)
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
        public static void Matchssn(string ssn)
        {
            const string pattern = @"^(?!(?:(\d)\1{8}))"; 
            bool valid = false;
            if (Regex.IsMatch(ssn, pattern)) valid = true;
            if (valid)
                Debug.WriteLine("ssn matches pattern {0}", ssn);
            else
                Debug.WriteLine("ssn does not match pattern {0}", ssn);
           
        }
    }
}
