
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483
{
    // static - cannot ever be instantiated
    // base class types to override - abstract and virtual
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
    // Difference between virtual and abstract.  Abstract methods must be overriden. Overriding virtual methods is optional.
    // sealed - Final implementation - cannot be derived (or inherited).
    //        -  Examples of Sealed Classes are String Builder
    //        - If you want to make sure no one overrides or extends the functionality of a class then mark it as sealed.
    // making this class abstract means that I do not ever want this class 
    // to be instantiated.    However, the abstract class can be inherited and
    // the class that inherited the abstract class can be instantiated.  
    // Struct versus Classes - Same as saying Value versus Reference Types.  See TypeSystem.cs for info on Classes versus Structs.
    // 
    // See InterfacesMenu.cs   -  has more information on Arrays versus Lists
    // See ConsumeTypes.cs - Information on casting
    
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
