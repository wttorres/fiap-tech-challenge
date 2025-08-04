using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FluentAssertions;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Autenticacao.Fakers;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Autenticacao.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Autenticacao;

public class JwtTokenServiceTest : JwtTokenServiceFixture
{
    [Fact]
    public void GerarToken_QuandoUsuarioValido_DeveRetornarTokenComClaimsCorretos()
    {
        // Arrange
        var usuario = UsuarioFaker.Valido();
        usuario.Perfil = TechChallenge.GameStore.Domain.Usuarios.Perfil.Admin;

        // Act
        var token = TokenService.GerarToken(usuario);

        // Assert
        token.Should().NotBeNullOrWhiteSpace();

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        jwtToken.Claims.Should().ContainSingle(c => 
            c.Type == ClaimTypes.Name && c.Value == usuario.Email);

        jwtToken.Claims.Should().ContainSingle(c => 
            c.Type == ClaimTypes.Role && c.Value == usuario.Perfil.ToString());

        jwtToken.Claims.Should().ContainSingle(c => 
            c.Type == ClaimTypes.NameIdentifier && c.Value == usuario.Id.ToString());

        jwtToken.Issuer.Should().Be("GameStore.Issuer.Teste");
        jwtToken.Audiences.Should().Contain("GameStore.Audience.Teste");
        jwtToken.ValidTo.Should().BeAfter(DateTime.UtcNow);
    }
}