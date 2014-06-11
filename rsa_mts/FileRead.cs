using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsa_mts
{
    public static class FileRead
    {
        public static byte[] Read(string filepath)
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
