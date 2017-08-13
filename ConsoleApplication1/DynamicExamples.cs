using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace JesseTesting.App
{

    //Visual C# 2010 introduces a new type, dynamic. The type is a static type, but an object of type dynamic bypasses static type checking.
    //In most cases, it functions like it has type object. At compile time, an element that is typed as dynamic is assumed to support any 
    //operation. Therefore, you do not have to be concerned about whether the object gets its value from a COM API, from a dynamic language 
    //such as IronPython, from the HTML Document Object Model (DOM), from reflection, or from somewhere else in the program. However, if the 
    //code is not valid, errors are caught at run time.

    // Static types get resolved at compile time.

    /// <summary>
    /// var says, “Let the compiler figure out the type.” 
    /// dynamic says, “Let the runtime figure out the type.” 
    /// 
    /// Static typing eliminates a large class of errors before a program is even run. It shifts the burden away from runtime 
    /// unit tests onto the compiler to verify that all the types in a program fit together correctly. This makes large programs 
    /// much easier to manage, more predictable, and more robust. Furthermore, static typing allows tools such as IntelliSense 
    /// in Visual Studio to help you write a program, since it knows for a given variable what type it is, and hence what methods 
    /// you can call on that variable.
    ///
    /// A static method can only call other methods that are defined as static.
    /// 
    /// </summary>

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
