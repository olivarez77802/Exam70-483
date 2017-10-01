using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace Exam70483
{
    public class ClassesAndInterfaces
    {
        /*
         * Interface 
         * - Inside an interface you cannot use an access modifier (.ie public, protected, private)
         * - Access modifiers are not used since everything defined in an interface has to be available, 
         *   so there is no sense in hiding anything using an access modifier.
         * - The methods in an interface are implicitly virtual
         * - You can inherit from multiple interfaces.  You can only inherit from one class whether it is abstract or concrete.  
         * - When you inherit from both a class and interface(s), the class must come first. 
         */
        // As a guideline:
        //  * Use classes and subclasses for types that naturally share an implementation.
        //  * Use interfaces for types that have independent implementations.
        //
        //  Consider the following classes
        //  abstract class Animal {}
        //  abstract class Bird       : Animal {}
        //  abstract class Insect     : Animal {}
        //  abstract class FlyingCreature : Animal {}
        //  abstract Carnivore        : Animal {}
        //
        // Concrete classes:
        //
        //  class Ostrich : Bird {}
        //  
        //
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Namespaces, Classes and Interfaces Menu \n ");
                Console.WriteLine(" 0.  Attributes \n ");
                Console.WriteLine(" 1.  \n ");
                Console.WriteLine(" 2.  Inheritance and Polymorphism \n ");
                Console.WriteLine(" 3.  Namespaces \n");
                Console.WriteLine(" 4.  Object Creation and Lifetime \n");
                Console.WriteLine(" 5.  \n");
                Console.WriteLine(" 6.  Reflection  \n");
                Console.WriteLine(" 7.  Classes and Constructors \n");
                Console.WriteLine(" 8.  Generics \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: Attributes();
                        break;
                    case 1:
                        break;
                    case 2: InheritanceAndPolymorphism();
                        break;
                    case 3: Namespaces();
                        break;
                    case 4: ObjectCreation();
                        break;
                    case 6: Reflection();
                        break;
                    case 7: Constructors();
                        ClassesAndStructs();
                        break;
                    case 8: GenericExamples.PrimaryMain();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);  // end do

        }  // end Menu()

        static void Attributes()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/aa288454(v=vs.71).aspx");
            //Attribute_Program.APMain();

        }

        static void InheritanceAndPolymorphism()
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/ms173152.aspx");
            Process.Start("http://www.csharp-station.com/Tutorial/CSharp/Lesson09");
            Console.WriteLine(" Example of Polymorphism ");
            P_Program.ProgramMain();

        }
        static void Namespaces()
        {
            NameSpacesMenu.Menu();

        }
        static void ObjectCreation()
        {
            Process.Start("https://www.youtube.com/watch?v=SZotrU_5Tf4");
        }
        static void Reflection()
        {
            ReflectionExamples.PrimaryMain();
            Console.ReadKey();
        }
        static void Constructors()
        {
            // What is the difference between constructors and other methods ?
            // 1.  Constructors must have the same name as the class and can not return a value.
            // 2.  Constructors are only called once while regular methods could be called many times.
            // 3.  The only method you can write where you do not have to specify the return type.
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
        #region AttributeProgram
        //public static class Attribute_Program
        //{
        //    [System.Obsolete("use class B")]
        //    class A
        //    {
        //        public void Method() { }
        //    }
        //    class B
        //    {
        //        [System.Obsolete("use New Method", true)]
        //        public void OldMethod() { }
        //        public void NewMethod() { }
        //    }
        //    class Check : Attribute
        //    {
        //        public int MaxLength { get; set; }
        //    }
        //    class Customer
        //    {
        //        private string _CustomerCode;

        //        [Check(MaxLength = 10)]
        //        public string CustomerCode
        //        {
        //            get { return _CustomerCode; }
        //            set { _CustomerCode = value; }
        //        }
        //    }
        //    public static void APMain()
        //    {
        //        Process.Start("https://msdn.microsoft.com/en-us/library/22kk2b44(v=vs.90).aspx");
        //        Process.Start("http://www.codeproject.com/Articles/827091/Csharp-Attributes-in-minutes#Whatareattributesandwhydoweneedit");


        //        // Generate 2 warnings
        //        A a = new A();
        //        // Generate no errors or warnings
        //        B b = new B();
        //        b.NewMethod();
        //        // Generates an error, terminating compilation
        //        // b.OldMethod();
        //        Console.ReadKey();

        //        Customer obj = new Customer();
        //        obj.CustomerCode = "12345678901";

        //        //Get the type of the object
        //        Type objtype = obj.GetType();

        //        //Use the 'Type' object and loop through all properties and attributes
        //        foreach (PropertyInfo p in objtype.GetProperties())
        //        {
        //            // for every property loop through all attributes
        //            foreach (Attribute t in p.GetCustomAttributes(false))
        //            {
        //                Check c = (Check)t;
        //                if (p.Name == "CustomerCode")
        //                {
        //                    if (obj.CustomerCode.Length > c.MaxLength)
        //                    {
        //                        throw new Exception(" Max length issues ");
        //                    }
        //                }
        //            }
        //        } //end foreach

        //        Console.ReadKey();

        //    }  //endAPMain


        //} //end class AttributeProgram
        #endregion

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


