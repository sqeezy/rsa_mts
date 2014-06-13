using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace rsa_mts
{
    /// <summary>
    /// The class to control the program and execute the needed tasks.
    /// </summary>
    public class TUIRSA
    {
        private readonly string _filepath;
        private readonly FileRead _fileRead;
        private readonly bool _readableConsole;
        private readonly RSA _rsa;

        /// <summary>
        /// Initializes a new instance of the <see cref="TUIRSA"/> class.
        /// This class controls the flow of the program.
        /// </summary>
        /// <param name="filepath">The filepath of the textfile to work with.</param>
        /// <param name="rsa">The RSA-implementation in use.</param>
        /// <param name="fileRead">A class to read the textfile.</param>
        /// <param name="readableConsole">Set this to true if your output gets to much to read.</param>
        public TUIRSA(string filepath, RSA rsa, FileRead fileRead, bool readableConsole = true)
        {
            _filepath = filepath;
            _rsa = rsa;
            _fileRead = fileRead;
            _readableConsole = readableConsole;
        }

        /// <summary>
        /// Executes this instance.
        /// It will read the file, encrypt it, decrypt it again and saves the result to 'out.txt'.
        /// Every step will be visible in the console.
        /// </summary>
        public void Execute()
        {
            byte[] readBytes = _fileRead.Read(_filepath);
            List<int> readInts = readBytes.Select(Convert.ToInt32)
                .ToList();

            PrintCollection(readInts, String.Format("Bytes written from {0}:", _filepath));

            int[] encryptedInts = readInts.Select(_rsa.Encrypt).ToArray();

            PrintCollection(encryptedInts, "The encrypted values:");

            int[] decryptedData = encryptedInts.Select(_rsa.Decrypt).ToArray();

            PrintCollection(decryptedData, "Decrypted data:");

            byte[] cryptBytes = decryptedData.Select(Convert.ToByte).ToArray();


            try
            {
                File.WriteAllBytes("out.txt", cryptBytes);
                Console.WriteLine("\nYou can find the decrypted text in 'out.txt'.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nCouldnt write output-file: {0},{1}", e, e.StackTrace);
            }
        }

        /// <summary>
        /// Prints the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="headline">The headline.</param>
        private void PrintCollection(IEnumerable<int> collection, string headline)
        {
            Console.WriteLine();
            Console.WriteLine("{0}", headline);

            string underlining = string.Empty;
            for (int i = 0; i < headline.Length; i++)
            {
                underlining += "=";
            }
            Console.WriteLine(underlining);

            if (_readableConsole)
            {
                foreach (int i in collection.Take(10))
                {
                    Console.Write(i + " ");
                }
                Console.Write("...");
            }
            else
            {
                foreach (int i in collection)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}