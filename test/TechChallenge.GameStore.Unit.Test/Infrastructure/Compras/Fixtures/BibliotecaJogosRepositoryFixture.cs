using System;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Compras;
using TechChallenge.GameStore.Infrastructure.Compras.Imp;
using TechChallenge.GameStore.Unit.Test._Shared;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Compras.Fixtures;

public class BibliotecaJogosRepositoryFixture : IDisposable
{
    public GameStoreContext Context { get; private set; }
    public BibliotecaJogosRepository Repository { get; private set; }

    public BibliotecaJogosRepositoryFixture()
    {
        Context = ContextFactory.Create();
        Repository = new BibliotecaJogosRepository(Context);
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}
