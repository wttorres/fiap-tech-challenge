using System;
using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Infrastructure._Shared;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameStoreContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?.Equals("Development", StringComparison.OrdinalIgnoreCase) == true)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        
        base.OnConfiguring(optionsBuilder);
    }

}
