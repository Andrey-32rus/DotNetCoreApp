using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Jwt.Service
{
    public static class AuthOptions
    {
        public const string ISSUER = "Jwt.Service"; // издатель токена
        const string KEY = "S2V5IGZvciBKd3QgQXV0aCBTZXJ2aWNlOiB7VEUlVnZWeWlzczhBIz9POCRwSyA=";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
