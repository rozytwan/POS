using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.FonePayApi
{
  public  class FonePayDataValidation
    {
        public static string SHA512_keyHash(string key, string message)
        {
            var hash = new StringBuilder();
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputeBytes = Encoding.UTF8.GetBytes(message);
            using (var hmac = new HMACSHA512(secretKeyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputeBytes);
              
                    foreach (var theByte in hashValue)
                    {
                        hash.Append(theByte.ToString("X2"));
                    }
            }
            return hash.ToString();
        }
       
    }
}
