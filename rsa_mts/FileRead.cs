using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsa_mts
{
    /// <summary>
    /// A class to savely read a textfile into a byte array.
    /// </summary>
    public class FileRead
    {
        /// <summary>
        /// Reads the specified filepath.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">No file with this path.</exception>
        /// <exception cref="System.Exception">Could not read this file.</exception>
        public byte[] Read(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new ArgumentException("No file with this path.");
            }
            else
            {
                try
                {
                    return File.ReadAllBytes(filepath);
                }
                catch (IOException)
                {
                    throw new Exception("Could not read this file.");
                }
            }
        }
    }
}
