using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_asked_client.Util
{
    internal class RandomString
    {
        private static readonly string STRING_SOURCE = "1234567890qwertyuiopasdfghjklzxcvbnm";
        private static Random random = new Random();

        public static string Create(int length)
        {
            string result = string.Empty;

            for (int i = 0; i < length; ++i)
            {
                result += STRING_SOURCE[random.Next(0, STRING_SOURCE.Length)];
            }

            return result;
        }
    }
}
