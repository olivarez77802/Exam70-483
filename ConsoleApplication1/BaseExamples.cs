using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JesseTesting.App
{
    // static - cannot ever be instantiated or use static if you do not want to create an instance
    // concrete - Types that can be instantiated.  Concrete types can inherit (or derive) from an abstract type
    //            and provide implementation for the abstract or virtual methods.
    // abstract - Incomplete class; must be completed in a derived class.  Also
    //            cannot be instantiated.   Will usually hold methods that are defined as either virtual
    //            or abstract.  Abstract classes are useful because of Polymorphism.  Abstract class can
    //            provide some implementation details.  This is a difference between them and Interfaces.
    //            Interfaces cannot provide implementation details.
    // inherit  - You can inherit from many interfaces.  You are restricted from inheriting from only one class whether it is abstract or concrete.
    // virtual - first implementation.   When you use the virtual keyword you enable Polymorphism
    //
    // public abstract class Window
    // {
    //   public virtual string Title { get; set; }
    //  
    //   public virtual void Draw()
    //   {
    //     ** Drawing Code
    //   }
    //
    //   public abstract void Open()    <-- Nested abstract means the class deriving from class Window must provide 
    //                                      an implmentation for the Open method.   
    // }
    // 
    // override - further implementation.  Keyword used in concrete classes to provide further implementations for methods
    //                                     that were defined as either virtual or abstract.
    // sealed - Final implementation - cannot be derived (or inherited).
    //        -  Examples of Sealed Classes are String Builder
    // making this class abstract means that I do not ever want this class 
    // to be instantiated.    However, the abstract class can be inherited and
    // the class that inherited the abstract class can be instantiated.  
    // struct - means you cannot derivefrom it.
    // 
    // Arrays are reference types
    // Array CoVariance - You can implicitly cast a Derive[] to a Base[] type
    // Example - Base Type is object and Dervied Type is String
    // Array CoVariance is broken because you cannot determine type, so you should
    // not use.
    // IEnumerable<T> and IEnumerator<T> use CoVariance and are good to use unlike 
    // Array CoVariance.
    // 
    // You can always cast a derived type to a base type
    // string is derived from object
    // string str = "Hello world"
    // object obj = str;
    //
    // However.  You cannot normally case a collection of a derived type to a collection of a base type
    // One exception is arrays, this will work for arrays.  This is called Array CoVariance.
    // Below not allowed    
    // var strList = new List<string> {"Monday","Tuesday"};
    // List<object> objList = strList;
    //
    // CoVariance is safe for enumerators because an enumerator can't modify the collection
    // The below will work.  Micorosft allows for the IEnumerable<T> and IEnumerator<T> interfaces.
    // var strList = new List<string> {"Monday", "Tuesday" };
    // IEnumerable<object> objEnum = strList;
    //
    // If you go to the definition of IEnumable
    // The 'out' keyword is what tells the compiler that the Interface can be treated as Covariant
    //
    // ...public interface IEnumerable<out T> : IEnumerable
    //    {
    //        ...IEnumerator<T> GetEnumerator();
    //    }
    static class BaseExamples   
    {
        #region TMain
        abstract class Person
        {
            private string ssn = "444-55-666";
            private string name = "Jesse Olivarez";
            // making this method virtual means that this method can be overridden.  A method
            // that is not marked virtual cannot be overriden.
            public virtual void GetInfo()
            {
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("SSN: {0}", ssn);
            }
        }
        class Employee : Person
        {
            public string id = "ABC567EFG";
            //override allows you to override a method that was made virtual.
            public override void GetInfo()
            {
                base.GetInfo();
                Console.WriteLine("Employee ID: {0}", id);
            }
        }
        
        public static void TMain()
        {
            Employee E = new Employee();
            E.GetInfo();
        }
        #endregion
        #region DMain

        public class BaseClass
        {
            int num;
            string baseString;
            public BaseClass()
            {
                Console.WriteLine("in BaseClass()");
            }
            public BaseClass(string myString)
            {
                baseString = myString;
                Console.WriteLine(baseString);
            }
            public BaseClass(int i)
            {
                num = i;
                Console.WriteLine(" in BaseClass(int i) is {0}", i);
            }
            public int GetNum()
            {
                return num;
            }
            public void print()
            {
                Console.WriteLine("I'm in a Parent Class ");
            }

        }
        public class DerivedClass : BaseClass
        {
            //This constructor will call BaseClass.BaseClass()
            public DerivedClass()
                : base()
            {
            }
            public DerivedClass(string MyString)
                : base("From Derived")
            {
                Console.WriteLine("Derived Constructor ");
            }
            //This constructor will call BaseClass.BaseClass(int i)
            public DerivedClass(int i)
                : base(i)
            {
            }
            public new void print()
            {
                base.print();
                Console.WriteLine("I'm in a Derived Pring class");
            }
           
        }

        public static void D_Main()
        {
            DerivedClass md = new DerivedClass();
            DerivedClass md1 = new DerivedClass(1);
            md.print();
            DerivedClass md3 = new DerivedClass("Jesse");
            ((BaseClass)md3).print();
        }
        #endregion
    }
}
