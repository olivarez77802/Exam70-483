using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace Exam70483
{
    /* 
     * typeof versus GetType
     * - GetType  - Type is known at run time
     * - typeof -  Compile time operator
     * 
     * Example
     * var sample = new Sample {Name = "John", Age = 25};
     * var sampleType = typeof(Sample);     <-- known at Compile time
     * var sampleType = sample.GetType;     <-- know at run time
     */
    class ReflectionExamples
    {
        public static void Menu()
        {

            /*
            Process.Start("http://csharp.net-tutorials.com/reflection/introduction/");
            https://www.youtube.com/watch?v=3FvT6uNMT7M&list=PLrzrNeNx3kNHUOzNmvX5gZy0scGLKpY7m&index=6
            */
            ReflectionExample1.EnterNumber();
            Console.ReadKey();
            Console.WriteLine("Example of Reflection using GetMethods() ");
            ReflectionExample2.GetMethods();
            Console.ReadKey();
            Console.WriteLine("Example of Reflection using GetMethod().Invoke ");
            ReflectionExample3.InvokeSpecificMethod();
            Console.ReadKey();
            Console.WriteLine("Example of Reflection using GetMethod(set_Name).Invoke ");
            ReflectionExample4.InvokeSpecificMethod();
            Console.ReadKey();

        }
        
       

        
    } // End Reflection Examples
    #region Reflection Example 1
    
    class ReflectionExample1
    {
        private static int a = 5, b = 10, c = 20;

        public static void EnterNumber()
        {
            Console.WriteLine("a + b + c = " + (a + b + c));
            Console.WriteLine("Please enter the name of the variable that you wish to change:");
            string varName = Console.ReadLine();
            Type t = typeof(ReflectionExample1);
            FieldInfo fieldInfo = t.GetField(varName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            if (fieldInfo != null)
            {
                Console.WriteLine("The current value of " + fieldInfo.Name + " is " + fieldInfo.GetValue(null) + ". You may enter a new value now:");
                string newValue = Console.ReadLine();
                int newInt;
                if (int.TryParse(newValue, out newInt))
                {
                    fieldInfo.SetValue(null, newInt);
                    Console.WriteLine("a + b + c = " + (a + b + c));
                }
                //    Console.ReadKey();
            }
        } // Enter Number
    } // End Reflection Example1
    #endregion
    #region Reflection Example 2 
    class Person2
    {
        public string Name { get; set; }
        public string Speak()
        {
            return string.Format("Hello there, my name is  {0}", Name);
        }
        public int Calculate(int first, int second, int third)
        {
            var result = first * second;
            return result - third;
        }
    }
    class ReflectionExample2
    {
        public static void GetMethods()
        {
            var p = new Person2 { Name = "Jesse Olivarez" };
            //Console.WriteLine(p.Speak());
            var type = p.GetType();
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }
    }
    #endregion

    #region Reflection Example 3
    class ReflectionExample3
    {
        public static void InvokeSpecificMethod()
        {
            var p = new Person2 { Name = "Frank Olivarez" };
            var type = p.GetType();
            var result = type.GetMethod("Speak").Invoke(p, null);
            Console.WriteLine(result);

        }
    }
    #endregion
    #region Reflection Example 4
    class ReflectionExample4
    {
        public static void InvokeSpecificMethod()
        {
            var p = new Person2 { Name = "John Olivarez" };
            var type = p.GetType();
            type.GetMethod("set_Name").Invoke(p, new[] { "John" });
            var result = type.GetMethod("Speak").Invoke(p, null);
            Console.WriteLine(result);

        }
    }
    #endregion

}
