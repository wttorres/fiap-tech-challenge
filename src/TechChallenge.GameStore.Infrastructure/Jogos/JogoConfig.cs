using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Infrastructure.Jogos;

public class JogoConfiguration : IEntityTypeConfiguration<Jogo>
{
    public void Configure(EntityTypeBuilder<Jogo> builder)
    {
        builder.ToTable("jogo");

        builder.HasKey(j => j.Id);

        builder.Ignore(p => p.Nome);
        
        builder.Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedOnAdd(); 
    }
}