using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace JesseTesting.App
{
    // LINQ Operators categories based on execution behavior, divided into 2 groups.
    //
    // 1. Deferred or Lazy Operators - These query's use deferred executuion.
    //    Examples - select, where, Take, Skip, etc.
    // 2. Immediate or Greedy Operators - These query operators use immediate execution.
    //    Examples - count, average, min, max, ToList, etc.
    //
    // IEnumerable - A List, Array, Query implements IEnumerable.
    // An IEnumerable Interface specifies that the underlying type implements IEnumerable
    //
    //
    // called by Methods.cs
    //


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
