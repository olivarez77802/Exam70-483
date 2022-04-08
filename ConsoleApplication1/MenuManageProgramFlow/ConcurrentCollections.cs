using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483.MenuManageProgramFlow
{
    /*
     * See also ThreadingExamples.cs; ThreadPoolExamples.cs
     * 
     * Race condition - Results are sensitive to precise timing of threads.  To avoid race condition make data read-only.
     * 
     * Concurrent collections will protect you from:
     *    Internal Data Corruption
     *    Race Conditions inside method calls
     * but won't protect you from
     *    Race conditions between method calls
     *    
     *  What Concurrent Collections are there:
     *    Concurrent Dictionary<TKey, TValue>
     *    ConcurrentQueue<T>
     *    ConcurrentStack<T>
     *    ConcurrentBag<T>
     *    
     *  Concurrent Dictionary is really the only choice, Concurrent Queue,Stack, Bag are very specially and will rarely be used.
     *  You can use a Dictionary to replace almost all Collections. 
     *  
     *  On one thread: Concurrent Dictionary is massively slower than Dictionary.
     *  Don't use concurrent collections unless you really need the thread safety.
     *  A lot of resources are tied up when using the Concurrent Dictionary, sometimes
     *  it makes more sese to use the regular Dictionary. 
     *       
     *    
     */
    class ConcurrentCollections
    {
    }
}
