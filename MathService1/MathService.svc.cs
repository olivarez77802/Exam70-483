using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MathService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MathService.svc or MathService.svc.cs at the Solution Explorer and start debugging.
    public class MathService : IMathService
    {
        public Int32 Add(Int32 piNum1, Int32 piNum2)
        {
            return piNum1 + piNum2;
        }
      
        public Int32 Subtract(Int32 piNum1, Int32 piNum2)
        {
            return piNum1 - piNum2;
        }
       
        public Int32 Multiply(Int32 piNum1, Int32 piNum2)
        {
            return piNum1 * piNum2;
        }
       
        public Int32 Divide(Int32 piNum1, Int32 piNum2)
        {
            return piNum1 / piNum2;
        }

       
    }
}
