using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;
//using System.IO;
//using System.Runtime.Serialization.Json;

namespace Exam70483
{
    public class XMLExamples
    {
        public class class1
        {
            public int Age { get; set; }
            public bool Male { get; set; }
            [XmlAttribute]
            public string Name { get; set; }
            public void Save(string FileName)
            {
                using (var stream = new FileStream(FileName, FileMode.Create))
                {
                    var XML = new XmlSerializer(typeof(class1));
                    XML.Serialize(stream, this);
                }
            }
        } // end class1
        public static void Menu()
        {
           
           
          
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" XML Examples \n ");
                Console.WriteLine(" 0.  XML Serialize - Convert class and values into XML \n ");
                Console.WriteLine(" 1.  XML DeSerialize - Load Raw XML into a class \n ");
                Console.WriteLine("     Navigate Document Tree");
                Console.WriteLine(" 2.  Root Node \n ");
                Console.WriteLine(" 3.  Child Node \n ");
                Console.WriteLine(" 4.  ....  \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");

                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        XMLSerialize();
                        Console.ReadKey();
                        break;
                    case 1:
                        XMLDeSerialize();
                        Console.ReadKey();
                        break;
                    case 2:
                        Root_Node();
                        Console.ReadKey();
                        break;
                    case 3:
                        Child_Node();
                        Console.ReadKey();
                        break;
                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;

                }


            } while (x < 9);
        }

        static void XMLSerialize()
        {
            class1 c = new class1();
            c.Age = 10;
            c.Male = true;
            c.Name = "Jesse";
            Console.WriteLine("Serailize - Convert class and values into XML\n");
            Console.WriteLine(@"Raw XML stored in C:\Users\jesse-olivarez\Documents\Repositories\Exam70-483\ConsoleApplication1\bin\Debug");
            c.Save("TestFile.xml");
        }
        static void XMLDeSerialize()
        {
            Console.WriteLine("DeSerialize - Load Raw XML File into class");
            XMLDeserialize();

        }
        static void Root_Node()
        {
            //  https://msdn.microsoft.com/en-us/library/system.xml.xmldocument(v=vs.110).aspx
            //  https://www.w3schools.com/xml/dom_nodes.asp
            //Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<?xml version='1.0' ?>" +
                        "<book genre='novel' ISBN='1-861001-57-5'>" +
                        "<title>Pride And Prejudice</title>" +
                         "<price>19.95</price>" +
                        "</book>");

            //Display the document element.
            Console.WriteLine("Document Element OuterXml : {0}",doc.DocumentElement.OuterXml);

           
        }
        static void Child_Node()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<book ISBN='1-861001-57-5'>" +
                        "<title>Pride And Prejudice</title>" +
                        "<price>19.95</price>" +
                        "</book>");

            XmlNode root = doc.FirstChild;

            Console.WriteLine(" Has Child Nodes {0}", root.HasChildNodes);

            //Display the contents of the child nodes.
            if (root.HasChildNodes)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    Console.WriteLine("Child Node Inner Text {0}", root.ChildNodes[i].InnerText);
                }
            }
        }
        static class1 LoadFromFile(string fileName) 
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(class1));
                return (class1)XML.Deserialize(stream);
            }
        }
        static void XMLDeserialize()
        {
            class1 c = LoadFromFile("TestFile.xml");
            Console.WriteLine(" Age = {0}, Name = {1}", c.Age, c.Name); 

        }



        public class Employee
        {
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string gender { get; set; }
            public int salary { get; set; }
        }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee()
            {
            firstname = "Todd",
            lastname = "Grover",
            gender = "Male",
            salary = 50000
            },
            new Employee()
            {
            firstname = "Sara",
            lastname = "Baker",
            gender = "Female",
            salary = 40000
            }
        };
            return employees.ToList();
        }

        List<Employee> employees2 = GetAllEmployees();
        //JavaScriptSerializer javScriptSerializer = new JavaScriptSerializer();
        //string jsonString = javaScriptSerializer.Serialize(employees2);


        //class SerializationExamples
        //{
        //    [DataContract]
        //    internal class Person
        //    {
        //        [DataMember]
        //        internal string name;

        //        [DataMember]
        //        internal int age;
        //    }


        //    public static void JSONSerializer()
        //    {
        //        Person p = new Person();
        //        p.name = "John";
        //        p.age = 42;

        //        MemoryStream stream1 = new MemoryStream();
        //        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));

        //        ser.WriteObject(stream1, p);

        //        stream1.Position = 0;
        //        StreamReader sr = new StreamReader(stream1);
        //        Console.Write("JSON form of Person object: ");
        //        Console.WriteLine(sr.ReadToEnd());

        //        Console.WriteLine(" JSON DeSerializer");
        //        stream1.Position = 0;
        //        Person p2 = (Person)ser.ReadObject(stream1);
        //        Console.Write("Deserialized back, got name=");
        //        Console.Write(p2.name);
        //        Console.Write(", age=");
        //        Console.WriteLine(p2.age);

        //    }

        //}



    } // end class SerializationExamples

}
