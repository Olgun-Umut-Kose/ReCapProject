using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePassHash(string pass, out byte[] passHash, out byte[] passSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass));
            }
        }

        public static bool VerifyPassHash(string pass, byte[] passHash, byte[] passSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512(passSalt))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass));
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != passHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}