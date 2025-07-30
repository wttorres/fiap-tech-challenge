using TechChallenge.GameStore.Application.Compras.Cadastrar;
using TechChallenge.GameStore.Unit.Test.Application.Compras.Mocks;
using TechChallenge.GameStore.Unit.Test.Application.Promocoes.Mocks;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Cadastrar.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Compras.Fixtures;

public class ComprarJogoHandlerFixture
{
    public UsuarioRepositoryMock UsuarioRepositoryMock { get; private set; }
    public JogoRepositoryMock JogoRepositoryMock { get; private set; }
    public PromocaoRepositoryMock PromocaoRepositoryMock { get; private set; }
    public HistoricoCompraRepositoryMock HistoricoCompraRepositoryMock { get; private set; }
    public BibliotecaJogosRepositoryMock BibliotecaJogosRepositoryMock { get; private set; }

    public ComprarJogoHandler Handler { get; private set; }

    public ComprarJogoHandlerFixture()
    {
        UsuarioRepositoryMock = new UsuarioRepositoryMock();
        JogoRepositoryMock = new JogoRepositoryMock();
        PromocaoRepositoryMock = new PromocaoRepositoryMock();
        HistoricoCompraRepositoryMock = new HistoricoCompraRepositoryMock();
        BibliotecaJogosRepositoryMock = new BibliotecaJogosRepositoryMock();

        Handler = new ComprarJogoHandler(
            UsuarioRepositoryMock.Object,
            JogoRepositoryMock.Object,
            PromocaoRepositoryMock.Object,
            HistoricoCompraRepositoryMock.Object,
            BibliotecaJogosRepositoryMock.Object
        );
    }
}
