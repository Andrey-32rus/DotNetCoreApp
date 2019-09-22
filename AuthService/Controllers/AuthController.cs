using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthLib;
using Microsoft.AspNetCore.Mvc;
using NLog;
using UtilsLib;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public ActionResult<AuthResponse> Login(AuthRequest request)
        {
            try
            {
                var user = MongoUsers.FindUserByLogin(request.Login);
                string passwordHash = CryptoUtils.GetSha512Base64Encoded(request.Password);
                if (user.PasswordHash == passwordHash)
                {
                    DateTime now = DateTime.UtcNow;
                    TokenMongo tokenModel = new TokenMongo
                    {
                        Id = new TokenMongoPrimaryKey
                        {
                            UserId = user.Id,
                            AppGuid = request.AppGuid,
                        },
                        AccessToken = CryptoUtils.GenerateGuidToken(10),
                        AccessTokenExpires = now.AddSeconds(60),
                        RefreshToken = CryptoUtils.GenerateGuidToken(5),
                        RefreshTokenExpires = now.AddDays(30),
                    };
                    MongoTokens.ReplaceTokenByUserAndAppGuid(tokenModel);
                    return new AuthResponse
                    {
                        AccessToken = tokenModel.AccessToken,
                        ExpireTime = tokenModel.AccessTokenExpires.ToUnixTimestamp(),
                        RefreshToken = tokenModel.RefreshToken,
                    };
                }

                return StatusCode(400, null);
            }
            catch (Exception e)
            {
                MyLogger.Log(e.ToString(), LogLevel.Error, "Auth.Login");
                return StatusCode(500, null);
            }
        }
    }
}
