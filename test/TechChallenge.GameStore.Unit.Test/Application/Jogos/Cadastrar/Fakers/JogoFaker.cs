using AutoBogus;
using TechChallenge.GameStore.Application.Jogos.Cadastrar;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Unit.Test.Application.Jogos.Cadastrar.Fakers
{
    public static class JogoFaker
    {
        public static Jogo ConverterParaJogo(CadastrarJogoCommand command)
        {
            return new AutoFaker<Jogo>()
                .RuleFor(x => x.Nome, f => command.Nome)
                .RuleFor(x => x.Preco, f => command.Preco)
                .Generate();
        }
    }
}
