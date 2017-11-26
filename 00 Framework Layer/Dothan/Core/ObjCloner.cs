using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dothan.Core
{
    internal static class ObjCloner
    {
        public static object Clone(object obj)
        {
            using (MemoryStream buffer = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(buffer, obj);
                buffer.Position = 0;
                object temp = formatter.Deserialize(buffer);
                return temp;
            }
        }
    }
}
