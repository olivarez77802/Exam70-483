using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483
{
    class DelegateExamples
    {
        delegate void CustomDel(string s);
        delegate int Countit(int x);

        //Define two methods that have the same signature as CustomDel.
        static void Hello(string s)
        {
            System.Console.WriteLine("  Hello, {0}!", s);
        }
        static void Goodbye(string s)
        {
            System.Console.WriteLine("  Goodbye, {0}!", s);
        }
        public static void TCMain()
        {
            //delegate void CustomDel(string s);
            // Declare instances of the custom delegate.
            CustomDel hiDel, byeDel, multiDel, multiMinusHiDel;

            //In this example, you can omit the custom delegate if you
            //want to and use Action<string> instead.
            //Action<string> hiDel, byeDel, multiDel, multiMinusHiDel;

            //Create the delegate object hiDel that references the 
            //method Hello.
            hiDel = Hello;

            //Create the delegate object byeDel that references the 
            //method Goodbye.
            byeDel = Goodbye;

            //The two delegates, hiDel and byeDel, are combined to 
            //form multiDel.
            multiDel = hiDel + byeDel;

            //Remove hiDel from the multicast delegate, leaving byeDel,
            //which calls only the method Goodbye.
            multiMinusHiDel = multiDel - hiDel;

            Console.WriteLine("Invoking delegate hiDel: ");
            hiDel("A");
            Console.WriteLine("Invoking delegate byeDel: ");
            byeDel("B");
            Console.WriteLine("Invoking delegate multiDel: ");
            multiDel("C");
            Console.WriteLine("Invoking delegate mulitMinusHiDel: ");
            multiMinusHiDel("D");
        }

        public static void Lambda_Main()
        {
            /* Explicit typing for Lambda Expression, the parameter x has to be int since it has to match the 
               type for Countit
             */
            Countit testDel = (int x) => x + 5;
            int result = testDel(5);
            Console.WriteLine(result);
            /* Implicit typing for Lambda Expression, no type is specified for parmater x since it gets its
             * type from Countit.
             */
            Countit testDel2 = (x) => x + 5;
            int result2 = testDel2(5);
            Console.WriteLine(result);

            
        }


    }
}
