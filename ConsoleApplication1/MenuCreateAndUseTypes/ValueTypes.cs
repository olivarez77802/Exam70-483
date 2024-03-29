﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483.MenuCreateAndUseTypes
{
    public class ValueTypes
    {
        /* See also Methods.cs and  BaseExamples.cs on when to use a Class versus Struct.
         * 
         * Value Types are Independent Instances or Copies.  Value Change doesn't affect other copies.
         * Classes versus Structs
         * {
         * A struct is a value type where a class is a reference type.  Structs cannot have a default constructor.
         * 
         * All the differences that are applicable to a value type and reference types are also applicable to classes and structs.
         * 
         * Value types hold their value in memory where they are declared, but reference types hold a reference to an object in 
         * memory.
         * 
         * Value types are destroyed immediately after the scope is lost, where as for reference types only the reference 
         * variable is destroyed after the scope is lost.   The object is later destroyed by garabage collectors.
         * 
         * When you copy a struct into another struct, a new copy of that struct gets created and modifications on one
         * struct will not affect the values contained by another struct.
         * 
         * When you copy a class into another class, we only get a copy of the reference variable.  Both the 
         * reference variables point to the same object on the heap.   So operations on one variable will affect the values 
         * contained by the other reference variable.
         * 
         * Structs cannot be declared as protected because structs do not support inheritance.  This is another way
         * of saying Structs are sealed types.
         * 
         * Structs can't have destructors, but classes can have destructors
         * 
         * Structs cannot have explicit parameter less constructor where as a class can.
         * 
         * Structs can't inherit from another class where where as a class can, Both Structs and classes can inherit from
         * an interface.
         * 
         * Structs are sealed types.  A class or a struct cannot inherit from another struct.
         * You use sealed keyword to prevent your classes from being inherited by another class.
         * 
         * Examples of structs in the .NET Framework - int(System.Int32), double(System.Double) etc.
         *  }
         * 
         * Stack and Heap
         * {
         * Physical Memory is divided into a Stack and Heap
         * 
         * Stack - Values types are stored here.  Object Reference Variables are also stored here.
         * Static Memory Allocation.
         * 
         * Heap - The place in memory where Object Reference Variables will point to.
         * Dynamic Memory Allocation.
         * }
        
        /*
        The 'var' key word indicates implicit typing 
        string[] colorOptions = new string[4];   Is the same as
        var colorOptions = new string[4]; 

        The 'var' key word is also useful for complex return types such as Linq since you do not have to figure out
        what is being returned.  Especially when you don't really care about what is being returned you just want to 
        iterate through the result.  So use the 'var' keyword wherever it makes sense and does not detract from 
        readablity.

          Reference Types can represent a non-existent value with a null reference.
          Value Types cannot represent null values.

          string s = null;    - ok, Nullable type
          int i = null;       - Compile error, value type cannot be null

          Boxing is the act of converting a VALUE type instance to a REFERENCE type
          instance.   

              int x = 9;
              object = x;   -  box the int

           Unboxing casts the object back to the VALUE type

            int y = (int)obj;    // unbox the int

 */
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Value Types Menu \n ");
                Console.WriteLine(" 0.  Structs  \n ");
                Console.WriteLine(" 1.  Enums  \n ");
                Console.WriteLine(" 2.  Numeric \n");
                Console.WriteLine(" 3.  Char \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        Struct1.Menu();
                        Console.ReadKey();
                        break;
                    case 1:
                        ExamLibrary.CreateAndUseTypes.EnumTest.EnumMain();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        }
    }
}
