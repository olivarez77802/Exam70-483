﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Exam70483
{
    /*
     * Thread represents an actual OS-level thread, with its own stack and kernel resources. (technically, a CLR implementation 
     * could use fibers instead, but no existing CLR does this) Thread allows the highest degree of control; you can Abort()
     *  or Suspend() or Resume() a thread (though this is a very bad idea), you can observe its state, and you can set 
     *  thread-level properties like the stack size, apartment state, or culture. The problem with Thread is that OS threads 
     *  are costly. Each thread you have consumes a non-trivial amount of memory for its stack, and adds additional CPU overhead 
     *  as the processor context-switch between threads. Instead, it is better to have a small pool of threads execute your code
     *  as work becomes available.   There are times when there is no alternative Thread. If you need to specify the name
     * (for debugging purposes) or the apartment state (to show a UI), you must create your own Thread (note that having 
     * multiple UI threads is generally a bad idea). Also, if you want to maintain an object that is owned by a single thread 
     * and can only be used by that thread, it is much easier to explicitly create a Thread instance for it so you can easily
     * check whether code trying to use it is running on the correct thread.
     * 
     * ThreadPool
     * 
     * ThreadPool is a wrapper around a pool of threads maintained by the CLR. ThreadPool gives you no control at all; 
     * you can submit work to execute at some point, and you can control the size of the pool, but you can't set anything else.
     * You can't even tell when the pool will start running the work you submit to it.  Using ThreadPool avoids the overhead
     * of creating too many threads. However, if you submit too many long-running tasks to the threadpool, it can get full, 
     * and later work that you submit can end up waiting for the earlier long-running items to finish. In addition, the 
     * ThreadPool offers no way to find out when a work item has been completed (unlike Thread.Join()), nor a way to get 
     * the result. Therefore, ThreadPool is best used for short operations where the caller does not need the result.
     * 
     * All threads from the thread pool are background threads, whereas the manually created threads are foreground threads
     * by default (but can be set as background threads as well).
     * 
     * Task
     * 
     * Finally, the Task class from the Task Parallel Library offers the best of both worlds. Like the ThreadPool, a task does
     * not create its own OS thread. Instead, tasks are executed by a TaskScheduler; the default scheduler simply runs 
     * on the ThreadPool.
     * 
     * Unlike the ThreadPool, Task also allows you to find out when it finishes, and (via the generic Task) to return a result.
     * You can call ContinueWith() on an existing Task to make it run more code once the task finishes (if it's already finished,
     * it will run the callback immediately). If the task is generic, ContinueWith() will pass you the task's result, 
     * allowing you to run more code that uses it.
     * 
     * You can also synchronously wait for a task to finish by calling Wait() (or, for a generic task, by getting the 
     * Result property). Like Thread.Join(), this will block the calling thread until the task finishes. Synchronously
     * waiting for a task is usually bad idea; it prevents the calling thread from doing any other work, and can also lead 
     * to deadlocks if the task ends up waiting (even asynchronously) for the current thread.
     * 
     * Since tasks still run on the ThreadPool, they should not be used for long-running operations, since they can still 
     * fill up the thread pool and block new work. Instead, Task provides a LongRunning option, which will tell the 
     * TaskScheduler to spin up a new thread rather than running on the ThreadPool.
     * 
     * All newer high-level concurrency APIs, including the Parallel.For*() methods, PLINQ, C# 5 await, and modern async 
     * methods in the BCL, are all built on Task.
     * 
     * Conclusion
     * 
     * The bottom line is that Task is almost always the best option; it provides a much more powerful API and avoids wasting
     * OS threads.  The only reasons to explicitly create your own Threads in modern code are setting per-thread options,
     * or maintaining a persistent thread that needs to maintain its own identity.
     *
     * https://stackoverflow.com/questions/13429129/task-vs-thread-differences
     * 
     * 
     */
    class ThreadPoolExample
    {
        public static void Method()
        {
            int maxThreads;
            int minThreads;
            int avaThreads;

            int comp1;
            int comp2;
            int comp3;

            ThreadPool.GetMaxThreads(out maxThreads, out comp1);
            Console.WriteLine("The Max Number of Threads: {0}", maxThreads);

            ThreadPool.GetMinThreads(out minThreads, out comp2);
            Console.WriteLine("The Min Number of Threads: {0}", minThreads);

            ThreadPool.GetAvailableThreads(out avaThreads, out comp3);
            Console.WriteLine("The number of available Threads: {0}", avaThreads);
            
        }
    }
}
