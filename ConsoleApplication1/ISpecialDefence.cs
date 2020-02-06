using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    /* Could also have used an abstract base class instead of an interface.
    */
    interface ISpecialDefence
    {
        int CalculateDamageReduction(int totaldamage);
    }
}
