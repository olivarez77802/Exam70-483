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
                Console.WriteLine(" 1.  Cancel a long-running task");
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
                       // CancelTask();
                        CancelTask2();
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
        static void CancelTask()
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
            Thread.Sleep(10);
            cts.Cancel();

        }
        static void CancelTask2()
        {
            /*
            Attained from
            https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=netframework-4.7.2

            The following example uses a random number generator to emulate a data collection application that reads
            10 integral values from eleven different instruments.  A value of zero indicates that the measurement
            has failed for one instrument, in which case the operation should be cancelled and no overall mean should
            be computed            
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
            /* The TaskFactory.ContinueWhenAll method is called to ensure that the mean is computed only
             * after all the readings have been gathered successfully.  If a task has not because it has
             * been cancelled, the call to TaskFactory.ContinueWhenAll methods throws an exceptions.
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
