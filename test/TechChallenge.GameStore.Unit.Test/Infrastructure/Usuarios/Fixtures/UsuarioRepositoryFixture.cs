using System;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Usuarios;
using TechChallenge.GameStore.Unit.Test._Shared;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Usuarios.Fixtures;

public class UsuarioRepositoryFixture : IDisposable
{
    public GameStoreContext Context { get; private set; }
    public UsuarioRepository Repository { get; private set; }

    public UsuarioRepositoryFixture()
    {
        Context    = ContextFactory.Create();
        Repository = new UsuarioRepository(Context);
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}