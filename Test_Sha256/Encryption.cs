using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Test_Sha256
{
    public static class Encryption
    {
        public static string ToHex(byte[] bytes, bool upperCase, bool toString)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (toString)
                    result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));
                else
                    result.Append(bytes[i]);
            }
            return result.ToString();
        }

        public static string SHA256HexHashString(string StringIn, bool toString)
        {
            string hashString;
            using (var sha256 = SHA256Managed.Create())
            {
                var hash = sha256.ComputeHash(Encoding.Default.GetBytes(StringIn));
                hashString = ToHex(hash, false, toString);
            }

            return hashString;
        }
    }
}
