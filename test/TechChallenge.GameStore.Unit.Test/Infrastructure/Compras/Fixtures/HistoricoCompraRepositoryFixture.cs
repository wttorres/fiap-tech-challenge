using System;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Compras.Imp;
using TechChallenge.GameStore.Unit.Test._Shared;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Compras.Fixtures;

public class HistoricoCompraRepositoryFixture : IDisposable
{
    public GameStoreContext Context { get; private set; }
    public HistoricoCompraRepository Repository { get; private set; }

    public HistoricoCompraRepositoryFixture()
    {
        Context = ContextFactory.Create();
        Repository = new HistoricoCompraRepository(Context);
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}
