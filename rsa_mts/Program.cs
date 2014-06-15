using System;
using System.IO;
using System.Linq;

namespace rsa_mts
{
    public class Program
    {
        /// <summary>
        /// Main Methode
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            TUIRSA program = new TUIRSA("Textfile.txt",new RSA(),new FileRead());
            program.Execute();
            Console.ReadKey();
        }
    }
}