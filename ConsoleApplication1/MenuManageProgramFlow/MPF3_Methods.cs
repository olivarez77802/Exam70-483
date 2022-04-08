using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483.MenuManageProgramFlow
{
    public class MPF3_Methods : IMenu
    {
        public void MenuOpt0()
        {
            CreateEventsAndCallbacks_0.Menu();
           // ManageProgramFlow_3_0.Menu();
          //  EventHandlerExamples.Menu();
        }

        public void MenuOpt1()
        {
            CreateEventsAndCallbacks_1.Menu();
           // ManageProgramFlow_3_1.Menu();
            //EventExamples.Menu();
            
        }

        public void MenuOpt2()
        {
            CreateEventsAndCallbacks_2.Menu();
           // ManageProgramFlow_3_2.Menu();
         //   Delegate.Menu();
            
        }

        public void MenuOpt3()
        {
            Lambda.Menu();
        }

        public void MenuOpt4()
        {
            Anonymous.Menu();
        }

        public void MenuOpt5()
        {
            throw new NotImplementedException();
        }

        public void MenuOpt6()
        {
            throw new NotImplementedException();
        }
    }
}
