using System;
using System.IO;
using System.Linq;

namespace rsa_mts
{
    internal class Program
    {
        /// <summary>
        /// Main Methode
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var readBytes = FileRead.Read("Textfile.txt");
            var readInts = readBytes.Select(Convert.ToInt32)
                                    .ToList();

            Console.WriteLine("Bytes of file:\n");
            foreach (var readInt in readInts)
            {
                Console.Write(readInt+" ");
            }
            Console.WriteLine();

            var rsa = new RSA();

            var encryptedInts = readInts.Select(rsa.Encrypt).ToArray();

            Console.WriteLine("Encrypted data:\n");
            foreach (var encryptedInt in encryptedInts)
            {
                Console.Write(encryptedInt+" ");
            }
            Console.WriteLine();

            var decryptedData = encryptedInts.Select(rsa.Decrypt).ToArray();

            Console.WriteLine("Decrypted data:\n");
            foreach (var i in decryptedData)
            {
                Console.Write(i+" ");
            }
            Console.ReadKey();

            var cryptBytes = decryptedData.Select(Convert.ToByte).ToArray();
            File.WriteAllBytes("out.txt",cryptBytes);
        }
    }
}