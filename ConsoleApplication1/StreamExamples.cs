using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Exam70483.App.App
{
   abstract class StreamExamples
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
