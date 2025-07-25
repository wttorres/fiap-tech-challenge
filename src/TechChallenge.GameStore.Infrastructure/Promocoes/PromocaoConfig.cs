using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Infrastructure.Promocoes;

public class PromocaoConfiguration : IEntityTypeConfiguration<Promocao>
{
    public void Configure(EntityTypeBuilder<Promocao> builder)
    {
        builder.ToTable("promocao");

        builder.HasKey(p => p.Id);
        
        builder.Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedOnAdd(); 

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Descricao)
            .HasMaxLength(500);

        builder.Property(p => p.DescontoPercentual)
            .IsRequired();

        builder.Property(p => p.DataInicio)
            .IsRequired();

        builder.Property(p => p.DataFim)
            .IsRequired();

        builder
            .HasMany<PromocaoJogo>("_jogos")
            .WithOne(pj => pj.Promocao)
            .HasForeignKey(pj => pj.PromocaoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(p => p.Jogos); 

    }
}