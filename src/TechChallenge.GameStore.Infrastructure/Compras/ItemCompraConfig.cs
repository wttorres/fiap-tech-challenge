using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.GameStore.Domain.Compras;

namespace TechChallenge.GameStore.Infrastructure.Compras
{
    public class ItemCompraConfig : IEntityTypeConfiguration<ItemCompra>
    {
        public void Configure(EntityTypeBuilder<ItemCompra> builder)
        {
            builder.ToTable("ItensCompra");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.PrecoPago)
                   .IsRequired();

            builder.HasOne(i => i.Jogo)
                   .WithMany()
                   .HasForeignKey(i => i.JogoId);
        }
    }
}
