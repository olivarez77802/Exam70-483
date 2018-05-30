using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    /*
     * See also ThreadingExamples.cs
     * 
     * Race condition - Results are sensitive to precise timing of threads
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
     *    
     */
    class ConcurrentCollections
    {
    }
}
