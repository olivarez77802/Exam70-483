using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
//using System.IO;
//using System.Runtime.Serialization.Json;

namespace JesseTesting.App
{
    public class SerializationExamples
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
        public static void XMLMain()
        {
            class1 c = new class1();
            c.Age = 10;
            c.Male = true;
            c.Name = "Jesse";
            c.Save("TestFile.xml");
        }
        public static class1 LoadFromFile(string fileName) 
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(class1));
                return (class1)XML.Deserialize(stream);
            }
        }
        public static void XMLMainDeserialize()
        {
            class1 c = LoadFromFile("TestFile.xml");
            Console.WriteLine
                
                
                
                
                
                
                (" Age = {0}, Name = {1}", c.Age, c.Name); 

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
