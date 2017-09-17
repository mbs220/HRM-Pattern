using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MBS.HR.Patterns.Security
{
    public class ModelSignManager
    {
        public Stream SerializeModel(object model)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, model);
            return stream;

        }
        public byte[] SerializeModelArray(object model)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, model);
            return stream.ToArray();

        }
        public string CalculateMD5Hash(Stream stream)
        {
            byte[] hashed = null;
            using (var md5 = MD5.Create())
            {
                hashed = md5.ComputeHash(stream);
            }

            return Encoding.UTF8.GetString(hashed ?? new byte[0] );
        }
        public string CalculateMD5Hash(byte[] binaryModel)
        {
            byte[] hashed = null;
            StringBuilder sb = new StringBuilder();

            //using (var md5 = MD5.Create())
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                hashed = md5.ComputeHash(binaryModel);
                foreach (byte b in hashed)
                    sb.Append(b.ToString("x2"));

            }

            //return Encoding.UTF8.GetString(hashed ?? new byte[0]);
            //return Encoding.Default.GetString(hashed ?? new byte[0]);
            return sb.ToString();
        }
        public bool HasModelChangedBySign(string sign1,string sign2)
        {
            return string.Compare(sign1, sign2) != 0;
        }

    }
}
