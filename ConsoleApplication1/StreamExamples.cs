using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Exam70483
{
    /* 
     * See also ExceptionClassExamples.cs
     * 
     * The FileStream constructor takes four parameters
     * 1. The path to the file
     * 2. The file mode
     * 3. The file access
     * 4. The file share
     * 
     * The file mode, access, and share each have their own table of enumerations.
     * 
     * File Mode Enumeration
     * - An exception is thrown on every mode except Append and OpenOrCreate.
     * Append       - Opens a file if it exists and seeks to the end of the file, or creates a new file if it doesn’t exist. This can be used only with FileAccess.Write.
     * CreateNew    - Creates a new file. If the file already exists, an exception is thrown.
     * Create	    - Creates a new file. If the file already exists it will be overwritten. If the file exists and is hidden, an exception is thrown.
     * Open         - Opens a file. If the file does not exist, an exception is thrown. 
     * OpenOrCreate - Opens a file if it exists or creates a new file if it does not exist.
     * Truncate     - Opens an existing file and truncates the data in the file. If the file does not exist, an exception is thrown.
     * 
     * File Access Enumeration
     * Read -	   Read access to the file
     * Write -	   Write access to the file
     * ReadWrite - Read-and-write access to the file
     * 
     * FileShare Enumeration  - Determines the type of access other streams can have on this file at the same time, you have it open.
     * None -      Does not enable another stream to open the file
     * Read -      Enables subsequent opening of the file for reading only
     * Write -     Enables subsequent opening of the file for writing
     * ReadWrite - Enables subsequent opening of the file for reading or writing
     * Delete -    Enables for subsequent deletion of the file
     * Inheritable-Makes the file handle inheritable by child processes
     */
    public static class StreamExamples
    {
        static void FileStreamExamples()
        {
         FileStream fileStream = new FileStream(@"c:\Users\Olivarez\My Documents\Numbers.txt",
                FileMode.Create, FileAccess.Write, FileShare.None);

            for (int i = 0; i < 10; i++)
            {
                byte[] number = new UTF8Encoding(true).GetBytes(i.ToString());
                fileStream.Write(number, 0, number.Length);
            }
            fileStream.Close();
            Console.WriteLine(@"File c:\Users\Olivarez\My Documents\Numbers.txt written");
            Console.ReadKey();
         }
        static void StreamReaderExample1()
        {
            StreamReader streamreader = new StreamReader(@"c:\Users\Olivarez\My Documents\Numbers.txt");
            Debug.WriteLine("Char by Char");
            while (!streamreader.EndOfStream)
            {
                Debug.WriteLine((char)streamreader.Read());
            }
            streamreader.Close();
            Debug.WriteLine("Char by Char written to output window");
        }

        static void StreamReaderExample2()
        {
            StreamReader streamreader = new StreamReader(@"c:\Users\Olivarez\My Documents\Numbers.txt");
            Debug.WriteLine("Line by line");
            while (!streamreader.EndOfStream)
            {
                Debug.WriteLine(streamreader.ReadLine());
            }
            streamreader.Close();
            Console.WriteLine("Line by Line written to output window");
            Console.ReadKey();
        }
        static void StreamReaderExample3()
        {
            StreamReader streamreader = new StreamReader(@"c:\Users\Olivarez\My Documents\Numbers.txt");
            Debug.WriteLine("Entire file");
            Debug.WriteLine(streamreader.ReadToEnd());
            Console.WriteLine("Entire file written to output window");
        }
        static void StreamWriterExample1()
        {
            StreamWriter streamwriter = new StreamWriter(@"c:\Users\Olivarez\My Documents\StreamWriter.txt");
            streamwriter.WriteLine("ABC");
            streamwriter.Write(true);
            streamwriter.Write(1);
            streamwriter.Close();
            Debug.WriteLine(@"c:\Users\Olivarez\My Documents\StreamWriter.txt File written");
        }
        public static void StreamMain()
        {
            FileStreamExamples();
            StreamReaderExample1();
            StreamReaderExample2();
            StreamReaderExample3();
            StreamWriterExample1();
        }
    }
}
