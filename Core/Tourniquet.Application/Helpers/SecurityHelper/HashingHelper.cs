using System.Security.Cryptography;
using System.Text;

namespace Tourniquet.Application.SecurityHelper.Helpers
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

        public static bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            using HMACSHA512 hmac = new(Convert.FromBase64String(passwordSalt));
            string computeHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return computeHash.SequenceEqual(passwordHash);
        }
    }
}