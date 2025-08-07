using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechChallenge.GameStore.Domain.Compras;

namespace TechChallenge.GameStore.Unit.Test.Application.Compras.Mocks
{
    public class BibliotecaJogosRepositoryMock : Mock<IBibliotecaJogosRepository>
    {
        public void ConfigurarAdicionarAsync()
        {
            Setup(r => r.AdicionarAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Task.CompletedTask);
        }

        public void ConfigurarUsuarioJaPossuiJogoAsync(int usuarioId, int jogoId, bool possui)
        {
            Setup(r => r.UsuarioJaPossuiJogoAsync(usuarioId, jogoId))
                .ReturnsAsync(possui);
        }

        public void ConfigurarObterPorUsuarioIdAsync(int usuarioId, List<BibliotecaJogo> jogos)
        {
            Setup(r => r.ObterPorUsuarioIdAsync(usuarioId))
                .ReturnsAsync(jogos);
        }

        public void ConfigurarNaoPossuiJogo()
        {
            Setup(r => r.UsuarioJaPossuiJogoAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(false);

            Setup(r => r.AdicionarAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Task.CompletedTask);
        }
    }
}
