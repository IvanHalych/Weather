using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Weather
{
    static class Serialization
    {
        public static void Save(object file, string File)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream fStream = new FileStream(File+".soap", FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                bin.Serialize(fStream, file);
            }
        }
        public static object Load(string File)
        {
            object file;
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream fStream = new FileStream(File + ".soap", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                if (fStream.Length == 0)
                    file = null;
                else
                file = bin.Deserialize(fStream);
            }
            return file;
        }
    }
}
