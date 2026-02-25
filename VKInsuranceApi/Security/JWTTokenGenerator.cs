using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace VKInsuranceApi.Security
{
    public class JWTTokenGenerator
    {
        public IConfiguration _configuration;
        public JWTTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateJWTToken(string CustomerEmail, int? CustomerId)
        {
            var claims = new[]
                       {
                            new Claim(JwtRegisteredClaimNames.Sub,CustomerEmail),
                            new Claim("CustomerId",CustomerId.ToString()),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                        };

            var secret = _configuration["Jwt:Key"];
            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new InvalidOperationException("JWT signing key is not configured. Set 'Jwt:Key' in configuration.");
            }

            var secretBytes = Encoding.UTF8.GetBytes(secret);
            if (secretBytes.Length < 16) // 16 bytes = 128 bits
            {
                throw new InvalidOperationException("The JWT signing key must be at least 128 bits (16 bytes).");
            }


            var key = new SymmetricSecurityKey(secretBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(20),
                signingCredentials: creds

                );

            //create token
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
