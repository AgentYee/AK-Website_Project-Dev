using System;
using System.Security.Cryptography;
using System.Text;

namespace AK_Website_Project.Helpers
{
    public static class EncryptionHelper
    {
        #region
        public static String HashToSHA256(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }
        #endregion
    }
}