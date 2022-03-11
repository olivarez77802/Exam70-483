using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Exam70483
{
    public class GenericExamples
    {

        /*
         *  Generics overview

    Use generic types to maximize code reuse, type safety, and performance.
    The most common use of generics is to create collection classes.
    The .NET class library contains several generic collection classes in the System.Collections.Generic namespace.
    These should be used whenever possible instead of classes such as ArrayList in the System.Collections namespace.
    See more information on ArrayList in Collections.cs
    You can create your own generic interfaces, classes, methods, events, and delegates.
    Generic classes may be constrained to enable access to methods on particular data types.
    Information on the types that are used in a generic data type may be obtained at run-time by using reflection.

    Advantages and DisAdventages of using Generics
    https://docs.microsoft.com/en-us/dotnet/standard/generics/
    Advantages and disadvantages of generics
    There are many advantages to using generic collections and delegates:
    Type safety. Generics shift the burden of type safety from you to the compiler. There is no need to write code to test 
    for the correct data type because it is enforced at compile time. The need for type casting and the possibility of run-time 
    errors are reduced.   Less code and code is more easily reused. There is no need to inherit from a base type and override members. 
    For example, the LinkedList<T> is ready for immediate use. For example, you can create a linked list of strings with the 
    following variable declaration:
     C#
     LinkedList<string> llist = new LinkedList<string>();

     Better performance. Generic collection types generally perform better for storing and manipulating value types because there
     is no need to box the value types.  Generic delegates enable type-safe callbacks without the need to create multiple delegate
     classes. For example, the Predicate<T> generic delegate allows you to create a method that implements your own search criteria
     for a particular type and to use your method with methods of the Array type such as Find, FindLast, and FindAll.
     Generics streamline dynamically generated code. When you use generics with dynamically generated code you do not need to 
     generate the type. This increases the number of scenarios in which you can use lightweight dynamic methods instead of generating 
     entire assemblies. For more information, see How to: Define and Execute Dynamic Methods and DynamicMethod.

The following are some limitations of generics:

    Generic types can be derived from most base classes, such as MarshalByRefObject (and constraints can be used to require that 
    generic type parameters derive from base classes like MarshalByRefObject). However, .NET does not support context-bound generic 
    types. A generic type can be derived from ContextBoundObject, but trying to create an instance of that type causes a 
    TypeLoadException.

    Enumerations cannot have generic type parameters. An enumeration can be generic only incidentally (for example, because it is
    nested in a generic type that is defined using Visual Basic, C#, or C++). For more information, see "Enumerations" in Common 
    Type System.

    Lightweight dynamic methods cannot be generic.

   In Visual Basic, C#, and C++, a nested type that is enclosed in a generic type cannot be instantiated unless types have been 
   assigned to the type parameters of all enclosing types. Another way of saying this is that in reflection, a nested type that 
   is defined using these languages includes the type parameters of all its enclosing types. This allows the type parameters of 
   enclosing types to be used in the member definitions of a nested type. For more information, see "Nested Types" in MakeGenericType.

    System.Collections.Generic NameSpace
      Many of the generic collection types are direct analogs of nongeneric types. Dictionary<TKey,TValue>
      is a generic version of Hashtable; it uses the generic structure KeyValuePair<TKey,TValue> for enumeration
      instead of DictionaryEntry.
      List<T> is a generic version of ArrayList. There are generic Queue<T> and Stack<T> classes that correspond 
      to the nongeneric versions.
      There are generic and nongeneric versions of SortedList<TKey,TValue>. Both versions are hybrids of a dictionary
      and a list. The SortedDictionary<TKey,TValue> generic class is a pure dictionary and has no nongeneric counterpart.
      The LinkedList<T> generic class is a true linked list. It has no nongeneric counterpart.
   
   Generic Collections
   https://www.youtube.com/watch?v=sXdAsfbiTjc

   List Generic Collection
   List<T> is a generic version of ArrayList.
   https://www.youtube.com/watch?v=gXyoJA579QI



 * 
 * Benefits of using Generics
 *    Compile-time checking
 *    Reduces boxing of values
 *    
 * T - Type   
 * Use T as the type parameter for classes with one parameter.
 * 
 * Prefix descriptive type parameter names with T
 * Ex.  public class OpResult<TResult, TMessage>   
 * 
 * Genric Constraints - limits the types on parameters.
 * Where T : struct                -- Value Type
 * Where T : class                 -- Reference Type
 * Where T : new()                 -- Type with parameterless constructor
 * Where T : vendor                -- Be or derive from a vendor class
 * where T : IVendor               -- Be or implement the IVendor interface
 * 
 * ------------------------------------------------------
 * Generic Contraint Syntax - Class signature
 * struct - limits the arguments to value types
 *  where T - defines the parameter name
 * public class OperationResult<T> where T : struct
 * 
 * Example - Calling generic
 * var operationResult = new OperationResult<decimal>();
 * var operationResult = new OperationResult<bool>();
 * 
 *  
 * ------------------------------------------------------
 * public <T> Populate<T>(string sql) where T: class, new()
 * {
 *   T instance = new T();
 *   // Code to populate an object
 *   return instance;
 * } 
 * 
 * Generic Constraint syntax - Method Signature
 * public T RetrieveValue<T, V>(string sql, V parameter) where T : struct
 *                                                       where V : struct
 *                                                       
 * Populate<T>  could be interpreted as everthing in the class or struct is defined as type T.
 * https://www.tutorialsteacher.com/csharp/csharp-generics
 *                                                       
 */
        #region GA_Main()
        public static void GA_Main()
        {
            int[] arr = { 0, 1, 2, 3, 4 };
            List<int> list = new List<int>();

            for (int x = 5; x < 10; x++)
            {
                list.Add(x);
            }

            ProcessItems<int>(arr);
            ProcessItems<int>(list);
            char[] carr = { 'a', 'b', 'c', 'd' };
            ProcessItems<char>(carr);



        }
        static void ProcessItems<T>(IList<T> coll)
        {
            // IsReadOnly returns True for the array and False for the List.
            System.Console.WriteLine
                ("IsReadOnly returns {0} for this collection.",
                coll.IsReadOnly);

            // The following statement causes a run-time exception for the  
            // array, but not for the List. 
            //coll.RemoveAt(4); 

            foreach (T item in coll)
            {
                System.Console.Write(item.ToString() + " ");
            }
            System.Console.WriteLine();
        }
        #endregion
        #region Tester_Main
        class MyGenericArray<T>
        {
            private T[] array;
            public MyGenericArray(int size)
            {
                array = new T[size + 1];
            }

            public T getItem(int index)
            {
                return array[index];
            }

            public void setItem(int index, T value)
            {
                array[index] = value;
            }
        }


        static void Tester_Main()
        {

            //declaring an int array
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);

            //setting values
            for (int c = 0; c < 5; c++)
            {
                intArray.setItem(c, c * 5);
            }

            //retrieving the values
            for (int c = 0; c < 5; c++)
            {
                Console.Write(intArray.getItem(c) + " ");
            }

            Console.WriteLine();

            //declaring a character array
            MyGenericArray<char> charArray = new MyGenericArray<char>(5);

            //setting values
            for (int c = 0; c < 5; c++)
            {
                charArray.setItem(c, (char)(c + 97));
            }

            //retrieving the values
            for (int c = 0; c < 5; c++)
            {
                Console.Write(charArray.getItem(c) + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
        #endregion
        #region Swap_Main
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        static void Swap_Main()
        {
            int a, b;
            char c, d;
            a = 10;
            b = 20;
            c = 'I';
            d = 'V';

            //display values before swap:
            Console.WriteLine("Int values before calling swap:");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("Char values before calling swap:");
            Console.WriteLine("c = {0}, d = {1}", c, d);

            //call swap
            Swap<int>(ref a, ref b);
            Swap<char>(ref c, ref d);

            //display values after swap:
            Console.WriteLine("Int values after calling swap:");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("Char values after calling swap:");
            Console.WriteLine("c = {0}, d = {1}", c, d);

            Console.ReadKey();
        }
        #endregion
        #region Generic_Constraints
        //https://www.youtube.com/watch?v=aGvmqtfFjOw   -- Generic Constraints
        class ClassOne { public ClassOne() { } }
        class ClassTwo { public ClassTwo(int i, char c) { } }
        class Generic_Constraints_MainClass
        {
            public static T ProduceA<T>() where T : new()
            //
            // new() indicates a parameterless constructor is required
            // -- Could also say 
            // public static T ProduceA<T>() where T: ClassOne, new() 
            // ClassOne put the reguirement that T must inherit from ClassOne
            //
            {
                T returnval = new T();
                return returnval;
            }
        }
        #endregion

        //Func, Action, Predicate are examples of calling Generics
        public static void Same_Main()
        {
            List<string> names = new List<string>();
            names.Add("sekhar");
            names.Add("srinivas");
            names.Add("sri");

            string result = names.Find(SearchName);
            if (result == null)
                Console.WriteLine("Name not found..");
            else
                Console.WriteLine("Name found...");

            // Example of Anonymous Method ...Does same as above
            string result2 = names.Find(
                delegate(string name)
                {
                    return name.Equals("sekhar");
                }
            );
            if (result2 == null)
                Console.WriteLine("Anonymous..Name not found..");
            else
                Console.WriteLine("Anonymous..Name found...");

            /*
             Example of Lambda Expression ...Does same as above
             Lambda - Input parameter goes to Expression
             Input parameter (string name)
             Exression return name.Equals("sekhar")'
            */
            string result3 = names.Find
                (name => name.Equals("sekhar"));

            if (result3 == null)
                Console.WriteLine("Lambda..Name not found..");
            else
                Console.WriteLine("Lambda..Name found...");

           /*
             Differences between Function / Action / Predicate.  Func and Predicate can only return
             one value, the type is to the far right.  Predicate the return type is always boolean but
             is optional.
            
             Func:  A delegate for a function that may or may not take 
              parameters and return a value.
             Func <string, bool> - far right in this case bool is the return type
              left is the parameters.  Can have more than one parameter.
            
             Action: A delegate for a function that may or may not take
                     parameters and does NOT return a value.
            
             Predicate: A specialized version of a Func that takes an argument
                        evaluates a value against a set of criteria and always returns
                        a boolean value as a results.   Nice thing about Predicate is that 
                        the return type of Boolean does not have to be a parameter.  Func can
                        similate a Predicate but the return type of boolean must be included as the
                        last parameter.
            */


            Func<string, bool> fn = SearchName;
            bool result4 = fn("sekhar");
            if (result4 == false)
                Console.WriteLine("Function...Name not found..");
            else
                Console.WriteLine("Function...Name found...");

            //Predicate returns true or false
            Predicate<string> pred = delegate(string name)
            {
                return name.Equals("sekhar");
            };
            if (pred("sekhar") == false)
                Console.WriteLine("Predicate ...Name not found..");
            else
                Console.WriteLine("Predicate...Name found...");

            /*
            Predicate with Lamda
            Predicate<string> pred2 = names.Find(name => name.Equals("sekhar"));
            if (pred2("sekhar") == false)
                Console.WriteLine("Predicate Lambda ...Name not found..");
            else
                 Console.WriteLine("Predicate Lambda...Name found..."); 
            */

        }
        private static bool SearchName(string name)
        {
            return name.Equals("sekhar");
        }



        public static void PrimaryMain()
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/512aeb7t.aspx");
            GenericExamples.GA_Main();
            Console.ReadKey();
            GenericExamples.Tester_Main();
            Console.ReadKey();
            GenericExamples.Swap_Main();
            GenericExamples.Generic_Constraints_MainClass.ProduceA<ClassOne>();
            // Since ClassTwo is not a parameterless constructor the below gives an error.
            //GenericExamples.Generic_Constraints_MainClass.ProduceA<ClassTwo>();
            GenericExamples.Same_Main();
        }

    }

}
