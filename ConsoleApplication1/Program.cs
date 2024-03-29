﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace Exam70483
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Intellisense Icons
             * Cube - Defines Method
             * Cube (Down Arrow) - Means that it has more than 1 overload
             * Wrench - Property
             * Wrench (Star) - Freguently Used Methods.
             * Lignting Bolt - Event
             * If a dispose method is exposed then then the garbage  collector will
             * not handle and you need to handle (see ExceptionClassExamples.cs)
             * 
             * dll - Dynamic Link Library
             * 
             * C# Version History
             * C# 4.0 --- Visual Studio 2010
             * C# 5.0 --- Visual Studio 2012, 2013
             * C# 6.0 --- Visual Studio 2015
             * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history
             * 
             * C# Version/ .Net Framework / Visual Studio - XREF
             * http://www.tutorialsteacher.com/csharp/csharp-version-history
             * 
             * C# 3.0 WCF(Windows Communication Foundation) was introduced
             * 
             * Location of Assembies and API's
             * C:\Program Files\Reference Assemblies\Microsoft
             * 
             * C# Developer command Prompt
             * Search for 'Developer Command Prompt'
             * Type 'Where csc.exe' to determine location of csc.exe and Framework
             * 
             * 
            // Microsoft C# Exam 70-483
            //
            // Manage Program Flow
            // Create and Use Types
            // Debug Applications and Implement Security
            // Implement Data Access
            //
            // https://www.microsoft.com/en-us/learning/exam-70-483.aspx
            //
               Took Exam on 08/08/2018
               Exam performance was weakest in the following areas:
               * Serialize and deserialize data. Serialize and deserialize data by using binary serializaation, custom
                 serialization, XML Serializer, JSON Serializer, Data Contract serializer.
               * Implement diagnostics in an application.  Objective may include but not limited to:  Implement logging 
                 and tracing; profiling applications; create and monitor performance counters; write to event logs
               * Implement multithreading and asynchronous processing.  Use Task Parallel Library (ParrallelFor, PLinq, Tasks);
                 create continuation tasks; spawn threads using ThreadPool; unblock the UI; use async and await keyworkds;
                 manage data by using concurrent collections.

              Things I remember struggling with:
               * --e  versus e--  (Prefix versus Post fix decrement)
               * Delay signing the assembly
               * Read a raw XML File what are the different elements, nodes called
               * Different file permissions when reading a file
               * Reading a file using different permissions when you don't want an exception called
               * How would you handle an exception in a concurret collection
               * #elif  - PreProcessor directive
               * Different type of attributes when reading WCF Web Services
               * Memory Leaks
               * Using an Alternate DB when testing
               * Setting up to run with a data field that is extremely large.  Do we modify a parameter in the 
                 config file ?
               * Using 'Is' operator to determine if an element in a  Generic List belongs to a class
               * WCF Namespaces
               * Regex
               * ?? operator
           
            C# Defaults - Implicit
            1. Classes are non-static and their access modifier is internal by default. Non-Static means instance members will be created (you use new Class1).  
               Classes have a default constructor.  Structs do not have a default constructor.
            2. Class members -   Are private by default.  If you remove the Accessor (see ClassHeirarchy.cs) on a class member by default it will be 'private', 
               so you cannot access member outside class.   
               https://stackoverflow.com/questions/2521459/what-are-the-default-access-modifiers-in-c/3175697

            3. Constructors - Classes and structes have a default constructor, structs cannot have a parameterless 
               contructor defined explicitly, the reason being is that structs are value types. Classes can have a parameteless constructor.
               When you use the new keyword objects are initialized to their default values (i.e. an int is set to zero, a string set to null).
               If you declare a variable of struct type without using the new keyword, it does not call any constructor, so all the
               members remain unassigned and will generate a compile error.  Remember that with classes if you do not define a constructor, 
               C# generates generates one that initializes all members to their default values.   Static constructors cannot have access modifiers 
               they are by default private (See Static Examples.cs).  Static constructors are called before instance constructors by default.

            4. Static classes are sealed by default
            5. Delegates behave like classes and structs.  By default they have internal
               access, they are private by default when nested.
               https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
            6. Interfaces are internal by default.  Interface members are public by default.
               Members of an interface must be public, since they have to be callable via the interface.
               public must be declared explicitily.

            */
            /* Global Exception Handler
             * See https://stackify.com/csharp-catch-all-exceptions/
             */
            AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
            {
                Debug.WriteLine(eventArgs.Exception.ToString());
            };
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" C# Exam 70-483 \n ");
                Console.WriteLine(" 0.  Manage Program Flow \n ");
                Console.WriteLine(" 1.  Create and Use Types \n");
                Console.WriteLine(" 2.  Debug And Implement Security \n");               
                Console.WriteLine(" 3.  Implement Data Access \n ");
                Console.WriteLine(" 4.  Micosoft Exam 70-483 Website \n");              
                Console.WriteLine(" 9.  Quit            \n\n ");
                
                int selection;
                selection = Common.readInt ("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    
                    case 0:
                        MenuManageProgramFlow.ManageProgramFlow.Menu();
                        break;
                    case 1:
                        MenuCreateAndUseTypes.CreateAndUseTypes.Menu();
                        break;
                    case 2:
                        MenuDebugImplementSecurity.DebugAppImplementSecurity.Menu();
                        break;
                   
                    case 3:
                        MenuImplementDataAccess.ImplementDataAccess.Menu();
                        break;
                    case 4:
                        Process.Start("https://www.microsoft.com/en-us/learning/exam-70-483.aspx");
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


