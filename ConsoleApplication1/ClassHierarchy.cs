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
         * 10. sealed
         * 11. static -  Use the static modifier, which belongs to the type itself rather than to a specific object. The 
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
         * See TypeSystem.cs for Classes versus Structs.
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
          * Use interfaces for types that have independent implementations.
        
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
                        ClassesAndStructs();
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
             * 1. Abstraction
             * 2. Encapsulation  - Using a class with a private property
             * 3. Inheritance  - Using a base class  
             * 4. Polymorphism - Many shapes.  Abstract Classses that get overridden.
             */
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
        static void ClassesAndStructs()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/ms173109(v=vs.110).aspx");
            TypeProgram.TypeMain();
        }


        public class PShape
        {
            // A few example members
            public int X { get; private set; }
            public int Y { get; private set; }
            public int Height { get; set; }
            public int Width { get; set; }

            //Virtual method
            public virtual void Draw()
            {
                Console.WriteLine("Performing base class drawing tasks");
            }
        }
        class Circle : PShape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing a circle ");
                base.Draw();
            }
        }
        class Rectangle : PShape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing a rectangle");
                base.Draw();
            }
        }
        class Triangle : PShape
        {
            public override void Draw()
            {
                //Code to draw a triangle
                Console.WriteLine("Drawing a traingle");
                base.Draw();
            }
        }


        public static class P_Program
        {
            public static void ProgramMain()
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

            //Constructor
            public Employee(string name, string alias, decimal salary)
            {
                //use 'this' to qualify the field, name and alias and salary"
                Console.WriteLine("Instance Constructor Called");
                this.name = name;
                this.alias = alias;
                this.salary = salary;
            }

            //Printing
            public void printEmployee()
            {
                Console.WriteLine("Name: {0} \n Alias: {1} \n Salary: {2} ", name, alias, salary);
                //Passing the object to the CalcTax method by using 'this'"
                Console.WriteLine("Taxes: {0:C} \n", Tax.CalcTax(this));
            }
            public decimal Salary
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
        public static class MainClass
        {
            public static void MC_Main()
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
        public class TypeProgram
        {
            public static void TypeMain()
            {
                Second s = new Second();
                s.name = "Tricia";
                s.surname = "Robich";
                First<Second> objf = new First<Second>(s);
                Console.ReadLine();
            }
        }

    } // End of Class ClassesandInterfaces

}  // End Namespace


