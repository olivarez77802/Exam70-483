using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam70483
{
    class ManageMultithreading
    {
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Manage Mulithreading - Synchronize resources; implement locking; cancel a long-running task; \n ");
                Console.WriteLine(" Implement thread-safe methods to handle race conditions. \n ");
                Console.WriteLine(" 0.  Threading Examples");
                Console.WriteLine(" 1.  CancellationTokenSource with Task.Factory");
                Console.WriteLine(" 2.  CancellationTokenSource with TaskFactory");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        ThreadingExamples.Menu();
                        Console.ReadKey();
                        break;
                    case 1:
                        CancellationTokenSource_wTask();
                        Console.ReadKey();
                        break;
                    case 2:
                        CancellationTokenSource_wTaskFactory();
                        Console.ReadKey();
                        break;
                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);
        }
        static void CancellationTokenSource_wTask()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            var t = Task.Factory.StartNew(() =>
            {
                foreach (var item in
                    Enumerable.Range(0, 100).AsParallel().WithCancellation(ct).Select(i => i).Where(i => i % 5 == 0))
                {
                    Console.WriteLine(" Example of Cancellation Token item is {0}", item);
                }
            }, ct);

            // May have to Comment out or change time on Thread.Sleep if you want it to cancel, otherwise it will finish before the cancel is called.
            // Thread.Sleep(100) will usaully be enough time for it to run start to finish.
            // Thread.Spleed(10) will usually cause cts.Cancel() to be called.
            Thread.Sleep(10);
            cts.Cancel();
            /* Example Output  - Output may be different each time because of .AsParallel
            Example of Cancellation Token item is 0
            Example of Cancellation Token item is 45
            Example of Cancellation Token item is 5
            Example of Cancellation Token item is 55
            Example of Cancellation Token item is 10
            Example of Cancellation Token item is 65
            Example of Cancellation Token item is 15
            Example of Cancellation Token item is 85
            Example of Cancellation Token item is 20
            Example of Cancellation Token item is 95
            Example of Cancellation Token item is 25
            Example of Cancellation Token item is 30
            Example of Cancellation Token item is 35
            Example of Cancellation Token item is 40
            Example of Cancellation Token item is 50
            Example of Cancellation Token item is 60
            Example of Cancellation Token item is 70
            Example of Cancellation Token item is 75
            Example of Cancellation Token item is 80
            Example of Cancellation Token item is 90
            */
        }
        static void CancellationTokenSource_wTaskFactory()
        {
            /*
            Attained from
            https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=netframework-4.7.2

            The following example uses a random number generator to emulate a data collection application that reads
            10 integral values from eleven different instruments.  A value of zero indicates that the measurement
            has failed for one instrument, in which case the operation should be cancelled and no overall mean should
            be computed.    You will have to run multiple times in order for the mean to get computed.            
            */
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Random rnd = new Random();
            Object lockObj = new object();
            /*
              Cancellation token is passed to a TaskFactory object.
              The Task Factory object in turn passes the cancellation token
              to each of the tasks responsible for collecting readings for a 
              particular instrument.
            */
            List<Task<int[]>> tasks = new List<Task<int[]>>();
            TaskFactory factory = new TaskFactory(token);
            for (int taskCtr = 0; taskCtr <= 10; taskCtr++)
            {
                int iteration = taskCtr + 1;
                tasks.Add(factory.StartNew(() =>
                {
                    int value;
                    int[] values = new int[10];
                    for (int ctr = 1; ctr <= 10; ctr++) { 
                    {
                        lock (lockObj)
                            value = rnd.Next(0, 101);
                    }
                    if (value == 0) {
                            source.Cancel();
                            Console.WriteLine("Cancelling at task {0}", iteration);
                            break;
                        }
                        values[ctr - 1] = value;
                    }
                    return values;
                }, token));

            }
            /* 
             * Once the above is done, it will either go in the try or the catch block.  If the above
             * completed successfully it will go to the try block.  If it got cancelled it will go to 
             * the catch block.
             * 
             * The TaskFactory.ContinueWhenAll method is called to ensure that the mean is computed only
             * after all the readings have been gathered successfully.   If a task has not because it has
             * been cancelled, the call to the TaskFactory.ContinueWhenAll method throws an exception.  
             * Notice the catch block uses the InnerException.
             */
            try
            {
                Task<double> fTask = factory.ContinueWhenAll(tasks.ToArray(),
                                                            (results) =>
                                                            {
                                                                Console.WriteLine("Calculating overall mean..");
                                                                long sum = 0;
                                                                int n = 0;
                                                                foreach (var t in results)
                                                                {
                                                                    foreach (var r in t.Result)
                                                                    {
                                                                        sum += r;
                                                                        n++;
                                                                    }
                                                                }
                                                                return sum / (double)n;
                                                            }, token);
                Console.WriteLine("The mean is {0}.", fTask.Result);
                    
            }
            catch(AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Unable to compute mean: {0}", ((TaskCanceledException)e).Message);
                    else
                        Console.WriteLine("Exception: " + e.GetType().Name);
                }
            }
        }
    }
}
