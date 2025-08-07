using System;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Notificacoes;
using TechChallenge.GameStore.Unit.Test._Shared;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Notificacoes.Fixtures;

public class NotificacaoRepositoryFixture : IDisposable
{
    public GameStoreContext Context { get; private set; }
    public NotificacaoRepository Repository { get; private set; }

    public NotificacaoRepositoryFixture()
    {
        Context = ContextFactory.Create();
        Repository = new NotificacaoRepository(Context);
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}