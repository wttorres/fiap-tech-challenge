using System;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Promocoes;
using TechChallenge.GameStore.Unit.Test._Shared;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Promocoes.Fixtures;

public class PromocaoRepositoryFixture : IDisposable
{
    public GameStoreContext Context { get; private set; }
    public PromocaoRepository Repository { get; private set; }

    public PromocaoRepositoryFixture()
    {
        Context    = ContextFactory.Create();
        Repository = new PromocaoRepository(Context);
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}