using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Exam70483
{
    /*

    called by Methods.cs

    LINQ Operators categories based on execution behavior, divided into 2 groups.
    
     1. Deferred or Lazy Operators - These query's use deferred executuion.
        Examples - select, where, Take, Skip, etc.
     2. Immediate or Greedy Operators - These query operators use immediate execution.
        Examples - count, average, min, max, ToList, etc.

     IEnumerable - A List, Array, Query implements IEnumerable.
     An IEnumerable Interface specifies that the underlying type implements IEnumerable


     Linq Syntax  - Query Syntax versus Method Syntax  - Linq statements work on any object that implements IEnumerable.

     Query Syntax -  var query = from c in customerList
                                 where c.CustomerId == customerId
                                 select c;

    Method Syntax - var query = customerList.Where(c =>
                               c.CustomerId == customerId);

    Extension Methods are used when you use the Method Syntax.
    extension methods require class to be static and parameter to have 'this'
     Extension methods use the Enumerable Class.The Enumerable class is in the
   System.Linq namespace

   Mistake#5 - Failing to consider the underlying objects in a LINQ Statement.
   https://www.toptal.com/c-sharp/top-10-mistakes-that-c-sharp-programmers-make
   The underlying objects in a LINQ statement are references to SQL Table data(as
   is the case with the Entity Framework DbSet object), the statement is converted
   into a T-SQL statement.  Operators then follow T-SQL rules, not C# rules, the
   the comparison operator '==' ends up being case insesitive.

   Extension methods require 3 things:
     * Must reside in a static class
     * Method in the class must be static
     * Need a 'this' in front of the first parameter of the static method
       By placing a 'this' keyword the parameter no longer represents a parameter passed to the method
       but rather it represents the type being extended.

       Can be called like a static method e.g return StringHandler.InsertSpaces(_Productname); or
       Can be called as a method on the extended class e.g. return _Productname.InsertSpaces();
    
    
     Chaining - you can append, link extension methods as needed.
     Fluent programming - The output of one method is the input to the next
                          creating a string of operations that together form a single task.

                         foundCustomer = customer.List.Where(c => 
                                         c.CustomerId == customerId)
                                          .Skip(1)
                                          .FirstorDefault();
                         return foundCustomer;
    
    
     Transforming with Projections
     * Projection
        Select
        Select Many
     * Why Project?
       Limit to the needed properties
       Perform an action on the properties
       Morph the sequence elements into another type
     * Projects a Type
       Original Type
       Existing Type
       Anonymous Type


     Example  - Projects into a new string that is comprised of the Last Name and First Name
                Example show how to project only properites that are needed or only Last and First Name
                Example also shows how to perform an action on those properties or concatenation
                Example also shows how to morph the sequence into another type so we morphed Customer into a string item


     See IEnumeratorInterfaces.cs for more information on IEnumerable
     public IEnumrable<string> GetNames(List<Customer> customerList)
    {
        var query = customerList.Select(c => c.LastName + ", " + c.FirstName);
        return query;
    }

    Example of Anonymous type  - new keyword defines Anonmyous type
     Anonymous type are great for defining types on the fly that can be used for processing or binding scenarios but these types
               are only useful in the method they are declared - don't try to pass anonymous types from a function. 
     dynamic - allows you bypass compile time type checking allowing you to return an anonymous type.
         However if we called this method and got back the dynamic there would be no way to convert back to our query so it is not recommended technique
     The recommened use of dynamic types is to add this code where you need it, for example you can put this code to the UI Layer and bind directly to the
     results of the query.


     public dynamic GetNamesandEmail(List<Customer> customerList)
    {
        var query = customerList.Select(c => new
        {
            Name = c.LastName + ", " + c.FirstName,
            c.EmailAddress
        });
        return query;

    }
    */
    abstract class EnumerableMethods
    {
        private enum eMenu
        {
            IENumerator,
            Immediate,
            Deferred,
            three,
            four,
            five,
            six,
            seven,
            eight,
            Quit
        }
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Enumerable Methods Menu - Deferred vs Immediate Operators\n ");
                Console.WriteLine(" 0.  IENumerator Interface / Website \n ");
                Console.WriteLine(" 1.  Immediate Operators (ToArray, ToList, ToDictionary, ToLookup )\n ");
                Console.WriteLine(" 2.  Deferred Operators (select, where, take, skip)  \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");

                eMenu selection = (eMenu)(Common.readInt("Enter Number to Execute Routine : ", 0, 9));
                switch (selection)
                {
                    case eMenu.IENumerator:
                        IEnumeratorInterface.Menu();
                        break;

                    case eMenu.Immediate:
                        EnumerableImmmediateMethods.Menu();
                        break;

                    case eMenu.Deferred:
                        LINQExamples.Menu();
                        break;

                   
                    case eMenu.Quit:
                        x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);

        }  // End Menu

        
    }
}
