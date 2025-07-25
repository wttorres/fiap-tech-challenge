using System;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Jogos;
using TechChallenge.GameStore.Unit.Test._Shared;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Jogos.Fixtures;

public class JogoRepositoryFixture : IDisposable
{
    public GameStoreContext Context { get; private set; }
    public JogoRepository Repository { get; private set; }

    public JogoRepositoryFixture()
    {
        Context = ContextFactory.Create();
        Repository = new JogoRepository(Context);
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}
