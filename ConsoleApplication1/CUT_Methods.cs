using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    public class CUT_Methods : IMenu
    {
        public void MenuOpt0()
        {
            CreateTypes.Menu();
            
        }

        public void MenuOpt1()
        {
            ConsumeTypes.Menu();
        }

        public void MenuOpt2()
        {
            throw new NotImplementedException();
            
       }

        public void MenuOpt3()
        {
            ClassHierarchy.Menu();
        }

        public void MenuOpt4()
        {
            RunTimeTypes.Menu(); 
        }

        public void MenuOpt5()
        {
            ManageObjectCycle.Menu();
            
        }

        public void MenuOpt6()
        {
            // CreateAndUseTypes_6.Menu();
            ManipulateStringsMenu.Menu();
            Console.ReadKey();
            //ManipulateStrings.Menu();
            //Console.WriteLine("Equality");
            //Console.ReadKey();
            //StringEquality.SE_Main();
            //Console.ReadKey();
            
        }
    }
}
