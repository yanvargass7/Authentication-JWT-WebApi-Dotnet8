using AuthenticationJWT.Domain.Interfaces;
using AuthenticationJWT.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationJWT.Application.Applications
{
    public class TokenApp : IToken
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository<User> _userRepository;
        public TokenApp(IConfiguration configuration, IUserRepository<User> user)
        {
            _configuration = configuration;
            _userRepository = user;
        }
        public string GenerateToken(User user)
        {
            var userDB = _userRepository.GetByUserName(user.UserName);
            if (user.UserName != userDB.UserName || user.Password != userDB.Password)
                return String.Empty;

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                                (_configuration["Jwt:key"] ?? string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken
            (

                issuer: issuer,
                audience: audience,

                //(ajustar role aqui está fixo validar tipo e apliclar no enum)
                claims: new[]
                {new Claim(type:ClaimTypes.Name, value: userDB.UserName),
                 new Claim(type:ClaimTypes.Role, value: Role.Admin.ToString())},

                expires: DateTime.Now.AddHours(2),
                signingCredentials: signinCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
    }
}
