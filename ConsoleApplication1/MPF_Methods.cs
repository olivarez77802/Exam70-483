using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    class MPF_Methods : IMenu
    {
        public void MenuOpt0()
        {
          MultithreadingAndAsync.Menu();
        }
         
        public void MenuOpt1()
        {
            ManageMultithreading.Menu();

        }

        public void MenuOpt2()
        {
            ImplementProgramFlow.Menu();
        }

        public void MenuOpt3()
        {
            EventsandCallBacksMenu.Menu();
        }

        public void MenuOpt4()
        {
        /*
         * A "finally" statement will execute even there is an exception that goes through "catch" block
         * The "finally" statement will also execute when there is no exception
         * Finally block will always execute so it is a good place to close file or shut down resources.
         * A try/Finally block can also be used by the "using" statement
        */

            ExceptionClassExamples.Menu();
       }

        public void MenuOpt5()
        {
            throw new NotImplementedException();
        }
    }
}
