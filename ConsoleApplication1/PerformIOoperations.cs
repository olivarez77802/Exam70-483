using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Exam70483
{
    /*
     * Called by ImplementDataAccess.cs
    */
    class PerformIOoperations
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Perform I/O Operations \n ");
                Console.WriteLine("    Read and write files and streams; read and write from the network \n ");
                Console.WriteLine("    by using classes in the System.Net namespace; implement asynchronous \n ");
                Console.WriteLine("    operations \n\n");
                Console.WriteLine(" 0.  List Files in a Directory \n ");
                Console.WriteLine(" 1.  List Directories  \n ");
                Console.WriteLine(" 2.  List Contents of a File \n");
                Console.WriteLine(" 3.  Open URL \n");
                Console.WriteLine(" 4.  .... \n");
                Console.WriteLine(" 5.  Parse Examples \n");
                Console.WriteLine(" 6.  StreamReader \n");
                Console.WriteLine(" 7.  StringReader \n");
                Console.WriteLine(" 8.  ..... \n");
                Console.WriteLine(" 9.  Quit            \n\n ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: ListFiles();
                        break;
                    case 1: ListDir();
                        break;
                    case 2: ListContent();
                        break;
                    case 3: openUrl();
                        break;
                    case 4:
                        break;
                    case 5:
                        ParseExamples.Main_Mod();
                        Console.ReadKey();
                        break;
                    case 6:
                        StreamExamples.StreamMain();
                        break;
                    case 7:
                        StringReaderExamples.SREMain();
                        Console.ReadKey();
                        break;
                    case 8:
                       
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);

        }

        static void ListFiles()
        {
            string contents = System.IO.File.ReadAllText(@"C:\Users\olivarez\My Documents\DemoWeb\Visual C#\Collections.txt");
            // Console.Out.WriteLine(System.IO.Directory.GetFiles(@"C:\Users\olivarez"));
            // string[] filePaths = Directory.GetFiles(@"C:\Users\olivarez\");
            string[] filePaths = Directory.GetFiles(@"C: \Users\olivarez\My Documents\DemoWeb\Visual C#");
            Console.WriteLine("List all of the files (NOT Folders) in Directory");
            for (int i = 0; i < filePaths.Length; ++i)
            {
                // Console.WriteLine("Begin Directory");
                string path = filePaths[i];
                Console.WriteLine(System.IO.Path.GetFileName(path));
                // Console.WriteLine("End Director");
            }
            Console.WriteLine(" End List of Files ");

            Console.ReadKey();

        }

        static void ListDir()
        {
            Console.WriteLine(" Begin Directories C:Users olivarez ");
            string[] dirs = Directory.GetDirectories(@"C:\Users\olivarez");
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine(" End List of Directories  ");
            Console.ReadKey();

            Console.WriteLine(" Begin Directories C: Users olivarez My Documents DemoWeb ");
            string[] dir2 = Directory.GetDirectories(@"C:\Users\olivarez\My Documents\DemoWeb");

            foreach (string dir in dir2)
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine(" End List of Directories  ");
            Console.ReadKey();

            Console.WriteLine(" Begin Directories C: Users olivarez My Documents DemoWeb Visual C#");
            string[] dir3 = Directory.GetDirectories(@"C:\Users\olivarez\My Documents\DemoWeb\Visual C#");

            foreach (string dir in dir3)
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine(" End List of Directories  ");
            Console.ReadKey();
            // Console.Out.WriteLine("contents = " + contents);
        }

        static void ListContent()
        {
            Console.Clear();
            Console.WriteLine(@" Will List Contents of File C:\Users\olivarez\My Documents\AIGA.TXT ");
            Console.WriteLine(" Press any Key to Continue ");
            Console.ReadKey();
            string contents = System.IO.File.ReadAllText(@"C:\Users\olivarez\My Documents\AIGA.TXT");
            Console.Out.WriteLine("contents = " + contents);
            Console.WriteLine(" End of File.. Press any Key to Return to Menu ");
            Console.ReadKey();

        }
        static void openUrl()
        {
            Process.Start("http://www.google.com");
        }
       

    }
}
