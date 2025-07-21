using System;
using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Usuarios;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Usuarios.Fixtures;

public class UsuarioRepositoryFixture : IDisposable
{
    public GameStoreContext Context { get; private set; }
    public UsuarioRepository Repository { get; private set; }

    public UsuarioRepositoryFixture()
    {
        var options = new DbContextOptionsBuilder<GameStoreContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
            .Options;

        Context = new GameStoreContext(options);
        Repository = new UsuarioRepository(Context);
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}