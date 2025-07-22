using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Infrastructure.Jogos
{
    public class JogoConfig : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.ToTable("jogo");

            builder.HasKey(j => j.Id);

            builder.Property(j => j.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(j => j.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(j => j.Nome);

            builder.Property(j => j.Preco)
                .IsRequired();
        }
    }
}
