using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Infrastructure._Shared;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Jogo> Jogos => Set<Jogo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder. ApplyConfigurationsFromAssembly(typeof(GameStoreContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
}
