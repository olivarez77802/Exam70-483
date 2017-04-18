using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace JesseTesting.App
{
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
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: IEMain();
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
                //throws to the next level.
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
    }
}
