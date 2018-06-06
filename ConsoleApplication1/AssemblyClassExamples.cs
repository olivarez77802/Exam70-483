

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace Exam70483
{
    //
    // Called by Namespaces Menu - System.Reflection
    //      
    class AssemblyClassExamples
    {

        public static void GetTypes()
        {
            // List all Types in Executing Assembly 
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Type[] myAssemblyTypes = myAssembly.GetTypes();

            foreach (Type myType in myAssemblyTypes)
            {
                Debug.WriteLine(string.Format("myType name: {0}", myType.Name));
            }
            Console.WriteLine(" End of GetTypes");
        }
        public static void GetExecutingAssembly()
        {


            // Get the assembly from a known type in that assembly.
            Type t = typeof(AssemblyClassExamples);
            Assembly assemFromType = t.Assembly;
            Console.WriteLine("Assembly that contains Example:");
            Console.WriteLine("   {0}\n", assemFromType.FullName);

            // Get the currently executing assembly.
            Assembly currentAssem = Assembly.GetExecutingAssembly();
            Console.WriteLine("Currently executing assembly:");
            Console.WriteLine("   {0}\n", currentAssem.FullName);

            Console.WriteLine("The two Assembly objects are equal: {0}",
                              assemFromType.Equals(currentAssem));
        }

        public static void Determine_type()
        {
            Console.WriteLine(" Type of verb ");
            Type type = typeof(IEnumerable<CommonCollections.Cat>);
            while (type != null)
            {
                Console.WriteLine(type.Name);
                type = type.BaseType;
            }
            Console.ReadKey();
        }


    }
}
