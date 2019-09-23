using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService
{
    public static class TokenUtils
    {
        public static string GenerateGuidToken(int countOfGuids = 1)
        {
            List<byte> bytes = new List<byte>(16 * countOfGuids);
            for (int i = 0; i < countOfGuids; i++)
            {
                var guid = Guid.NewGuid().ToByteArray();
                bytes.AddRange(guid);
            }

            return Convert.ToBase64String(bytes.ToArray());
        }
    }
}
