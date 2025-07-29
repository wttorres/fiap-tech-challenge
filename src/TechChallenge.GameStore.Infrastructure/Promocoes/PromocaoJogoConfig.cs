using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Infrastructure.Promocoes;

public class PromocaoJogoConfiguration : IEntityTypeConfiguration<PromocaoJogo>
{
    public void Configure(EntityTypeBuilder<PromocaoJogo> builder)
    {
        builder.ToTable("promocao_jogo");

        builder.HasKey(pj => new { pj.PromocaoId, pj.JogoId });

        builder
            .HasOne(pj => pj.Promocao)
            .WithMany(p => p.Jogos) 
            .HasForeignKey(pj => pj.PromocaoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(pj => pj.Jogo)
            .WithMany() 
            .HasForeignKey(pj => pj.JogoId);
    }
}
