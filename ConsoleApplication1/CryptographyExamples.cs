using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;




namespace JesseTesting.App
{
    class CryptographyExamples
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Crytography Menu \n ");
                Console.WriteLine(" 0.  Hashing \n ");
                Console.WriteLine(" 1.  Symmetric Algorithms \n ");
                Console.WriteLine(" 2.  Asymmetric Algorithms \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0: Hashing();
                        Console.ReadKey();
                        break;
                   // case 1: Symmetric_Default();
                   //     Console.ReadKey();
                   //     break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 9: x = 9;
                        break;
                    default: Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);

        }

        static void Hashing()
        {
            string plaintext = "This is a simple demonstration of hashing ";

            SHA512Managed hashSvc = new SHA512Managed();

            byte[] hash = hashSvc.ComputeHash(Encoding.UTF8.GetBytes(plaintext));

            //This converts 64 byte hash into the string  hex representation
            //of byte values "FB-2F-85-C8-67-F3..."; each pair respresents the 
            //byte value of 0-255.   Removing the "-" separator creates a
            //128 character string

            string hex = BitConverter.ToString(hash).Replace("-", "");

            Console.WriteLine(plaintext);
            Console.WriteLine("Hashes to :");
            Console.WriteLine(hex);
        }
        public class Symmetric_Default
        {
            // Symmetric Algorithms
            // * Encryption and Decryption use the same (secret) key
            // * .Net Symmetric algorithms are 'block ciphers'.
            // 

            //protected void ButtonEncrypt_Click()
            //{
            //    string Plaintext = "Symmetric Algorithms Example";
            //    RijndaelManaged cipher = CreateCipher();
            //    // IV - Initialization Vector
            //    // Show the IV on page (will use for decrypt, normally send in clear along with ciphertext
            //    var TextBoxIVText = Convert.ToBase64String(cipher.IV);

            //    // Create the encryptor, convert to bytes and encrypt

            //    ICryptoTransform cryptTransform = cipher.CreateEncryptor();
            //    byte[] plaintext = Encoding.UTF8.GetBytes(Plaintext);
            //    byte[] ciphertext = cryptTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);

            //    // convert to 64 bytes for display
            //    var TextBoxCipherText = Convert.ToBase64String(ciphertext);

            //}

            //private RijndaelManaged CreateCipher()
            //{
            //    RijndaelManaged cipher = new RijndaelManaged();
            //    cipher.KeySize = 256;
            //    cipher.BlockSize = 256;   // use 128 bit to be AES Compliant
            //    cipher.Padding = PaddingMode.ISO10126;
            //    cipher.Mode = CipherMode.CBC;

            //    // Read the key from the config file
            //    byte[] key =
            //        conversions.HexToByteArray(WebConfigurationManager.AppSetting["AES256"]);
            //    cipher.Key = key;
            //    return cipher;

            //}
        }
    }
}
