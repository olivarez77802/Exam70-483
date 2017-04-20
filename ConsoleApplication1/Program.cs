﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace JesseTesting.App
{
    class Program
    {
        static void Main(string[] args)
        {

            // Microsoft C# Exam 70-483
            //
            // Manage Program Flow
            // Create and Use Types
            // Debug Applications and Implement Security
            // Implement Data Access
            //
            // https://www.microsoft.com/en-us/learning/exam-70-483.aspx
            //
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" C# Exam 70-483 \n ");
                Console.WriteLine(" 0.  Manage Program Flow \n ");
                Console.WriteLine(" 1.  Create and Use Types (Value/Reference) \n");
                Console.WriteLine(" 2.  Debug And Implement Security \n");               
                Console.WriteLine(" 3.  Implement Data Access \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");
                
                int selection;
                selection = Common.readInt ("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    
                    case 0: ManageProgramFlow.Menu();
                        break;
                    case 1: CreateAndUseTypes.Menu();
                        break;
                    case 2:
                        CryptographyExamples.Menu();
                        break;
                   
                    case 3: ImplementDataAccess.Menu();
                        break;

                   case 9 : x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;

                }

                                
            } while (x < 9);

                        
        } //* End Main


        // The readString method will read text and make sure that the user does not enter
        // empty text.   
        //static string readString(string prompt)
        //{
        //    string result;
        //    do
        //    {
        //        Console.Write(prompt);
        //        result = Console.ReadLine();

        //    } while (result == "");
        //    return result;
        //}

        //// The readInt mthod reads a number within a particular range.   The
        //// method uses the readString method in the readInt one, so that the 
        //// user can't enter an empty string when a number is required.
        //static int readInt(string prompt, int low, int high)
        //{
        //    int result;
        //    do
        //    {
        //        string intString = readString (prompt);
        //        result = int.Parse(intString);

        //    } while ((result < low || result > high));
        //    return result;

        //}
        //static void RunSimpleMath()
        //{
        //    /* This is a commment line */
        //    Console.WriteLine("Running SimpleMath");
        //    MathOps test = new MathOps();
        //    decimal answer = test.Add(2, 2);
        //    Console.WriteLine("The Add method returned 2 + 2 = " + answer);
        //    Console.WriteLine("2 + 3= " + new MathOps().Add(2, 3).ToString());
        //    Console.WriteLine("3 - 2= " + new MathOps().Subtract(2, 3).ToString());
        //    Console.WriteLine("2 * 3= " + new MathOps().Multiply(2, 3).ToString());
        //    Console.WriteLine("2/3  = " + new MathOps().Divide(2, 3).ToString());
        //    Console.ReadKey();
        //}

        
        
        static void RunwithDivideAnswer()
        {
            Console.Clear();
            Console.WriteLine("\nRunwithDivideAnswer");
            Console.WriteLine("\nDefined as public 'Divide Answer'. Divide Answer is a class that   ");
            Console.WriteLine("is returned.                                                         ");
            Console.WriteLine("                                                                    ");
            Console.WriteLine("                                                                 ");
            var simpleMath = new MathOps();
            DivideAnswer ans = simpleMath.Divide3(15, 6);
            Console.WriteLine("answer " + ans.Value);
            Console.WriteLine("remainder " + ans.Remainder);
            Console.Write("\nPress ENTER to Continue ");
            Console.ReadKey();
        }


        static void ftpsub()
        {

            
            // FtpWebRequest request = (FtpWebRequest)WebRequest.Create
            //    ("Site");
            // request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            //  Blank out after testing
            // request.Credentials = new NetworkCredential("Userid", "password");

            // FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            // Stream responseStream = response.GetResponseStream();
            // StreamReader reader = new StreamReader(responseStream);
            // Console.WriteLine(reader.ReadToEnd());

            // Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);
            // reader.Close();
            // response.Close();

            string contents = System.IO.File.ReadAllText(@"C:\Users\olivarez\My Documents\AIGA.TXT");
            Console.Out.WriteLine("contents = " + contents);
        }
    }


}


