﻿using System;
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
                //
                // * Generic Interfaces are based on IEnumerable<T>
                // * Concept of collection define by ICollection<T> (but this interface isn't always useful)
                // * Three categories of collection defined by:
                //     ** IList<T>
                //     ** IDictionary<T>
                //     ** ISet<T>
                //
                //  * Collection<T> class is specifically designed to be overridden if you want to customize
                //                        the behavior of your Lists.
                //    An example of this is ObservableCollection<T> which provide change notificatons for a list.
                //
                // 
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
                        // IComparable will tell you if
                        //  x < y
                        //  x > y
                        //  x == y
                        //  returning an integer
                        //  - 1 means less than
                        //    1 means greater
                        //    0 means equal to
                        //

                        SortingExamples.Sort_A_Class();
                        break;

                        // ==, != operators  - Work out of the box only for primitive types and reference types
                        //                     Operators do not work in generic code
                        //                     Object.Equals  - ok in generic code
                        //
                        // >, <, >=, <=  operators - Work out of the box only for primitive types
                        //
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
                        // IList<T>  
                        // Arrays are a fixed size.  System.Array does not contain a definition for 'Add'   
                        // new string[]  is a fixed size.
                        // This problem with arrays is what List<T> was designed to overcome.
                        // new List<string> allows you to add to an array.
                        // List<T> acts as an array in every aspect and in addition you can add and
                        // remove elements.
                        //
                        // List<T> uses a capacity and a count method
                        // Capacity - Gets increased if you keep adding elements.  Once you add elements
                        //            and go past the capacity it gets increased by 8.
                        //
                        // count - Total number of elements you have added
                        // if the count is 4 and the capacity is 8 you cannot display elements that exceed the count.
                        // 
                    
                        GenericExamples.GA_Main();
                        break;
                        //case 4:  
                        //Dictionary uses a hash table.   It is a large collection
                        //that will divide a collection into smaller collections.
                        //Each smaller collection is defined as a bucket.
                        //If you know what bucket the item your searching for is in,
                        //you only need to search that bucket.
                        //
                        //The modulo % method along with the .gethashcode method is used to determine the bucket when 
                        //storing or retrieving a value.
                        //
                        //If two values x and y evaluate to equal then they must evaluate to the same hash code.
                        //
                        // StringComparer implements IEqualityComparer
                        // If two objects are equal they must return the same hash code that is why the IEqualityComparer
                        // defines its own get hash code method so you can make sure that rule is followed.  
                        // 
                        // public int GetHashCode (string obj)
                        // {
                        //    return obj.ToUpper().GetHashCode();   // Best to reuse what Microsoft has already done
                        // }
                        //
                        // SortedList<TKey, TValue>  - Dictionary that keeps its values sorted.  It's a Dictionary and NOT a List.
                        // Sorted List does NOT contain a Hash Table.  So when you implement an IComparer interface you won't have a 
                        // hash method.
                        //
                        // SortedDictionary<TKey, TValue>  - Functionally is the same as SortedList<TKey, TValue>
                        // Added and Removing Elments is a lot faster using a Sorted Dictionary verus a Sorted List.
                        // So only use a SortedDictionary if you need to make frequent changes to the collection.
                        //
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
