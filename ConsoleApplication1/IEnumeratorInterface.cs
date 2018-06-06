using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Exam70483
{
    class IEnumeratorInterface
    {
        private enum eMenu
        {
            IENumeratorString01,
            IENumeratorString02,
            two,
            three,
            four,
            five,
            six,
            seven,
            eight,
             Quit
        }
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
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" IEnumerator Interface \n ");
                Console.WriteLine(" 0.  IEnumeratorString01 \n ");
                Console.WriteLine(" 1.  IENumeratorString02 \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");

                eMenu selection = (eMenu)(Common.readInt("Enter Number to Execute Routine : ", 0, 9));
                switch (selection)
                {
                    case eMenu.IENumeratorString01:
                        IEnumaratorString01();
                        break;

                    case eMenu.IENumeratorString02:
                        IEnumaratorString02();
                        break;

                    case eMenu.Quit:
                        x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);

        }  // End Menu

      
        private static void IEnumaratorString01()
        {
            Console.WriteLine("foreach statement");
            foreach (char c in "beer")
            Console.WriteLine(c);
            Console.WriteLine("Same as foreach using IEnumerable and IEnumerator");
            using (var enumerator = "beer".GetEnumerator())
                while (enumerator.MoveNext())
                {
                    var element = enumerator.Current;
                    Console.WriteLine(element);
                }
            Console.ReadKey();
        }
        private static void IEnumaratorString02()
        {
            string s = "Hello";
            // Because string implements IEnumerable, we can 
            // get GetEnumerator()
            //
            IEnumerator rator = s.GetEnumerator();
            while (rator.MoveNext())
            {
                char c = (char)rator.Current;
                Console.WriteLine(c + ".");
            }
            Console.ReadKey();
            
        }
    }
}
