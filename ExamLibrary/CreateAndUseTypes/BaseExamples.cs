 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483
{
    /*
     Static Class - cannot ever be instantiated.  A static field is not recreated with each instance object.
                    See StaticExamples.cs for more info. on Static Classes;Static Methods; Static variables.
                    Since a static class will not have instances, it will not have getter and setters.
                    Static classes are sealed so cannot inherit from any class except object.

     Static and Sealed Classes
     A. Features of Static Class:
       1. It can only have static members.
       2. It cannot have instance members as static class instance cannot be created.
       3. It is a sealed class. As static class is sealed, so no class can inherit from a static class.
          We cannot create instance of static class that's the reason we cannot have instance members in static class,
          as static means shared so one copy of the class is shared to all. Static class also cannot inherit from other classes.
     B. The following are the points to keep in mind about sealed class:
      1. Sealed class can be instantiated.
      2. It can inherit from other classes.
      3. It cannot be inherited.  Class A : Class B  Class A cannnot inherit from Class B if B is sealed.

     https://www.c-sharpcorner.com/UploadFile/f1047f/static-and-sealed-class-in-C-Sharp/

     Advantage of Static Classes
     1. If you declare any member as a non-static member, you will get an error.
     2. When you try to create an instance to the static class, it will generate a compile error.
     3. Static class members are accessed by the class name followed by the member name.
     https://www.c-sharpcorner.com/UploadFile/74ce7b/static-class-in-C-Sharp/#:~:text=There%20are%20two%20types%20of,%2C%20static%20and%20non%2Dstatic.&text=This%20is%20the%20default%20type,%22Non%2Dstatic%20member%22.

     base class types to override - abstract and virtual
     abstract - Incomplete class; must be completed in a derived class.  Also
                cannot be instantiated.   Will usually hold methods that are defined as either virtual
                or abstract.  Abstract classes are useful because of Polymorphism.  Abstract class can
                provide some implementation details.  This is a difference between them and Interfaces.
                Interfaces cannot provide implementation details.   Abstract Classes should be compared
                with Interfaces.   See InterfacesMenu.cs
     inherit  - You can inherit from many interfaces.  You are restricted from inheriting from only one class
                whether it is abstract or concrete.
     virtual - first implementation.   When you use the virtual keyword you enable Polymorphism
    
     public abstract class Window
     {
       public virtual string Title { get; set; }
      
       public virtual void Draw()
       {
         ** Drawing Code
       }
    
       public abstract void Open()    <-- Nested abstract means the class deriving from class Window must provide 
                                          an implmentation for the Open method.   
     }
     
     override - further implementation.  Keyword used in concrete classes to provide further implementations for methods
                                         that were defined as either virtual or abstract.
     Difference between virtual and abstract methods.  Abstract methods must be overriden. Overriding virtual methods is optional.
     sealed - Final implementation - cannot be derived (or inherited).
            -  Examples of Sealed Classes are String Builder
            - If you want to make sure no one overrides or extends the functionality of a class then mark it as sealed.
     making this class abstract means that I do not ever want this class 
     to be instantiated. (Abstract class should be compared to an Interface).
     However, the abstract class can be inherited and
     the class that inherited the abstract class can be instantiated.  
     
     Struct versus Classes -  See also Methods.cs
       1. Same as saying Value versus Reference Types.  See ValueTypes.cs and Methods.cs for info on Classes versus Structs.
     Note!! - Both Struct and Class will use the 'new' keyword.   See also Static versus Dynamic in Dynamic Examples.cs.  Cannot
     use the 'new' keyword with Static types.   
     See also instance verus Static fields versus Instance fields in StaticExamples.cs
     See also Methods.cs
     
     See InterfacesMenu.cs   -  has more information on Arrays versus Lists
     See ConsumeTypes.cs - Information on casting
    
    */
    static class BaseExamples   
    {
        #region TMain
        abstract class Person
        {
            private string ssn = "444-55-666";
            private string name = "Jesse Olivarez";
            // making this method virtual means that this method can be overridden.  A method
            // that is not marked virtual cannot be overriden.  Methods can be either virtual
            // or abstract and the derived class must use the override keyword for both.  Notice
            // the abstract method is not alloweed to have an implementation in the base class.
            // An implementation of the virtual method is required in the base class.   The derive
            // class requires you to implement an abstract method.  Implementation of virtual methods
            // is optional in the derived class.
            public virtual void GetInfo()
            {
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("SSN: {0}", ssn);
            }
            public abstract void GetInfo2();
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
            public override void GetInfo2()
            {
                Console.WriteLine("Employee ID: {0}", id);
            }
        }
        
        internal static void TMain()
        {
            Employee E = new Employee();
            E.GetInfo();
        }
        #endregion
        #region DMain

        class BaseClass
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
        class DerivedClass : BaseClass
        {
            //This constructor will call BaseClass.BaseClass()
            internal DerivedClass()
                : base()
            {
            }
            internal DerivedClass(string MyString)
                : base("From Derived")
            {
                Console.WriteLine("Derived Constructor ");
            }
            //This constructor will call BaseClass.BaseClass(int i)
            internal DerivedClass(int i)
                : base(i)
            {
            }
            internal new void print()
            {
                base.print();
                Console.WriteLine("I'm in a Derived Print class");
            }
           
        }

        internal static void D_Main()
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
