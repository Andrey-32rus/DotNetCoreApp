using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthLib;
using Microsoft.AspNetCore.Mvc;
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
                string passwordHash = CryptoUtils.GetSha512(request.Password);
                if (user.PasswordHash == passwordHash)
                {
                    DateTime now = DateTime.UtcNow;
                    TokenMongo tokenModel = new TokenMongo
                    {
                        UserId = user.Id,
                        AppGuid = request.AppGuid,

                        AccessToken = TokenUtils.GenerateToken(),
                        AccessTokenExpires = now.AddSeconds(60),
                        RefreshToken = TokenUtils.GenerateToken(),
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
                return StatusCode(500, null);
            }
        }
    }
}
