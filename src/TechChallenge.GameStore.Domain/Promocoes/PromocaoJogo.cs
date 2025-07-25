using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Domain.Promocoes;

public class PromocaoJogo
{
    public int PromocaoId { get; private set; }
    public int JogoId { get; private set; }

    public Promocao Promocao { get; private set; }
    public Jogo Jogo { get; set; }

    public PromocaoJogo() { } 
    
    public PromocaoJogo(int jogoId, Promocao promocao)
    {
        JogoId = jogoId;
        Promocao = promocao;
    }

}