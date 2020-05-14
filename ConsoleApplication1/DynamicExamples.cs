using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace Exam70483
{
    /*
    The 'dynamic' type was introduced in C# 4.0
    Any object in the .Net framework can be assigned to type 'dynamic'

    When would you want to use dynamic typing ?
       * When you Interface with dynamic languages such as IronPython, and JavaScript
       * When you access weakly typed data such as XML, JSON
       * When you don't want to Reflection
        
    Visual C# 2010 introduces a new type, dynamic. The type is a static type, but an object of type dynamic bypasses static type checking.
    In most cases, it functions like it has type object. At compile time, an element that is typed as dynamic is assumed to support any
    operation.Therefore, you do not have to be concerned about whether the object gets its value from a COM API, from a dynamic language
    such as IronPython, from the HTML Document Object Model(DOM), from reflection, or from somewhere else in the program.However, if the
    code is not valid, errors are caught at run time.

    How do I get Type data ?
    - Statically at compile time
    - Dynamically at run time
    Example:
    var dog = new Dog { NumberOfLegs = 4 };
    // At compile time
    Type t1 = typeof(Dog);
    // At run time
    Type t2 = dog.GetType();

    Static types get resolved at compile time.

     <summary>
     var says, “Let the compiler figure out the type.” .  You can only use the 'var' keyword for local variables,
     you cannot use 'var' keyword when defining parameters to a method, cannot use when defining a field or property
     of a class.  The var keyword is used for local variables.  Variable must be initialized when using 'var' keyword.
     You cannot initialize the 'var' variable to null, since any reference type can be null.
     dynamic says, “Let the runtime figure out the type.” 
     
     Static typing eliminates a large class of errors before a program is even run.It shifts the burden away from runtime 
     unit tests onto the compiler to verify that all the types in a program fit together correctly.This makes large programs 
     much easier to manage, more predictable, and more robust.Furthermore, static typing allows tools such as IntelliSense 
     in Visual Studio to help you write a program, since it knows for a given variable what type it is, and hence what methods
     you can call on that variable.
    
     A static method can only call other methods that are defined as static.

    See static versus instance fields in StaticExamples.cs

    Example of Anonymous type  - new keyword defines Anonmyous type
      Anonymous type are great for defining types on the fly that can be used for processing or binding scenarios but these types
                are only useful in the method they are declared - don't try to pass anonymous types from a function. 
       dynamic - allows you bypass compile time type checking allowing you to return an anonymous type.
    However if we called this method and got back the dynamic there would be no way to convert back to our query so it is not recommended technique
    The recommened use of dynamic types is to add this code where you need it, for example you can put this code to the UI Layer and bind directly to the    
    results of the query.
    
    public dynamic GetNamesandEmail(List<Customer> customerList)
    {
      var query = customerList.Select( c => new
           {
            Name = c.LastName + ", " + c.FirstName, c.EmailAddress
           });
      return query;
    }    
    */

    class DynamicExamples
    {
        public static void DMain()
        {

            dynamic dperson = new ExpandoObject();

            dperson.Name = "Filip";
            dperson.Address = "603 N. Temple";

            Console.WriteLine("Name: {0} ", dperson.Name);
            dperson.Age = 24;
            Console.WriteLine("Age : {0} ", dperson.Age);
            Console.WriteLine("Address : {0}", dperson.Address);
            if (dperson.Age > 20) Console.WriteLine("Hello");
        }


        public static void DMain2()
        {
            dynamic employee, manager;

            employee = new ExpandoObject();
            employee.Name = "John Smith";
            employee.Age = 33;

            manager = new ExpandoObject();
            manager.Name = "Allison Brown";
            manager.Age = 42;
            manager.TeamSize = 10;

            WritePerson(manager);
            WritePerson(employee);
        }
        private static void WritePerson(dynamic person)
        {
            Console.WriteLine("{0} is {1} years old.",
                              person.Name, person.Age);
            // The following statement causes an exception
            // if you pass the employee object.
            // Console.WriteLine("Manages {0} people", person.TeamSize);
        }

        // This code example produces the following output:
        // John Smith is 33 years old.
        // Allison Brown is 42 years old.


    }
}
