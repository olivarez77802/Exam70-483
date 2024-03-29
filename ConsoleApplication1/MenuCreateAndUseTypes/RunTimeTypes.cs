﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483.MenuCreateAndUseTypes
{
    public class RunTimeTypes
    {
 /*
  * 
  * Dynamic types are similar to object types except that type checking for object type variables take place at compile
  * time, whereas that for dynamic type variables take place at run time.
  * 
  * 
           
  See also DynamicExamples.cs
           
           Windows RunTime
           https://www.youtube.com/watch?v=24Uaf3Y4qW8
           To Do:  1. Try building Camera Demo 2. Try building WinMd Hybrid App

           Refelection
           * Reflection inspects type metadata at runtime
           * The type metadata contains information such as:
            - The 'type' Name
            - The containing Assembly
            - Constructors
            - Properties
            - Methods
            - Attributes

            * This data can be used to create instances, access values and executes methods
              dynamically at run time.

            Example:
            void Property()
            {
               var horse = new Animal() {Name = "Ed" };
               var type = horse.GetType();
               var property = type.GetProperty("Name");
               var value = property.GetValue(horse, null);
            }

            public class Animal
            {
               public string Name { get; set}
            }

            https://www.youtube.com/watch?v=1G2IhEdb6lA
               
                         
        */


        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Find, execute, and create types at runtime by using reflection");
                Console.WriteLine("    Create and apply attributes; read attributes; generate code at runtime");
                Console.WriteLine("    using CodeDom and Lambda expressions; use types from the System.Refection");
                Console.WriteLine("    namespace, including Assembly, PropertyInfo, MethodInfo, Type");
          
                Console.WriteLine(" 0.  Reflection ");
                Console.WriteLine(" 1.  Relection - GetTypes");
                Console.WriteLine(" 2.  Refelection - GetExecutingAssembly");
                Console.WriteLine(" 3.  Reflection - Determine Type ");
                Console.WriteLine(" 4.  CodeDom ");
                Console.WriteLine(" 5.  Attributes ");
                Console.WriteLine(" 6.  ... ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        ReflectionExamples.Menu();
                        break;
                    case 1:
                        AssemblyClassExamples.GetTypes();
                        Console.ReadKey();
                        break;
                    case 2:
                        AssemblyClassExamples.GetExecutingAssembly();
                        Console.ReadKey();
                        break;
                    case 4:
                        AssemblyClassExamples.Determine_type();
                        break;
                    case 5:
                         AttributeExamples.Menu();
                        break;
                    case 6:
                        CodeDom_Example();
                         break;
                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;

                }


            } while (x < 9);

        }
        static void CodeDom_Example()
        {
            /*
             * Code (D)ocument (O)bject (M)odel
             * Writing Code that Writes Code
             * 
             */
        }
    }
}
