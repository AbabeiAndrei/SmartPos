﻿using System.Text;
using System.Security.Cryptography;

namespace SmartPos.DomainModel.Security.Crypto
{
    public class Hasher
    {
        public static string CreateMd5(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);
                
                var sb = new StringBuilder();
                foreach (var t in hashBytes)
                    sb.Append(t.ToString("X2"));

                return sb.ToString();
            }
        }
    }
}
