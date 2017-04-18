using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Collections;

namespace JesseTesting.App
{
    abstract class InterfacesMenu
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                //  As a guideline:
                //  Use classes and subclasses for types that naturally share an implementation
                //  Use interfaces for types that have independent implementations.
                //
                //Console.WriteLine("\n Interface contains only the signatures of methods, properties, ");
                //Console.WriteLine(" events, or indexers.  A class or struct that implements the    ");
                //Console.WriteLine("Interface must implement the members of the interface that ");
                //Console.WriteLine("are specified in the interface definition. \n");
                //Console.WriteLine("Interface1 is the name of an interface with Start() and Stop() ");
                //Console.WriteLine("methods. \n");
                Console.Clear();
                Console.WriteLine(" Types of Interfaces \n ");
                Console.WriteLine(" 0.  IComparable \n ");
                Console.WriteLine(" 1.  IDisposable \n ");
                Console.WriteLine(" 2.  IEnumerable \n ");
                Console.WriteLine(" 3.  IList \n");
                Console.WriteLine(" 4.  IDictionary \n");
                Console.WriteLine(" 5.  Self Created \n");
                Console.WriteLine(" 6.  IQueryable \n");
                Console.WriteLine(" 8.  Web Page \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        SortingExamples.Sort_A_Class();
                        break;
                    case 2:
                        // IEnumerable - A List, Array, Query implements IEnumerable.
                        // An IEnumerable Interface specifies that the underlying type implements IEnumerable
                        //
                        // public Interface IEnumerator
                        // {
                        //   bool MoveNext();
                        //   object Current {get;}
                        //   void Reset();
                        //  }
                        //
                        //  public interface IEnumerable
                        //  {
                        //   IEnumerator GetEnumerator();
                        //  }
                        //
                        EnumerableMethods.Menu();
                        IEnumeratorInterface.Menu();
                        break;
                    case 3:
                        GenericExamples.GA_Main();
                        break;
                    case 5:
                        Shape shape = new Oval();
                        shape.WhatAmI();
                        var car = new Car();
                        car.Start();
                        car.Stop();
                        var mower = new LawnMower();
                        mower.Start();
                        mower.Stop();
                        Console.Write("\nPress Enter to Continue ");
                        Console.ReadKey();

                        Collections.
                            Using_Collections();
                        Console.ReadKey();
                        break;
                    case 6: Console.WriteLine (" Not yet built");
                        Console.ReadKey();
                        break;

                        //* Differences between IEnumerable and IQueryable
                        //* http://blog.falafel.com/understanding-ienumerable-iqueryable-c/

                    case 8:
                        Process.Start("http://msdn.microsoft.com/en-us/library/87d83y5b.aspx");
                        break;

                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);  // end do

        }  // end Menu()
        //* 
        //* New Example
        //*
        class Shape
        {
            public void WhatAmI()
            {
                Console.WriteLine("I am a shape");
            }
        }

        class Oval : Shape
        {
            new public void WhatAmI()
            {
                Console.WriteLine("I am an oval");
            }
        }
    }


}
