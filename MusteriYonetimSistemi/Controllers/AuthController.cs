using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MusteriYonetimSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        string signingKey = "Bu Benim Signing Keyim Gizli bir anahtardir";
        [HttpGet]
        public string Get(string username, string password)

        {
            
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Email, username)
            };
            
            var securityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
              issuer: "https://github.com/ismailyilmazer",
              audience:"AudienceDegeri",
              claims:claims,
              expires:DateTime.Now.AddDays(4),
              notBefore:DateTime.Now,
              signingCredentials:credentials
                );
            var token=new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;

        }

        [HttpGet("ValidateToken")]

        public bool Validatetoken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            try {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                jwtSecurityTokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                  
                  ValidateLifetime=true,
                  ValidateAudience=false,

                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var claims=jwtToken.Claims.ToList();
            }
            catch(SystemException){ 
                return false;
            }
            return true;
        }
    }
}
