using Moq;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios.Cadastrar.Mocks;

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
}