using System;
using System.IO;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Jwt.Console
{
    class Program
    {
        private static string GenerateJSONWebToken(string key)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken("Jwt.Service",
                audience: "Jwt.Client",
                claims: null,
                expires: null,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        static void Main(string[] args)
        {
            var key = System.Console.ReadLine();
            var token = GenerateJSONWebToken(key);
            System.Console.WriteLine(Environment.NewLine + token);

            System.Console.ReadLine();
        }
    }
}
