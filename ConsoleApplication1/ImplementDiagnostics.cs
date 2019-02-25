#define ConsoleTrace
// #define StreamTrace
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
           
             
            Init_Trace();
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Implement Diagnostics in an Application \n ");
                Console.WriteLine(" - Implement Logging and Tracing; Profiling Applications; ");
                Console.WriteLine(" - Create and Monitor Performance Counters; write to the event log ");
                Console.WriteLine(" 0.  Implement Logging and Tracing \n ");
                Console.WriteLine(" 1.  Profiling Applications  \n ");
                Console.WriteLine(" 2.  Create and monitor performanance counters \n ");
                Console.WriteLine(" 3.  Write to Event Log \n ");
                Console.WriteLine(" 4.  Listeners");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        Trace.WriteLine(" Calling Implement Tracing and  Logging");                    
                        Console.ReadKey();
                        break;
                    case 1:
                        Trace.WriteLine(" Calling Profiling Applications");
                      
                        break;
                    case 2:
                        Trace.WriteLine(" Calling Monitor and Performance Counters ");
                        Performance_Counters();
                        Console.ReadKey();
                        break;
                    case 3:
                        Trace.WriteLine(" Calling Event Log");
                        Event_Viewer();
                        Console.ReadKey();
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
#if ConsoleTrace
            ConsoleTraceListener traceListener =
               new ConsoleTraceListener();
#elif StreamTrace
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
#endif
            
            Trace.Listeners.Add(traceListener);

            //write a startup note into the trace file
            Trace.WriteLine("Trace started " + DateTime.Now.ToString());
        }
        static void Performance_Counters()
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
        }
        static void Event_Viewer()
        {
            /*
             * Go to Start Menu and type in 'Event Viewer' to open Desktop App
             * Open Directory 'Applications and Service Logs'
             * You should find 'Exam70483'.
            */
            string source = "OrderMaker";
            string log = "Exam70483";
            string message = "Created new order 120192";
            int id = 1001;

            //Create the source if necessary. (Requires admin privelage)
            if (!EventLog.SourceExists(source))
                EventLog.CreateEventSource(source, log);

            // Write the log entry.
            EventLog.WriteEntry(source, message, EventLogEntryType.Information, id);

            Console.ReadKey();

        }
        static void Listeners()
        {
            /*
             Both the Debug and Trace Classes have a Listeners collection that hold references to listener objects.
             1. ConsoleTraceListener : Sends output to Console Window.
             2. EventLogTraceListener : Sends output to an event log.
             3. TextWriterTraceListener : Sends output to a stream such as a FileStream.  This lets you write output
                                          to any file.
            */
            Console.ReadKey();
        }

    }
}
