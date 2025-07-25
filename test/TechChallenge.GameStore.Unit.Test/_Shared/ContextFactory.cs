using System;
using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Infrastructure._Shared;

namespace TechChallenge.GameStore.Unit.Test._Shared;

public static class ContextFactory
{
    public static GameStoreContext Create()
    {
        var options = new DbContextOptionsBuilder<GameStoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) 
            .Options;

        return new GameStoreContext(options);
    }
}