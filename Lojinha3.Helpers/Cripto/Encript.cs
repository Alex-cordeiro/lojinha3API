using System;
using System.Text;
using System.Security.Cryptography;

namespace Lojinha3.Helpers.Cripto
{
    public static class Encript
    {
        private static SHA256CryptoServiceProvider algorithm = new SHA256CryptoServiceProvider();
        public static string ComputeHash(string input)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
