using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Exam70483
{
    /*
     * Called by ManageProgramFlog.cs
     * 
     * Exception Handling Good Practices
     * 1. Do not add a catch block that does nothing or just rethrows.  Catch block should add some value.
     *    Value would be considered logging the error, or report error to end user.  Bad practice to (swallow/trap)
     *    exceptions.
     * 2. Do not use exceptions for normal program flow logic.  e.g. Input Validation. You expect input to be invalid
     *    sometimes.  Invalid input is not an exceptional situation, it is considered normal flow.  Should write IsValid(xxx)
     *    methods instead.   Class Properties can be used for Input Validation.  Use 'Case' statement for Input Validation.
     *    
     * 3. Design code to avoid exceptions. e.g. Use TryParse instead of Parse. See ConsumeTypes.cs
     * 
     * 4. Use finally blocks for cleanup.   Always call 'dispose' method if Intellisense
     *    says there is one.  Intellisense will let you know that the garbage collector
     *    will not automatically handle.
     * 
     * Exception Handling
     * An exception is a class that derives from the System.Exception class.   The System.Exception class 
     * has several useful properties, that provide valuable information about the exception.
     * Message: Gets a message that describes the exception
     * Stack Trace: Provides the call stack to the line number in the method where the exception occured.
     * 
     * Exceptions are used in descending order. The Exception base class is used as a catch-all
     * 
     * try
     * {
     * 
     * }
     * catch (ArgumentNullException ex)
     * {
     * Log.Error(ex);
     * }
     * catch (ArgumentOutOfRangeException ex)
     * {
     * Log.Error(ex);
     * }
     * catch (Exception ex)
     * {
     * WriteLine($"Operation is not supported. {ex}");
     * }
     * finally
     * {
     *   WriteLine(" Finally always executes regadless if there was an exception ");
     *   Dispose();
     *   OtherCleanup();
     * }
     * 
     * 
     * System.Exception base class
     * System.Exception constructors
     * - public Exception()
     * - public Exception(string message)
     * - public Exception(string message, Exception innerException)
     * 
     * Exception and System Exception: Base Classes. Do not throw, Do not catch (except in top level handlers).
     *                                 Do not catch in framework code unless rethrowing.
     * SystemException is also a Base class for exceptions in system namespace.
     * 
     * - FileNotFoundException  - Inherits from IOException; IOException inherits from SystemException; 
     *                            SystemException inherits from Exception class.
     *                            
     *  Press Control-Alt-E to list all .Net exceptions
     *  
     *  There are a variety of different exceptions, it is not possible to guard against all exceptions.
     *  It is good to include the most commmon exceptions but at the end it is good to include the base
     *  Exception to serve as a 'catch all' for any unguarded exceptions.
     *  
     *  *****************************************************************************
     *  Releasing System Resources
     *  We use try, catch and finally blocks for exception handling
     *  try - The code that can possibly cause an exception will be in the try block.
     *  catch - Handles the exception.
     *  finally - Clean and free resources that the class was holding onto during the program execution.
     *            Finally Block is optional.
     *            
     *  Note: It is good practice to always release resources in the finally block, because finally
     *        block is guaranteed to execute, irrespective of whether there is an exception or not.
     *        
     *  The try-catch-finally block allows a program to catch unexpected errors and handle them.
     *  This block consists of three sections: a try section, one or more catch sections, and a finally
     *  section.  The "try" section is required, and you must include at least one 'catch' or 'finally'
     *  section.  Although, you don't need to include both, and you don't need to include any code inside
     *  the 'catch' or 'finally' section.   You can nest other try-catch-finally (Wow! you can have 2 
     *  finally blocks.)  sequences inside a 'try' section to catch errors without leaving the original
     *  try section.
     *  
     *  Note: You should only catch exceptions you know about.   The reason being is that some other routine
     *  may catch the exception.   Your program should only have one 'catch all' exception and it should be at the
     *  top of your program.   Exceptions are handled in a LIFO (Last In First Out) manner.
     *  
     *  Note: only the code in the 'try' section of a try-catch-finally block is protected by the block.
     *  If an exception occurs inside a 'catch' or 'finally' section, the exception is not caught
     *  by the block.
     *  
     *  You can nest another try-catch-finally block inside a 'catch' or 'finally' section to protect
     *  the program from errors in those places.  That can make the code rather cluttered, however, so
     *  in some cases it may be better to move the risky code into another method that includes its 
     *  own error handling.
     *        
     *  https://www.youtube.com/watch?v=WxdSb3ZCWYc&index=40&list=PLAC325451207E3105
     *  
     *  Use GetType() Method to determine the type of exception
     *  Use StackTrace  to find line number
     *  
     *  Also - Use Debug to determine type of exception and see Stack Trace
     *  
     *  Inner Exceptions
     *  https://www.youtube.com/watch?v=MO3sOTWfZPc&list=PLAC325451207E3105&index=41
     *  
     *  *******************************************************************************************
     *  Custom Exceptions
     *  
     *  https://www.youtube.com/watch?v=9qHb-2Edg7o&index=42&list=PLAC325451207E3105
     *  - Are necessary whenever we don't have an exception, that adequately describes the problem.  Within the
     *    .Net Framework we don't have an exception that defines the situation.  An Exception is nothing more than
     *    a class.
     *   1.The first step in creating a Custom Exception is to create a class that inherits from 
     *     the base Exception class (or the parent class to inherit all of it's functionality). 
     *   
     *   2.Provide a public constructor, that takes in a string parameter.  This constructor simply passes the
     *     string parameter, to the base exception class constructor.
     *     
     *   3.Using InnerExceptions, you can also track back the original exception.  If you want to provide this
     *     capablity for your custom exception class, then overload the constructor accordingly.
     *     
     *   4.If you want your Exception class object to work across appication domains, then the object must be
     *     serializable.  To make your exception class serializable mark it with the Serializable attribute and
     *     provide a constructor that invokes the base Exception class constructor that takes in SerializtionInfo
     *     and StreamingContext objects as parameters.
     *     
     ****************************************************************************************************************
     * Throw versus Throw ex
     * 1. throw does not  modify(or preserves)  the callstack
          or preserves the stack trace information
          throws to the next level.   So the throw simulates logging the exception.  The runtime then will handle
          until it finds some code that will handle the exception.  The program then lands there for the progrmam to 
          deal with.
        
       2.  If you were to throw ex - you would lose stack trace information.  'Throw ex' throws a new exception instead
           of throwing the original exception.

       3.  throw new ArithmeticException()
           could be any exception but written in this format you will lose stack trace information.
           
       4.  throw new AritmeticExcption("Inner Excpetion",ex)
           ex is the Inner Exception
        
     *****************************************************************************************************************
     * Global Exception Handler
     * 
     * Do not try to catch all errors.  Only try to catch those errors you are anticipating and then let the Global
     * Exception Handler handle the rest.
     *  
     * Global exception handler is your applications safety net allowing your exceptions to fall through.  The syntax
     * for a global exception handler is different depending on the application.  A console and Web application will have
     * a different syntax for the global exception handler.
     * 
     * See Global Exception Handler in Program.cs
     */
    class ExceptionClassExamples
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Exception Handling ");
                Console.WriteLine(" 0.  Inner Exception \n ");
                Console.WriteLine(" 1.  Web Page \n ");
                Console.WriteLine(" 2.  Exception Message \n ");
                Console.WriteLine(" 3.  throw \n");
                Console.WriteLine(" 4.  throw2 \n");
                Console.WriteLine(" 5.  catch all Exception \n");
                Console.WriteLine(" 6.  Custom Exceptions \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: IEMain();
                        Console.ReadKey();
                        break;
                    case 1:
                        Process.Start("http://msdn.microsoft.com/en-us/library/ms173162.aspx");
                        ExceptionHandlingStatements();
                        break;
                    case 2: ECEMain();
                        break;
                    case 3:

                        ThrowExample();
                        Console.WriteLine("After Throw Example");
                        Console.ReadKey();
                        break;
                    case 4:
                        ThrowExample2();
                        Console.ReadKey();
                        break;
                    case 5:
                         CatchAll();
                         Console.ReadKey();
                         break;
                    case 6:
                        CustomExceptionDemo();
                        Console.ReadKey();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);  // end do

        }  // end Menu()

        static void IEMain()
        {
            try
            {
                try
                {
                    Console.WriteLine("Enter First Number");
                    int FN = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Second Number");
                    int SN = Convert.ToInt32(Console.ReadLine());

                    int Result = FN / SN;
                    Console.WriteLine("Result = {0}", Result);
                }
                catch (Exception ex)
                {
                    string filePath = @"C:\Users\olivarez\log1.txt";
                    if (File.Exists(filePath))
                    {
                        StreamWriter sw = new StreamWriter(filePath);
                        sw.Write(ex.GetType().Name);
                        sw.WriteLine();
                        sw.WriteLine(ex.Message);
                        sw.Close();
                        Console.WriteLine("There is a problem, problem logged in c:users.olivarez.log.txt");
                    }
                    else
                    /*
                     * Passing the exception as a parameter  (..,ex)
                     * Definition will look like below
                     * public FileNotFoundException(string message, Exception innerException);
                    */
                    {
                        throw new FileNotFoundException(filePath + "is not present", ex);
                    }
                } // end Catch
            }
            catch (Exception exception)
            {
                Console.WriteLine("Current Exception = {0}", exception.GetType().Name);
                Console.WriteLine("Inner Exception = {0}", exception.InnerException.GetType().Name);
            }


        }


        static void ExceptionHandlingStatements()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/s7fekhdy.aspx");
        }

        static void ECEMain()
        {
            string s = "hello";
            try
            {
                int i = int.Parse(s);
            }
            catch (Exception e1)
            {
                Console.WriteLine("Exception = " + e1.Message);
            }
            finally
            {
                Console.WriteLine("Finally Block ALWAYS Executes");
            }
        }

        static void ThrowExample()
        {
            try
            {
                string s = OpenandParse(null);
            }
            catch (ArgumentNullException)
            {
                //throw does not  modify the callstack
                //or preserves the stack trace information
                //throws to the next level.
                //
                // If you were to throw ex - you would lose stack trace information
                //
                throw;
            }
        }

        static void ThrowExample2()
        {
            try
            {
                string s = OpenandParse(null);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Argument null exception" + e.Message);
            }
        }

        static string OpenandParse(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename", "Filename is required");
            }
            return File.ReadAllText(filename);
        }

        static void CatchAll()
        {
            StreamReader streamreader = null;
            try
            {
                streamreader = new StreamReader(@"c:\Users\Olivarez\My Documents\Numbers.txt");
                //
                //  The below lines will not get executed if there is an exception, which is why it is 
                //  important to code a 'finally' block
                // 
                Debug.WriteLine("Char by Char");
                while (!streamreader.EndOfStream)
                {
                    Debug.WriteLine((char)streamreader.Read());
                }
                // streamreader.Close();  <-- Moved to Finally Block
                // The @ - tells the processor to not process escape sequences
                Debug.WriteLine("Char by Char written to output window");
                FileStream fileStream = new FileStream(@"c:\Users\Olivarez\My Documents\Numbers.txt",
                          FileMode.Create, FileAccess.Write, FileShare.None);
            }
            catch (FileNotFoundException ex)
            {
                //Log the details to the DB
                Console.WriteLine("Please check if the file {0} exists - type{1}", ex.FileName, ex.GetType().Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Message: {0} \n  Type: {1} \n\n ",ex.Message, ex.GetType().Name);
                Console.WriteLine("Stack Trace (gives you line number) : {0}", ex.StackTrace);
                
                   
            }
            /*
             * Finally Block always executed regardless if there was an exception
             * A 'Finally' Block is needed since if you have an exception embedded in an Exception block
             * e.g. Coudn't write to a log file then code will not get executed afterwards unless there
             * was a finally block.
            */
            finally
            {
                if (streamreader != null)
                {
                    streamreader.Close();
                    Console.WriteLine("Finally Block Executed ");
                }
                else
                    Console.WriteLine("\n Finally Block Executed -- Streamread is null");
            }
        }
        /*

         *  Custom Exceptions
         *  
         *  https://www.youtube.com/watch?v=9qHb-2Edg7o&index=42&list=PLAC325451207E3105
         *  - Are necessary whenever we don't have an exception, that adequately describes the problem.  Within the
         *    .Net Framework we don't have an exception that defines the situation.  An Exception is nothing more than
         *    a class.
         *   1.The first step in creating a Custom Exception is to create a class that inherits from 
         *     the base Exception class (or the parent class to inherit all of it's functionality). 
         *   
         *   2.Provide a public constructor, that takes in a string parameter.This constructor simply passes the
         *     string parameter, to the base exception class constructor.
         *     
         *   3.Using InnerExceptions, you can also track back the original exception.If you want to provide this
         *     capablity for your custom exception class, then overload the constructor accordingly.
         *
         *   4.If you want your Exception class object to work across appication domains, then the object must be
         *     serializable.To make your exception class serializable mark it with the Serializable attribute and
         *     provide a constructor that invokes the base Exception class constructor that takes in SerializtionInfo
         * and StreamingContext objects as parameters.
         */
        static void CustomExceptionDemo()
        {
            try
            {
                throw new UserAlreadyLoggedInException("User is logged in - no duplicate session allowed");
            }
            catch (UserAlreadyLoggedInException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [Serializable]
        public class UserAlreadyLoggedInException : Exception
        {
            public UserAlreadyLoggedInException() : base()
            {

            }
            public UserAlreadyLoggedInException(string message) : base(message)
            {
            }

            public UserAlreadyLoggedInException(string message, Exception InnnerException)
                : base(message, InnnerException)
            { }

            public UserAlreadyLoggedInException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {

            }
        }
    }
}
