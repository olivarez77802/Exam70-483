using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JesseTesting.App
{ 
    abstract class StringEquality
    {
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-comparison-operator

        // For reference types other than string, == returns true if its two operands refer to the same object.
        // For the string type, == compares the values of the strings.   So String is the only refernce type
        // that you can use == with.
        //
        // String implements IComparable<string>
        // 
        // IComarable versus IComparer 
        // IComparable as I’m comparable. which means I can be compared to another instance of the same type.
        //             - used for natural comparisons
        // IComparer as I’m a comparer, I simply compare which means I compare two instances. 
        //             - allows for plugging in alternative comparisons
        //             - Can do one thing, great example of single responsilibity principle 
        // Comparers are needed to sort collections, or anything else that needs to sort objects.
        // http://www.karthikscorner.com/sharepoint/icomparable-vs-icomparer-c/
        //
        // Comparer<T> Implements IComarer<T>
        // Writing a comparer for non-sealed classes is problematic
        // Consider using sealed class when writing a class to compare 
        //
        //

        internal static void SE_Main()
        {
            // Numeric equality: True
            Console.WriteLine((2 + 2) == 4);

            // Reference equality: different objects, 
            // same boxed value: False.
            object s = 1;
            object t = 1;
            Console.WriteLine(s == t);

            // Define some strings:
            string a = "hello";
            string b = String.Copy(a);
            string c = "hello";

            // Compare string values of a constant and an instance: True
            Console.WriteLine(a == b);

            // Compare string references; 
            // a is a constant but b is an instance: False.
            Console.WriteLine((object)a == (object)b);

            // Compare string references, both constants 
            // have the same value, so string interning
            // points to same reference: True.
            Console.WriteLine((object)a == (object)c);
        }
    }
}
