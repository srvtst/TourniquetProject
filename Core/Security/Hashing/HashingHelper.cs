﻿using System.Security.Cryptography;
using System.Text;

namespace CoreLayer.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        public static bool VerifyPasswordHash(string password, string passwordSalt, string passwordHash)
        {
            byte[] salt = Convert.FromBase64String(passwordSalt);
            byte[] hash = Convert.FromBase64String(passwordHash);
            using (var hmac = new HMACSHA512(salt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != hash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}