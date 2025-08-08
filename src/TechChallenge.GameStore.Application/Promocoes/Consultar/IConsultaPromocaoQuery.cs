using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechChallenge.GameStore.Application.Promocoes.Consultar;

public interface IConsultaPromocaoQuery
{
    Task<PromocaoResponse> ObterPorIdAsync(int id);
    Task<List<PromocaoResponse>> ObterTodasAsync();
}