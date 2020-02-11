using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    class ManageAssemblies
    {
        public static void Menu()
        {
            /* 
             *             * 
             * Manage Assemblies
             *    Version assemblies; sign assemblies using strong names; 
             *    implement side-by-side hosting;
             *    put an assembly in the global assembly cache;
             *    create a WinMD assembly
             *   
             *******************************************************************************************************************************   
             * Version assemblies; sign assemblies using strong names   
             *   
             * .Net Framework consists of the .NET Framework Class Library and the Run Time Enviroment (or CLR)
             * .Net Framework Class Library consist of several assemblies.   The assemblies get installed into the
             * GAC (Global Assembly Cache).  GAC resides in C:\Windows\assembly.  All of these assemblies are strongly named.
             * 
             * In .Net assemblies can be broadly classified into 2 types
             * 1. Weak Named Assemblies
             * 2. Strong Named Assemblies
             * 
             * An Assembly consists of 4 parts
             * 1. Simple textual name
             * 2. Version Number
             * 3. Culture information (otherwise the assembly is language neutral)
             * 4. Public key token
             * 
             * Assembly version consists of 4 parts
             * 1.  Major version
             * 2.  Minor version
             * 3.  Build Number
             * 4.  Revision Number
             * 
             * Strong name assembly should have:
             * 1.  The textual assembly name
             * 2.  The assembly version number
             * 3.  The assembly should have been signed with private/public key pair.
             * 
             * In order to sign with a public/private key pair - I need to get keys.  How do you get keys:
             * 1.  Go to Visual Studio Command Prompt. C:\windows\system32>sn.exe -k c:\MyStrongKeys.snk
             *     Will write Public / Private key pair to MyStrongKeys.snk
             * 2.  Open Visual Studio go to Properties..should find AsssemblyInfo.cs
             * 3.  
             *     [assembly: AssemblyVersion("1.0.0.0")]
             *     [assembly: AssemblyFileVersion("1.0.0.0")]
             *     [assembly: AssemblyKeyFile("C:\\MyStrongKeys.snk")   <--- Add this line
             * 4.  When you rebuild solution the assembly is now signed with a public/private key pair
             * 5.  Only Strong Name Assemblies can be deployed into GAC
             * 6.  Strong Named Assemblies are guarenteed to be unique - Solving DLL Hell
             *
             * 
             * https://www.youtube.com/watch?v=p6u7n_BPcVw&list=PL8598C97BA1D871C1&index=3
             * 
             * GAC - Global Assembly Cache
             * With the introduction of .Net 4.0 we have 2 GAC's
             * 1. C:\Windows\Assembly - For .Net 2.0 - 3.5 assemblies
             * 2. C:\Windows\Microsoft.NET\assembly - For .NET 4.0 Assemblies
             * 
             * There are 2 ways to install an assembly into GAC
             * 1. Simply drag and Drop
             * 2. Use GacUtil.exe (GAC Utility Tool)
             * 
             * https://www.youtube.com/watch?v=FYmRrEYyhCM&index=4&list=PL8598C97BA1D871C1
             * 
             * Advantages of using the GAC
             * 1. Side-by-side versioning
             * 2. Sharing of assemblies
             * 3. The assembly signature is verified before it is installed on the GAC,
             *    so when the assembly will be loaded by the CLR when it is executed,
             *    it skips verification, improving the startup time of your application.
             * 4. Possiblity to precompile the assemblies, so they won't need to be 
             *    compiled by the JIT compiler everytime you load them.  This can speed
             *    up the start up process.  To do that you must run a utlity called 
             *    ngen.exe (Native Image Generator).
             * 
             * 
             * Delay signing an Assembly
             * - Obtain public key pair created by using Strong Name tool provided by Windows Software Development Kit(SDK)
             * To keep password secret but still have other developers working with your application,
             * you must use Delay sign 
             * https://docs.microsoft.com/en-us/dotnet/framework/app-domains/delay-sign-assembly
             * 
             * When an assembly needs to be digitally signed, the compiler sighns the assembly using the private key
             * and embeds the public key in the assembly for later verification by other assemblies that refer to it.
             * 
             *************************************************************************************************
             * DLL HELL (Also shows you how to create and use different assemblies)
             * https://www.youtube.com/watch?v=ZNeAmskh-pc&list=PL8598C97BA1D871C1&index=6
             * 
             *************************************************************************************************
             * Create a WinMD Assembly
             * 
             * WinMd - is a Windows Run Time Component allows you to share code across languages in Windows 8
             * Class Libraries - Are how you share code across assemblies or different projects
             * Portable Class Libraries - How you share code across the .Net ecosystem
             * 
             * 
             */
        }
    }
}
