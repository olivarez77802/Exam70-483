using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483
{
    class ObjectExamples
    {
        class ClassA { }
        class ClassB { }

        public static void PrimaryMain()
        {
            object[] objArray = new object[6];
            objArray[0] = new ClassA();
            objArray[1] = new ClassB();
            objArray[2] = "hello";
            objArray[3] = 123;
            objArray[4] = 123.4;
            objArray[5] = null;

            object[] objArray2 = new object[6];
            objArray2[0] = "Name0";
            objArray2[1] = "Name1";
            objArray2[2] = "Name2";
            objArray2[3] = "Name3";
            objArray2[4] = "Name4";
            objArray2[5] = "Name5";

            Console.WriteLine("Example of using as instead of casting");
            Console.WriteLine("As does not raise an exception for different typess");


            for (int i = 0; i < objArray.Length; ++i)
            {
                string s = objArray[i] as string;
                Console.Write("{0}:", i);
                if (s != null)
                {
                    Console.WriteLine("'" + s + "'");
                }
                else
                {
                    Console.WriteLine("not a string");
                }
            }
            Console.WriteLine("casting requires the type to be correct or for you to know type");
            Console.WriteLine("If the type is not correct, casting will throw an exception");
            //use objArray if you want an exception to be thrown.

            for (int i = 0; i < objArray2.Length; ++i)
            {
                string s = (string)objArray2[i];
                Console.Write("{0}:", i);
                if (s != null)
                {
                    Console.WriteLine("'" + s + "'");
                }
                else
                {
                    Console.WriteLine("not a string");
                }
            }
            Console.ReadKey();
        }

    }
}
