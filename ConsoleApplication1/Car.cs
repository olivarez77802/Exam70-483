using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483 
{
    public class Car : Interface1
    {
        #region Interface1 Members

        public bool Start()
        {
            Console.WriteLine("Car started");
            return true;
        }

        public bool Stop()
        {
            Console.WriteLine("Car Stopped");
            return true;
        }

        #endregion
    }
}
