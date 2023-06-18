using Application.Common.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Duende.IdentityServer.Models;

namespace Infrastructure.Identity;

public class TokenService : ITokenService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public TokenService(
        UserManager<ApplicationUser> userManager,
        IApplicationDbContext context,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _context = context;
        _configuration = configuration;
    }

    public async Task<string> GetTokenAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var token =  GetToken(roles.ToList(), user.Id, out string refreshToken);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(_configuration.GetValue<int>("ApplicationSettings:Jwt:ExpiryMinutes"));

        await _context.SaveChangesAsync(cancellationToken);

        return token;
    }

    public string GetToken(List<string> roles, string userId, out string refreshToken)
    {
        var issuer = _configuration.GetValue<string>("ApplicationSettings:Jwt:Issuer");
        var expiryMinutes = _configuration.GetValue<int>("ApplicationSettings:Jwt:ExpiryMinutes");
        var secret = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("ApplicationSettings:Jwt:Secret"));

        refreshToken = GenerateRefreshToken();

        var claims = new List<Claim>();
        claims.Add(new Claim("UserId", userId));
        claims.Add(new Claim("RefreshToken", refreshToken));
        roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(secret),
                SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);

        return token;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        rng.Dispose();
        return Convert.ToBase64String(randomNumber);
    }
}