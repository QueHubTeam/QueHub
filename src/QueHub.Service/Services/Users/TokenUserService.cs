using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QueHub.Domain.Entity.User;
using QueHub.Service.Common.Helpers;
using QueHub.Service.Interfaces.Persons;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameMasterArena.Service.Services.Students;

public class TokenUserService : ITokenUserService
{
    private readonly IConfiguration _config;
    public TokenUserService(IConfiguration configuration)
    {
        _config = configuration.GetSection("Jwt");
    }

    public string GenerateToken(UserEntity person)
    {
        var identityClaims = new Claim[]
        {
            new Claim("Id", person.Id.ToString()),
            new Claim("FirstName", person.FirstName),
            new Claim("LastName", person.LastName),
            new Claim("UserName", person.UserName),
            new Claim(GetEmail(), person.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]!));
        var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        int expiresHours = int.Parse(_config["Lifetime"]!);
        var token = new JwtSecurityToken(
            issuer: _config["Issuer"],
            audience: _config["Audience"],
            claims: identityClaims,
            expires: TimeHelper.GetDateTime().AddHours(expiresHours),
            signingCredentials: keyCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GetEmail()
    {
        return ClaimTypes.Email;
    }

}
