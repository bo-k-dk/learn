using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DemoTestAPI
{
    public static class JwtTokenFixer
    {
        public static string GenerateJwtToken(string key)
        {
            var SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credentials);

            var payload = new JwtPayload
            {
                { "sub", "testSubject" },
                { "Name", "Viggo" },
                { "Email", "viggo@mail.dk" },
                { "exp", (int)DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds() },
                { "iss", "https://localhost:7199/" },
                { "aud", "https://localhost:7199/" },
            };

            var secToken = new JwtSecurityToken(header, payload);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(secToken);

            return token;
        }

        public static 
    }
}
