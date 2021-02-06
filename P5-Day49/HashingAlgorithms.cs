using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            string passwordToBeHashed = "salih";


            /*
                Hashing Encryption Methods
             */
            Console.WriteLine("MD5 Hashing : " + MD5(passwordToBeHashed) + "\n");

            Console.WriteLine("SHA1 Hash : " + SHA1(passwordToBeHashed) + "\n");

            Console.WriteLine("SHA256 Hash : " + SHA256(passwordToBeHashed) + "\n");

            Console.WriteLine("SH384 Hash : " + SHA384(passwordToBeHashed) + "\n");

            Console.WriteLine("SH512 Hash : " + SHA512(passwordToBeHashed) + "\n");

            Console.WriteLine("SHA512 Managed Hash : " + HMACSHA512(passwordToBeHashed) + "\n");

            Console.WriteLine("Custom Hash : " + GenerateHash(passwordToBeHashed) + "\n");

            /*
                Symetric Encryption Methods
             */
            //Console.WriteLine("Tryple DES : " + ENCRYPT_DES(passwordToBeHashed) + "\n");

            /*
                Ayymetric Encryption Methods
             */
            //Console.WriteLine("RSA : " + ENCRYPT_RSA(passwordToBeHashed, "") + "\n");


            Console.ReadKey();
        }

        // MD5 Encryption
        public static string MD5(string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedPassword = md5.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedPassword).Replace("-", String.Empty);
        }

        // SHA1 Encryption
        public static string SHA1(string input)
        {
            SHA1Managed sha1 = new SHA1Managed();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedPassword = sha1.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedPassword).Replace("-", String.Empty);
        }

        // SHA256 Encryption
        public static string SHA256(string input)
        {
            SHA256Managed sha256 = new SHA256Managed();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedPassword = sha256.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedPassword).Replace("-", String.Empty);
        }

        // SHA384 Encryption
        public static string SHA384(string input)
        {
            SHA384Managed sha384 = new SHA384Managed();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedPassword = sha384.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedPassword).Replace("-", String.Empty);
        }

        // SHA512 Encryption
        public static string SHA512(string input)
        {
            SHA512Managed sha512 = new SHA512Managed();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedPassword = sha512.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedPassword).Replace("-", String.Empty);
        }

        // HMAC SHA512 Encryption
        public static string HMACSHA512(string input)
        {
            HMACSHA512 sha512 = new HMACSHA512();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedPassword = sha512.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedPassword).Replace("-", String.Empty);
        }

        // Custom Hash Generator
        private static int GenerateHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input).ToList();

            var counter = 4 - bytes.Count % 4;
            for (var i = 0; i < counter; i++)
            {
                bytes.Add(default(byte));
            }
            bytes.TrimExcess();

            var hash = default(int);
            for (var i = 0; i < bytes.Count; i += 4)
            {
                var row = BitConverter.ToInt32(new[] { bytes[i], bytes[i + 1], bytes[i + 2], bytes[i + 3] }, 0);
                hash ^= row;
            }
            return hash;
        }

        private static byte[] ConvertBYTE8(string value)
        {
            char[] arr = value.ToCharArray();
            byte[] bytes = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                bytes[i] = Convert.ToByte(arr[i]);
            }
            return bytes;
        }

        /*
            Symetric Methods
        */
        public static string ENCRYPT_DES(string input)
        {
            byte[] keys = ConvertBYTE8("123456781234567812345678");
            byte[] IV = ConvertBYTE8("12345678");

            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(keys, IV), CryptoStreamMode.Write);

            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(input);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            string result = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            writer.Dispose();
            memoryStream.Dispose();

            return result;
        }
        public static string DECRYPT_DES(string input)
        {
            byte[] keys = ConvertBYTE8("123456781234567812345678");
            byte[] IV = ConvertBYTE8("12345678");

            TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(input));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoServiceProvider.CreateDecryptor(keys, IV), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);

            string result = reader.ReadToEnd();
            reader.Dispose();
            cryptoStream.Dispose();
            memoryStream.Dispose();

            return result;
        }

        /*
            Asymetric Methods
         */

        public static byte[] ConvertToByteArray(string value)
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            return byteConverter.GetBytes(value);
        }
        public static string ENCRYPT_RSA(string input, out RSAParameters rSAParameters)
        {
            byte[] arr = ConvertToByteArray(input);
            RSACryptoServiceProvider serviceProvider = new RSACryptoServiceProvider();
            rSAParameters = serviceProvider.ExportParameters(true);
            byte[] arrayeturn = serviceProvider.Encrypt(arr, false);

            string result = Convert.ToBase64String(arrayeturn);
            return result;
        }

        public static string DECRYPT_RSA(string input, RSAParameters rSAParameters)
        {
            RSACryptoServiceProvider serviceProvider = new RSACryptoServiceProvider();
            byte[] arr = Convert.FromBase64String(input);


            UnicodeEncoding byteConverter = new UnicodeEncoding();
            serviceProvider.ImportParameters(rSAParameters);

            byte[] arrayeturn = serviceProvider.Encrypt(arr, false);

            string result = byteConverter.GetString(arrayeturn);
            return result;
        }
    }
}
