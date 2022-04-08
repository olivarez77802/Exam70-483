using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.MathService1;


namespace Exam70483.MenuImplementDataAccess
{
    /*
     * With respect to WCF, Serialization is the process of converting an object into XML representation.
     * 
     * Deserialization - The reverse process constructing the same object from XML 
     * 
     * By Default, WCF uses a Data Contract Serializer.
     * 
     * For complex types like Customer, Employee, Student to be serialized, the complex type can be
     * decorated with:
     * 1. SerializableAttribute or
     * 2. DataContractAttribute
     * 
     * WCF DataContract and DataMember
     * With .NET 3.5 and above, we don't have to explicitly use DataContract or 
     * DataMember attributes.  The Data Contract Serializer will serialize all 
     * public properties of your complex type in alphabetic order. By default 
     * private field and properties are not serialized.
     * 
     * If we decorate a complex type, with [Serializable] attribute the DataContract
     * Serializer serializes all fields(including private).  With [Serializable] 
     * attribute we don't have explicit control on what fields to include and
     * exclude serialized data.  The [Serializable] attribute won't let you omit
     * one from being serializable(This is unlike the [DataContract] attribute.
     * 
     * If we decorate a complex type with [Datacontract] attribute, the DataContract
     * Serializer serializes the fields marked with the [DataMember] attribute.  The
     * fields that are not marked with [DataMember] attribute are excluded from
     * serialization.  The [DataMember] attribute can be applied on either the private
     * fields or public properties.
     * 
     * In WCF, the most common way of serialization is to mark the type with the 
     * DataContract attribute and mark each member that needs to be serialized with
     * the DataMember attribute.
     * 
     * If you want to have explicit control on what fields and properties get serialized
     * then use DataContract and DataMember attributes.
     * 1. Using DataContractAttribute, you can define an XML namespace for your data.
     * 2. Using DataMemberAttribute, you can
     *    a) Define Name, Order, and make decision if a property or field is required.
     *    b) Also, serialize private fields and properties.
     * 
     * https://www.youtube.com/watch?v=RPgTKzSGcKY&index=6&list=PL6n9fhu94yhVxEyaRMaMN_-qnDdNVGsL1
     * 
     * Basic Rules of Data Ordering for Data Contract
     * 1. If a data contract type is a part of an inheritance heirarchy, data members of its base
     *    type are always first in order.
     * 2. Next in order are the current type's data members that do not have the "Order" property
     *    of the "DataMemberAttribute" attribute set, in alphabetical order.
     * 3. Next are any data members that have the "Order" property of the "DataMember" Attribute.
     *    These are ordered by the value of the "Order" property first and then alphabetically
     *    if there is more than one member of a certain "Order" value.  Order values may be skipped.
     * 
     * 
    */
    class WCFWebServiceExamples
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" WCF Web Services \n ");
                Console.WriteLine(" 0.  Math Service ");
                Console.WriteLine(" 1.  ... ");
                Console.WriteLine(" 2.  ... ");
                Console.WriteLine(" 3.  ... ");
                Console.WriteLine(" 4.  ....");
                Console.WriteLine(" 5.  ... ");
                Console.WriteLine(" 6.  JSON ");
                Console.WriteLine(" 7.  XML ");
                Console.WriteLine(" 8.  WCF WebService ");
                Console.WriteLine(" 9.  Quit            \n\n ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:

                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        JSONExamples.Menu();
                        Console.ReadKey();
                        break;
                    case 7:
                        XMLExamples.Menu();
                        Console.ReadKey();
                        break;
                    case 8:
                        MathService();
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
        static void MathService()
        {

            MathServiceClient client = new MathServiceClient();

            int result = client.Add(5, 6);
            Console.WriteLine(" Result from WCF WebService Add 5 + 6 is {0}", result);
            int result2 = client.Multiply(5, 6);
            Console.WriteLine(" Result from WCF WebService Multiply 5 * 6 is {0}", result2);
            int result3 = client.Subtract(10, 5);
            Console.WriteLine(" Result from WCF WebService Subtract 10 - 5 is {0}", result3);
            int result4 = client.Divide(10, 5);
            Console.WriteLine(" Result from WCF WebService Multiply 10 / 5 is {0}", result4);
            //Process.Start("https://www.youtube.com/watch?v=GzN1vHWlJjA");
        }

    }
}
