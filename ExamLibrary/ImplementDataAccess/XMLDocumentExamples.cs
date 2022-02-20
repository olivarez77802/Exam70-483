using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Exam70483
{
    /*
     * XMLDocument Class
     * Represents an XML document. You can use this class to load, validate, edit, add, and position XML in a document.

       Namespace:   System.Xml
       Assembly:  System.Xml (in System.Xml.dll)

       //  https://msdn.microsoft.com/en-us/library/system.xml.xmldocument(v=vs.110).aspx
       //  https://www.w3schools.com/xml/dom_nodes.asp


    
       According to the XML DOM, everything in an XML document is a node:

       The entire document is a document node
       Every XML element is an element node
       The text in the XML elements are text nodes
       Every attribute is an attribute node
       Comments are comment nodes
    
    */

    class XMLDocumentExamples
    {
        public static void Menu()
        {

            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" XMLDocument Class Examples \n ");
                Console.WriteLine(" 0.  Root Node  ");
                Console.WriteLine(" 1.  Child Node ");
                Console.WriteLine(" 3.  .. ");
                Console.WriteLine(" 4.  .. ");
                Console.WriteLine(" 4.  ..  \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        Root_Node();
                        Console.ReadKey();
                        break;
                    case 1:
                        Child_Node();
                        Console.ReadKey();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;

                }


            } while (x < 9);
        } //* End Menu

        static XmlDocument LoadXML()
        {
            XmlDocument doc = new XmlDocument();
            //doc.PreserveWhitespace = true;
            try { doc.Load("booksData.xml"); }
            catch (System.IO.FileNotFoundException)
            {
                doc.LoadXml("<?xml version=\"1.0\"?> \n" +
                "<books xmlns=\"http://www.contoso.com/books\"> \n" +
                "  <book genre=\"novel\" ISBN=\"1-861001-57-8\" publicationdate=\"1823-01-28\"> \n" +
                "    <title>Pride And Prejudice</title> \n" +
                "    <price>24.95</price> \n" +
                "  </book> \n" +
                "  <book genre=\"novel\" ISBN=\"1-861002-30-1\" publicationdate=\"1985-01-01\"> \n" +
                "    <title>The Handmaid's Tale</title> \n" +
                "    <price>29.95</price> \n" +
                "  </book> \n" +
                "</books>");
            }
            return doc;
        }
        static XmlDocument LoadXMLOneNode()
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            try { doc.Load("booksData.xml"); }
            catch (System.IO.FileNotFoundException)
            {
                doc.LoadXml(
                "<book ISBN='1-861001-57-8'>" +
                "<title>Pride And Prejudice</title>" +
                "<price>24.95</price>" +
                "</book>"); 
                
             }
            return doc;
        }
        static void Root_Node()
        {


            //Create the XmlDocument.

            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml("<?xml version='1.0' ?>" +
            //            "<book genre='novel' ISBN='1-861001-57-5'>" +
            //            "<title>Pride And Prejudice</title>" +
            //             "<price>19.95</price>" +
            //            "</book>");
            var doc = LoadXML();

            //Display the document element.
            Console.WriteLine("Document Element OuterXml : {0}", doc.DocumentElement.OuterXml);

            //
            // Couldn't get to work!
            //
            // https://stackoverflow.com/questions/42259600/loading-xmldocument-child-nodes-to-textboxes
            //var txtTitle = doc.LastChild.SelectSingleNode("title").LastChild.Value; 
            //var txtPrice = doc.LastChild.SelectSingleNode("price").LastChild.Value; 
            //Console.WriteLine(" Title is {0} price is {1}", txtTitle, txtPrice);
        }

           
        static void Child_Node()
        {
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml("<book ISBN='1-861001-57-5'>" +
            //            "<title>Pride And Prejudice</title>" +
            //            "<price>19.95</price>" +
            //            "</book>");

            // Doesn't work when I use LoadXML() !!! Not sure why !!! Doesn't make sense to use
            // a special Load Routine !!
            //
            // var doc = LoadXMLOneNode();
            var doc = LoadXML();
            //XmlNode root = doc.FirstChild;
            XmlNode root = doc.DocumentElement;

            Console.WriteLine(" Has Child Nodes {0}", root.HasChildNodes);

            //Display the contents of the child nodes.
            //if (root.HasChildNodes)
            //{
            //    for (int i = 0; i < root.ChildNodes.Count; i++)
            //    {
            //        Console.WriteLine("Child Node - OuterXML {0}", root.ChildNodes[i].OuterXml);
            //        Console.WriteLine("Child Node Inner Text {0}", root.ChildNodes[i].InnerText);
            //    }
            //}

            //Console.WriteLine("Display the last child - OuterXML {0} ", root.LastChild.OuterXml);
            //Console.WriteLine("Display last child - Inner Text {0}", root.LastChild.InnerText);

            foreach (XmlNode book in root)
            {
                foreach (XmlNode element in book)
                {
                   // Console.WriteLine(element.OuterXml);
                    Console.WriteLine(element.InnerText);
                }
               
            }
        }

    }  // End Class

}  // End Namespace
