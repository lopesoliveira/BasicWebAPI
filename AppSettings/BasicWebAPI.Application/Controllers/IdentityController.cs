using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using AppSettings.BasicWebAPI.Domain.Entities;

namespace BasicWebAPI.Application.Controllers {
   
    public class IdentityController : ControllerBase {

        private const string TokenSecret = "ForTheLoveOfGodStoreAndLoadThisSecurely";
        private static readonly TimeSpan TokenLifeTime = TimeSpan.FromMinutes(10);

        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] TokenGenerationRequest request) {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(TokenSecret);

            var claims = new List<Claim> {
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (JwtRegisteredClaimNames.Sub, request.Email!),
                new (JwtRegisteredClaimNames.Email, request.Email!),
                new Claim("userid", request.UserId !.ToString())
            };

            foreach(var claimPair in request.CustomClaims!) {
                var jsonElement = (JsonElement)claimPair;
                var valueType = jsonElement.ValueKind switch {
                    JsonValueKind.True => ClaimValueTypes.Boolean,
                    JsonValueKind.False => ClaimValueTypes.Boolean,
                    JsonValueKind.Number => ClaimValueTypes.Double,
                    _ => ClaimValueTypes.String
                };

                var claim = new Claim(claimPair.Key, claimPair.Value.ToString(), valueType);
                claims.Add(claim);
            }

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims) ,
                Expires = DateTime.UtcNow.Add(TokenLifeTime) ,
                Issuer = "https://id.nickchapsas.com" ,
                Audience = "https://movies.nickchapsas.com" ,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            var jwt = tokenHandler.WriteToken(token);
            return Ok(jwt);

        }
    }
}
