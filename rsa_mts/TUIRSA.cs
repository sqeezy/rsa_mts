using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
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
        private readonly string _textfilePath;
        private readonly string _filepathForDecryption;
        private readonly FileRead _fileRead;
        private readonly bool _readableConsole;
        private readonly RSA _rsa;

        /// <summary>
        /// Initializes a new instance of the <see cref="TUIRSA"/> class.
        /// This class controls the flow of the program.
        /// </summary>
        /// <param name="textfilePath">The filepath of the textfile to work with.</param>
        /// <param name="filepathForDecryption">The filepath of the textfile to output the en.</param>
        /// <param name="rsa">The RSA-implementation in use.</param>
        /// <param name="fileRead">A class to read the textfile.</param>
        /// <param name="readableConsole">Set this to true if your output gets to much to read.</param>
        public TUIRSA(string textfilePath, string filepathForDecryption, RSA rsa, FileRead fileRead,
            bool readableConsole = true)
        {
            _textfilePath = textfilePath;
            _filepathForDecryption = filepathForDecryption;
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
            byte[] readBytes = _fileRead.Read(_textfilePath);

            List<BigInteger> readInts = readBytes.Select(x => new BigInteger(x)).ToList();
            PrintCollection(readInts, String.Format("Bytes written from {0}:", _textfilePath));

            var encryptedInts = readInts.Select(_rsa.Encrypt).ToArray();
            PrintCollection(encryptedInts, "The encrypted values:");


            try
            {
                int elementsInARow = 1;
                String text = "";
                foreach (int k in encryptedInts)
                {
                    text += k;
                    text += " ";
                    if (elementsInARow == 7)
                    {
                        text += "\n";
                        elementsInARow = 0;
                    }
                    elementsInARow++;
                }

                File.WriteAllText("encrypted.txt", text);
                Console.WriteLine("\nYou can find the encrypted text in 'encrypted.txt'.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nCouldnt write output-file: {0},{1}", e, e.StackTrace);
            }
            string decryptedString="";

            //if filepath is given we take out the data from file
            if (_filepathForDecryption != null)
            {
                decryptedString = File.ReadAllText(_filepathForDecryption);
            }

            //eliminate all returns
            decryptedString = decryptedString.Replace('\n', ' ');

            //while splitting the string the spaces will be cleared
            string[] decrypt = decryptedString.Split(' ');

            //problem is we dont have only integers in our array so we need a List to eliminate them
            //because we dont know how big pur Array is if all ("") are eliminated
            List<BigInteger> decryptliste = new List<BigInteger>();

            //each integer of array will be added in the list 
            for (int i = 0; i < decrypt.Length; ++i)
            {
                try
                {
                    int num1;
                    bool Parsable = Int32.TryParse(decrypt[i], out num1);
                    {
                        //if it isn't parsable, it won't be added 
                        if (Parsable)
                        {
                            decryptliste.Add(Int32.Parse(decrypt[i]));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Can't parse decrypted things in int's", e, e.StackTrace);
                }
            }
            //now encrypted Values can be filled as ints in the array
            var decryptedArray = decryptliste.ToArray();

            //after running decription, dercrypted Data filled with the correct values 
            var decryptedData = decryptedArray.Select(_rsa.Decrypt).ToArray();

            PrintCollection(decryptedData, "Decrypted data:");


            byte[] cryptBytes = decryptedData.Select(x => Convert.ToByte((int)x)).ToArray();

            try
            {
                //Write the Text in the File 
                File.WriteAllBytes("decrypted.txt", cryptBytes);
                Console.WriteLine("\nYou can find the decrypted text in 'decrypted.txt'.");
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
        private void PrintCollection(IEnumerable<BigInteger> collection, string headline)
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