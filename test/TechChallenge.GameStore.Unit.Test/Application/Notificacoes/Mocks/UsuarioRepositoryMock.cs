using System.Collections.Generic;
using Moq;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Mocks;

public class UsuarioRepositoryMock : Mock<IUsuarioRepository>
{
    public void ConfigurarUsuarios(List<Usuario> usuarios)
    {
        Setup(r => r.ObterUsuariosQueRecebemNotificacoesAsync())
            .ReturnsAsync(usuarios);
    }
}