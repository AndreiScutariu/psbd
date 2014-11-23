using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MedicalClinicHandler.Utils
{
    public class Encrypt
    {
        public static string DoHash(string password)
        {
            return Base64To16(GetBytes(Hash(password)));
        }

        private static string Hash(string password)
        {
            var provider = new SHA384CryptoServiceProvider();
            var passBytes = GetBytes(password);
            var hash = provider.ComputeHash(passBytes);
            var hashString = GetString(hash);
            return hashString;
        }

        private static string Base64To16(ICollection<byte> bytes)
        {
            var hex = new StringBuilder(bytes.Count * 2);
            foreach (var oneByte in bytes)
                hex.AppendFormat("{0:x2}", oneByte);
            return hex.ToString();
        }

        private static byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private static string GetString(byte[] bytes)
        {
            var chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}