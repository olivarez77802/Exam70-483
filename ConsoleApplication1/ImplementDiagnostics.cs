using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    class ImplementDiagnostics
    {
        public static void Menu()
        {
            /* Implement logging and tracing; 
             * profiling applications;
             * create and monitor performance counters;
             * write to the event log
             *
             * https://www.youtube.com/watch?v=ypdnMpR5jZ8  
             * 
             * 
             *  Video uses Performance Monitor
             *   https://www.youtube.com/watch?v=No7QqSc5cl8
             * 
             * Go to Start and type 'Performance Monitor'
             * -- Lots of Documentation
             * 
             * 
             */
             
            Init_Trace();
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Implement Diagnostics in an Application \n ");
                Console.WriteLine(" - Implement Logging and Tracing; profiling applications; ");
                Console.WriteLine(" - create and monitor performance counters; write to the event log ");
                Console.WriteLine(" 0.  Implement Logging and Tracing \n ");
                Console.WriteLine(" 1.  Profiling Applications  \n ");
                Console.WriteLine(" 2.  Create and monitor performanace counters \n ");
                Console.WriteLine(" 3.  Write to Event Log \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        Trace.WriteLine(" Calling Implement Logging");                    
                        Console.ReadKey();
                        break;
                    case 1:
                        Trace.WriteLine(" Calling Profiling Applications");
                        break;
                    case 2:
                        Trace.WriteLine(" Calling Monitor and Performance Counters ");
                        break;
                    case 3:
                        Trace.WriteLine(" Calling Event Log");
                        break;
                    case 4:
                        Console.ReadKey();
                        break;
                    case 9:
                        x = 9;
                        Trace.Flush();
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);
        }
        static void Init_Trace()
        {
            // Create the trace output file
            // Stored in C:\Users\olivarez77802\Documents\Visual Studio 2015\Projects\GitRemoteRepositories\ConsoleApplication1\ConsoleApplication1\bin\Debug
            Stream traceStream = File.Create("TraceFile.txt");
            //Alternative - to append new text at end of file
            // Stream traceStream = File.Open("TraceFile.txt",
            //        FileMode.Append, FileAccess.Write, FileShare.Read);
            //

            // Create a TextWriterTraceListener for the trace output file.
            TextWriterTraceListener traceListener =
                new TextWriterTraceListener(traceStream);
            Trace.Listeners.Add(traceListener);

            //write a startup note into the trace file
            Trace.WriteLine("Trace started " + DateTime.Now.ToString());
        }
    }
    }
}
