using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483.ExamLibrary.CreateAndUseTypes
{
     public class EnumTest
        {
            enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
            public static void EnumMain()
            {
                int x = (int)Days.Sun;
                int y = (int)Days.Fri;
                Console.WriteLine("Sun = {0}", x);
                Console.WriteLine("Fri = {0}", y);
            }
        }
}
