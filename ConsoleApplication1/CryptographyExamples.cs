using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;




namespace Exam70483
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
                Console.WriteLine(" 3.  .... \n");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        Hashing();
                        Console.ReadKey();
                        break;
                    case 1:
                        /*
                         * Symmetric Encryption
                         * - One key is used for both encryption and decryption
                         * - Faster than asymmetric encryption
                         * - Cryptography namespace includes five symmetric algorithms
                         *    # Aes (recommended)
                         *    # DES
                         *    # RC2
                         *    # Rijndael (Same algorithm as Aes. Aes more secure)
                         *    # TripleDES
                         *    
                         *    https://www.youtube.com/watch?v=Tjeb8yCeWE8
                        */
                        //Symmetric_Default();
                        Console.ReadKey();
                        break;
                    case 2:
                        /*
                         * Asymmetric (or Public Key) Encryption
                         * - One key is used for encryption and another key for decryption
                         * - Commonly used for digital signatures
                         * - Cryptography namespace includes four aymmetric algorithms:
                         *   # DSA
                         *   # ECDffieHellman
                         *   # ECDsa
                         *   # RSA (Most popular)
                         *   
                         *   Microsoft recommmends the following algorithms to be used in the following situations:
                         *   - For data privacy, use AES.
                         *   - For data integrity, use HMACSHA256 or HMACSHA512
                         *   - For digital signatures, use RSA or ECDiffieHellman
                         *   - For random number generation, use RNGCryptoServiceProvider.
                         *   - For generating a key from a password, use Rfc2898DeriveBytes
                         *   
                         *   You can send out your public key, others can use the key to encrypt data they want to 
                         *   send to you.  You are the only one who can decrypt the data sent to you since you are
                         *   the only one with the private key. 
                        */
                        RSA_Sample();
                        Console.ReadKey();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
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

        static void RSA_Sample()
        {
            /*
             * Create parameters that will used with the RSACryptoServiceProvider
            */
            string keyContainerName = "MyKeyContainer";
            string clearText = "This is data we want to encrypt!";
            CspParameters cspParams = new CspParameters();
            // Specify that you want the keys to be saved in a container called "MyKeyContainer"
            cspParams.KeyContainerName = keyContainerName;

            RSAParameters publicKey;
            RSAParameters privateKey;
            /* 
             * Start by generating new encryption keys pair, by creating a new instance of RSACryptoServiceProvider.
             * Object won't be used for encryption/Decryption, only to create public/private keys.  
             */
            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                rsa.PersistKeyInCsp = true;
                // public key generated by setting parameter to false
                publicKey = rsa.ExportParameters(false);
                // private key generated by setting parameter to true
                privateKey = rsa.ExportParameters(true);

                rsa.Clear();
            }

            byte[] encrypted = EncryptUsingRSAParam(clearText, publicKey);
            string decrypted = DecryptUsingRSAParam(encrypted, privateKey);

            Console.WriteLine("Asymmetric RSA - Using RSA Params");
            Console.WriteLine("Encrypted: {0}", Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted: {0}\n", decrypted);
            /*
             * EncryptUsingContainer and DecryptUsingContainer work in the same way, the 
             * only difference is that instead of sending RSAParameters that are used
             * to generate keys, you use the same CrytoServiceProvider container that
             * you used to generate the keys.
             * 
            */

            Console.WriteLine("Asymmetric RSA - Using Persistant Key Container");
            encrypted = EncryptUsingContainer(clearText, keyContainerName);
            decrypted = DecryptUsingContainer(encrypted, keyContainerName);

            Console.WriteLine("Encrypted:{0}", Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted:{0}", decrypted);

        }
        static byte[] EncryptUsingRSAParam(string value, RSAParameters rsaKeyInfo)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaKeyInfo);
                byte[] encodedData = Encoding.Default.GetBytes(value);
                byte[] encryptedData = rsa.Encrypt(encodedData, true);

                rsa.Clear();
                return encryptedData;
            }
        }
        static string DecryptUsingRSAParam(byte[] encryptedData, RSAParameters rsaKeyInfo)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaKeyInfo);
                byte[] decryptedData = rsa.Decrypt(encryptedData, true);
                string decryptedValue = Encoding.Default.GetString(decryptedData);

                rsa.Clear();
                return decryptedValue;
            }
        }
        static byte[] EncryptUsingContainer(string value, string containerName)
        {
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = containerName;
            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                byte[] encodedData = System.Text.Encoding.Default.GetBytes(value);
                byte[] encryptedData = rsa.Encrypt(encodedData, true);

                rsa.Clear();
                return encryptedData;
            }
        }
        static string DecryptUsingContainer ( byte[] encryptedData, string container)
        {
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = container;
            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                byte[] decryptedData = rsa.Decrypt(encryptedData, true);
                string decryptedValue = Encoding.Default.GetString(decryptedData);

                rsa.Clear();
                return decryptedValue;
            }
        }

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

