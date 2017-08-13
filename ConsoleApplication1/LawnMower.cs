using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam70483.App.App
{
    public class LawnMower : Interface1
    {
        #region Interface1 Members

        public bool Start()
        {
            Console.WriteLine("Lawnmower started");
            return true;
        }

        public bool Stop()
        {
            Console.WriteLine("Lawnmower Stopped");
            return true;
        }

        #endregion
    }
}
