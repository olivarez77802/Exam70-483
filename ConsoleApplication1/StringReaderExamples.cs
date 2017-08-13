using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Exam70483.App.App
{
   // http://www.dotnetperls.com/stringreader

    class StringReaderExamples
    {
        
            const string _input = @"Dot Net Perls
is a website
you are reading";

            public static void SREMain()
            {
                // Creates new StringReader instance from System.IO
                using (StringReader reader = new StringReader(_input))
                {
                    // Loop over the lines in the string.
                    int count = 0;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        count++;
                        Console.WriteLine("Line {0}: {1}", count, line);
                    }
                }
            }
        }
    
}
