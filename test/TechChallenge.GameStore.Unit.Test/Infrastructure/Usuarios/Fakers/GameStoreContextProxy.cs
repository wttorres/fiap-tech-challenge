using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Infrastructure._Shared;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Usuarios.Fakers;

public class GameStoreContextProxy : GameStoreContext
{
    public GameStoreContextProxy(DbContextOptions<GameStoreContext> options)
        : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new Exception("Simulação de falha no banco");
    }
}