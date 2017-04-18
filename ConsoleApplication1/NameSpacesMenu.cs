using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

namespace JesseTesting.App
{
    abstract class NameSpacesMenu
    {

        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" NameSpaces Menu \n ");
                Console.WriteLine(" 0.  Cryptography \n ");
                Console.WriteLine(" 1.  System.Text.StringBuilder \n");
                Console.WriteLine(" 2.  System.Reflection NameSpace \n");
                Console.WriteLine(" 3.  System.Reflection NameSpace - Assembly Class \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    //case 0: DataProtectionSample.DPSMain();
                    //    break;
                    case 1:
                        StringBuilderExamples.PrimaryMain();
                        break;
                    case 2:
                        ReflectionExamples.PrimaryMain();
                        break;
                    case 3:
                        AssemblyClassExamples.GetTypes();
                        Console.ReadKey();
                        AssemblyClassExamples.GetExecutingAssembly();
                        Console.ReadKey();
                        AssemblyClassExamples.Determine_type();
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }


            } while (x < 9);  // end do

        }  // end Menu()

    } // end NamesSpacesMenu Class


    //public class DataProtectionSample
    //{
    //    // Create byte array for additional entropy when using Protect method.
    //    static byte[] s_aditionalEntropy = { 9, 8, 7, 6, 5 };

    //    public static void DPSMain()
    //    {
    //        // Create a simple byte array containing data to be encrypted.

    //        byte[] secret = { 0, 1, 2, 3, 4, 1, 2, 3, 4 };

    //        //Encrypt the data.
    //        //byte[] encryptedSecret = Protect(secret);
    //        Console.WriteLine("The encrypted byte array is:");
    //        //PrintValues(encryptedSecret);

    //        // Decrypt the data and store in a byte array.
    //        //byte[] originalData = Unprotect(encryptedSecret);
    //        Console.WriteLine("{0}The original data is:", Environment.NewLine);
    //        //PrintValues(originalData);

    //    }

    //    public static byte[] Protect(byte[] data)
    //    {
    //        try
    //        {
    //            // Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
    //            //  only by the same current user.
    //            //return ProtectedData.Protect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser);
    //            Console.WriteLine ("The above line does not work ???");
    //        }
    //        catch (CryptographicException e)
    //        {
    //            Console.WriteLine("Data was not encrypted. An error occurred.");
    //            Console.WriteLine(e.ToString());
    //            return null;
    //        }
    //    }

    //    public static byte[] Unprotect(byte[] data)
    //    {
    //        try
    //        {
    //            //Decrypt the data using DataProtectionScope.CurrentUser.
    //            //return ProtectedData.Unprotect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser);
    //            Console.WriteLine("The above line does not work");
    //        }
    //        catch (CryptographicException e)
    //        {
    //            Console.WriteLine("Data was not decrypted. An error occurred.");
    //            Console.WriteLine(e.ToString());
    //            return null;
    //        }
    //    }

    //    public static void PrintValues(Byte[] myArr)
    //    {
    //        foreach (Byte i in myArr)
    //        {
    //            Console.Write("\t{0}", i);
    //        }
    //        Console.WriteLine();
    //    }
    //}

}
