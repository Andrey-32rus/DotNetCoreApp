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
        public ActionResult<AuthResponse> Login(LoginRequest request)
        {
            try
            {
                var user = MongoUsers.FindUserByLogin(request.Login);
                if(user == null)
                    return StatusCode(400, null);

                string passwordHash = CryptoUtils.GetSha512Base64Encoded(request.Password);
                if (user.PasswordHash != passwordHash)
                    return StatusCode(400, null);

                DateTime now = DateTime.UtcNow;
                TokenMongo tokenModel = new TokenMongo
                {
                    Id = new TokenMongoPrimaryKey
                    {
                        UserId = user.Id,
                        AppGuid = request.AppGuid,
                    },
                    AccessToken = CryptoUtils.GenerateGuidToken(10),
                    AccessTokenExpires = now.AddMinutes(5),
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
            catch (Exception e)
            {
                MyLogger.Log(e.ToString(), LogLevel.Error, "Auth.Login");
                return StatusCode(500, null);
            }
        }

        [HttpPost("Refresh")]
        public ActionResult<AuthResponse> Refresh(RefreshRequest request)
        {
            try
            {
                var tokenModel = MongoTokens.FindByRefreshToken(request.RefreshToken);

                if(tokenModel == null)
                    return StatusCode(400, null);

                DateTime now = DateTime.UtcNow;
                if (now >= tokenModel.RefreshTokenExpires)
                    return StatusCode(401, null);

                tokenModel.AccessToken = CryptoUtils.GenerateGuidToken(10);
                tokenModel.AccessTokenExpires = now.AddMinutes(5);
                tokenModel.RefreshToken = CryptoUtils.GenerateGuidToken(5);
                tokenModel.RefreshTokenExpires = now.AddDays(30);
                MongoTokens.ReplaceTokenByUserAndAppGuid(tokenModel);
                return new AuthResponse
                {
                    AccessToken = tokenModel.AccessToken,
                    ExpireTime = tokenModel.AccessTokenExpires.ToUnixTimestamp(),
                    RefreshToken = tokenModel.RefreshToken,
                };
            }
            catch (Exception e)
            {
                MyLogger.Log(e.ToString(), LogLevel.Error, "Auth.Refresh");
                return StatusCode(500, null);
            }
        }
    }
}
