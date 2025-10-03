using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Infrastructure.Autenticacao;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;
    private readonly string _jtwKey;
    private readonly string _jwtAudience;
    private readonly string _jwtIssue;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
        _jtwKey        = Environment.GetEnvironmentVariable("JWT_KEY") ?? configuration["JWT_KEY"];
        _jwtAudience   = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? configuration["JWT_AUDIENCE"];
        _jwtIssue      = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? configuration["JWT_ISSUER"];
    }

    public string GerarToken(Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Perfil.ToString()),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jtwKey!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtIssue,
            audience: _jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}