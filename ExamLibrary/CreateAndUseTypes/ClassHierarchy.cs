using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace Exam70483
{
    public class ClassHierarchy
    {
        /*
         * C# Modifiers
         * 1. Access Modifers
         * 2. Abstract
         * 3. Async
         * 4. Const
         * 5. Event
         * 6. extern
         * 7. override
         * 8. partial
         * 9. readonly
         * 10. sealed (cannot be used as base class)
         * 11. static (sealed)-  Use the static modifier, which belongs to the type itself rather than to a specific object. The 
         *               static modifier can be used with classes, fields, methods, properties, operators, Events, and
         *               constructors.  See BaseExamples.cs;DynamicExamples.cs;StaticExamples.cs 
         *               https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members
         * 12. unsafe  - trust that you know what you are doing.  Used when efficency is important or your interfacing with 
         *              an unmanaged language.
         *              https://www.youtube.com/watch?v=GLxW7oDLloY
         * 13. virtual
         * 14. volatile
         * http://www.diranieh.com/NETCSharp/Modifiers.htm
         * 
         * 
         * Access Modifiers
         * 1. Public
         * 2. Private   -  Even an instance of a class cannot access its own private members. Properties defined in a class
         *                 are private by default.
         * 3. Protected  - Only available to containing type and to type that derive from the containing type.
         * 4. Internal   - Is the default if no access modifier is specified.
         * 5. Protected Internal
         * 
         * Interface 
         * - Inside an interface you cannot use an access modifier (.ie public, protected, private)
         * - Access modifiers are not used since everything defined in an interface has to be available, 
         *   so there is no sense in hiding anything using an access modifier.
         * - The methods in an interface are implicitly virtual
         * - You can inherit from multiple interfaces.  You can only inherit from one class whether it is abstract or concrete.  
         * - When you inherit from both a class and interface(s), the class must come first. 
         * See also IntefacesMenu.cs
         
         As a guideline:
          * Use classes and subclasses for types that naturally share an implementation.
          * Use interfaces and abstract classes for types that have independent implementations.
        
          Consider the following classes
            abstract class Animal {}
            abstract class Bird       : Animal {}
            abstract class Insect     : Animal {}
            abstract class FlyingCreature : Animal {}
            abstract Carnivore        : Animal {}
        
          Concrete classes:
        
           class Ostrich : Bird {}
          
         Entity / Class / Object
            * Entity is the name of the Class
            * An Object is an instance of a class
            * Each Ojbect can perform the defined actions
            * Class is like the cookie cutter that creates objects.  It will contain the properties and actions
            *          to perform.
        */
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Create and Implement a Class Hierarchy \n ");
                Console.WriteLine("    Design and Implement an Interface; inherit from a base class; \n");
                Console.WriteLine("    create and implement classes based on IComparable, IEnumerable, \n");
                Console.WriteLine("    IDisposable, and IUknown interfaces \n");
                Console.WriteLine(" 0.  Interfaces \n ");
                Console.WriteLine(" 1.  Inheritance\n ");
                Console.WriteLine(" 2.  Classes and Constructors \n");
                Console.WriteLine(" 3.  ...... \n");
                Console.WriteLine(" 4.  ...... \n");
                Console.WriteLine(" 5.  ...... \n");
                Console.WriteLine(" 6.  ...... \n");
                Console.WriteLine(" 7.  ...... \n");
                Console.WriteLine(" 8.  .......\n");
                Console.WriteLine(" 9.  Quit \n\n");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        InterfacesMenu.Menu();
                        break;
                    case 1: InheritanceAndPolymorphism();
                        break;
                    case 2:
                        Constructors();
                        break;
                    case 3: 
                        break;
                    case 4: 
                        break;
                    case 6:
                        break;
                    case 7: 
                        break;
                    case 8: 
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);  // end do

        }  // end Menu()

       
        static void InheritanceAndPolymorphism()
        {
            /*
             * Collaboration - 'Uses a'
             * Composition - 'Has a'
             * Inheritance - 'Is a'
             * 
             * Four pillars of OOP
             * 1. Abstraction - Data abstraction is the process of hiding certain details and showing only essential information
             *    to the user.  Abstraction can be achieved with either abstract classes or interfaces  
             *    Abstract methods which have to be overridden (Compare to virtual which are optionally overridden).
             *    The abstract keyword is used for classes and methods.
             *    -- Abstract Class is a restricted class that cannot be used to create objects (to access it, it must be inherited
             *       from another class).  An abstract class can have both abstract and regular methods.
             *    -- Abstract Method can only be used in an abstract class, and it does not have a body.  The body is provided by
             *       the derived class.
             *    https://www.w3schools.com/cs/cs_abstract.php
             * 2. Encapsulation  - Using a class with a private property.  See also EnforceEncapsulation.cs.  You 
             *    always need to think about how your change will affect client when using Encapsualtion.    Encapsulation,
             *    prevents access to implementation details.  Encapsulation is implemented by using access modifers (see above).  An 
             *    access modifier defines the scope and visibility of a class member. 
             *    The meaning of Encapsulation, is to make sure that 'sensetive' data is hidden from users. To achieve this, you must:
             *    -- Declare fields/variables as private
             *    -- Provide public get and set methods, through properties, to access and update the value of a private field.
             *    class Person
             *    {
             *      private string name;   // field
             *      public string Name;    // Property
             *      {
             *        get { return name; }  // get method
             *        set { name = value; } // set method
             *       }
             *     }
             *     Main()
             *      {
             *        Person myObj = new Person();
             *        myObj.Name = 'Jess';
             *      } 
             *    https://www.w3schools.com/cs/cs_properties.php
             * 3. Inheritance  - Using a base class (Is a).  The derived class will become (is a) the base classes.
             *    See also ExamLibrary/CreateandUseTypes/BaseExamples.  Static classes are sealed and cannot inherit.
             *    Every object inherits from System.Object and the methods associated with System.Object  (Equals, ToString,..).
             *    Notice these methods are defined as virtual and so can be overridden (see BaseExamples.cs).  This is why if you 
             *    sent a boolean and used .ToString it will return True or False since Microsoft engineers overrode .ToString.  You
             *    may need to override .ToString in classes that you overwrite.  
             *    https://www.w3schools.com/cs/cs_inheritance.php              
             * 4. Polymorphism - Many shapes.  Abstract Classses that get overridden.
             *    Polymorphism means "many forms", and it occurs when we have many classes that are related
             *    to each other by inheritance.  Inheritance lets us inherit fields and methods from another class. 
             *    Polymorphism uses those methods to perform different tasks. This allows us to perform a single
             *    action in different ways
             *    https://www.w3schools.com/cs/cs_polymorphism.php
             */
            object ref11;
            Process.Start("http://msdn.microsoft.com/en-us/library/ms173152.aspx");
            Process.Start("http://www.csharp-station.com/Tutorial/CSharp/Lesson09");
            Console.WriteLine(" Example of Polymorphism ");
            P_Program.ProgramMain();

        }
       
              
        static void Constructors()
        {
            // What is the difference between constructors and other methods ?
            // 1.  Constructors must have the same name as the class and can not return a value.
            // 2.  Constructors are only called once while regular methods could be called many times.
            // 3.  The only method you can write where you do not have to specify the return type.
            // 4.  May have more than one constructor that have different parameters.
            // 
            //
            Process.Start("http://msdn.microsoft.com/en-us/library/ace5hbzh.aspx");
            MainClass.MC_Main();
            Console.ReadKey();
        }
        


        /* Points to remember
         * 1. Can't make this class static because static classes don't have instance objects so why have getter and setters
         *    if you don't expect to have instance objects.
         * 2. class is defaulted to private since it is nested under class ClassHeirarchy
         * 3. On the property X,Y Definition the setter is private.  So X and Y have to be something less restrictive
         *    than private, which is why I didn't use the default of private and instead made internal.
         * 
         */
        class PShape
        {
            // A few example members
            internal int X { get; private set; }
            internal int Y { get; private set; }
            int Height { get; set; }
            int Width { get; set; }

            //Virtual method
            internal virtual void Draw()
            {
                Console.WriteLine("Performing base class drawing tasks");
            }
        }
        class Circle : PShape
        {
            internal override void Draw()
            {
                Console.WriteLine("Drawing a circle ");
                base.Draw();
            }
        }
        class Rectangle : PShape
        {
            internal override void Draw()
            {
                Console.WriteLine("Drawing a rectangle");
                base.Draw();
            }
        }
        class Triangle : PShape
        {
            internal override void Draw()
            {
                //Code to draw a triangle
                Console.WriteLine("Drawing a traingle");
                base.Draw();
            }
        }


        static class P_Program
        {
            internal static void ProgramMain()
            {
                //Polymorphism at work #1: a rectangle, Triangle, Circle
                //can all be used wherever a shape is expected.  No cast is 
                //required because an implicit conversion exists from a derived
                //class. 
                System.Collections.Generic.List<PShape> shapes = new System.Collections.Generic.List<PShape>();
                shapes.Add(new Rectangle());
                shapes.Add(new Triangle());
                shapes.Add(new Circle());

                // Polymorphism at work #2: the virtual method Draw is 
                // invoked on each of the derived classes, not the base class. 
                foreach (PShape s in shapes)
                {
                    s.Draw();
                }

                // Keep the console open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();

            }
        }

        class Employee
        {
            private string name;
            private string alias;
            private decimal salary;

            static Employee()
            {
                Console.WriteLine("Static constructors are called only once and I'm not saying once for each instance");
            }
            /* Constructor.  Each instance will have a name, alias, salary variable. Using 'this'
             * will allow you to fully qualify and specify the instance.
             */
            internal Employee(string name, string alias, decimal salary)
            {
                //use 'this' to qualify the field, name and alias and salary"
                Console.WriteLine("Instance Constructor Called");
                this.name = name;
                this.alias = alias;
                this.salary = salary;
            }

            //Printing
            internal void printEmployee()
            {
                Console.WriteLine("Name: {0} \n Alias: {1} \n Salary: {2} ", name, alias, salary);
                //Passing the object to the CalcTax method by using 'this'"
                Console.WriteLine("Taxes: {0:C} \n", Tax.CalcTax(this));
            }
            internal decimal Salary
            {
                get { return salary; }
            }
        }
        class Tax
        {
            public static decimal CalcTax(Employee E)
            {
                return 0.08m * E.Salary;
            }
        }
        internal static class MainClass
        {
            internal static void MC_Main()
            {
                //Create Object
                Employee E1 = new Employee("Mingda Pan", "mpan", 3000.00m);
                Employee E2 = new Employee("Jesse Olivarez", "PeeWee", 6000.00m);

                //Display result:
                E1.printEmployee();
                E2.printEmployee();

            }
        }
       

        class First<T> where T : Second
        {
            public First(T tmp)
            {
                Console.WriteLine("Name is : " + tmp.name);
                Console.WriteLine("Surname is : " + tmp.surname);
            }

        }
        class Second
        {
            public string name { get; set; }
            public string surname { get; set; }
        }
       

    } // End of Class ClassesandInterfaces

}  // End Namespace


