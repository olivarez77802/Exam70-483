using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    class SerializeAndDeSerialize
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Serialize and DeSerialize data \n ");
                Console.WriteLine("   Serialize and DeSerialize data by using binary serialization, \n ");
                Console.WriteLine("   custom serialization, XML Serialization, JSON Serializer, and \n ");
                Console.WriteLine("   Data Contract Serializer \n\n ");
                Console.WriteLine(" 0.  JSON Serialization - DeSerialization \n ");
                Console.WriteLine(" 1.  XML Serialization - DeSerialization \n ");
                Console.WriteLine(" 2.  ....  \n ");
                Console.WriteLine(" 3.  ...... \n ");
                Console.WriteLine(" 4.  ....  \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        JSONExamples.Menu();
                        Console.ReadKey();
                        break;
                    case 1:
                        XMLExamples.Menu();
                        Console.ReadKey();
                        break;
                    case 3:
                        break;
                    case 4:
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
    }
}
