using System.Collections.Generic;
using Moq;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios.Mocks;

public class UsuarioRepositoryMock : Mock<IUsuarioRepository>
{
    public void ConfigurarParaRetornarUsuarioAoObterPorEmail(Usuario usuario)
    {
        Setup(x => x.ObterPorEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(usuario);
    }

    public void ConfigurarParaRetornarUsuarioAoAdicionar(Result<Usuario> resultado)
    {
        Setup(x => x.AdicionarAsync(It.IsAny<Usuario>()))
            .ReturnsAsync(resultado);
    }

    public void GarantirChamadaAdicionar()
    {
        Verify(x => x.AdicionarAsync(It.IsAny<Usuario>()), Times.Once);
    }

    public void GarantirQueNaoChamouAdicionar()
    {
        Verify(x => x.AdicionarAsync(It.IsAny<Usuario>()), Times.Never);
    }

    public void ConfigurarParaObterPorId(Usuario usuario)
    {
        Setup(r => r.ObterPorIdAsync(usuario.Id))
            .ReturnsAsync(usuario);
    }

    public void ConfigurarParaObterUsuarios(IEnumerable<Usuario> usuarios)
    {
        Setup(x => x.ObterTodosAsync())
            .ReturnsAsync((List<Usuario>) usuarios);
    }

    public void ConfigurarParaAtualizar(Result<Usuario> resultado)
    {
        Setup(r => r.AtualizarAsync(It.IsAny<Usuario>()))
            .ReturnsAsync(resultado);
    }
}