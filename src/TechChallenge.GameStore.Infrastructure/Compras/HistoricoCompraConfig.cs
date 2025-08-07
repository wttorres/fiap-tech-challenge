using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.GameStore.Domain.Compras;

namespace TechChallenge.GameStore.Infrastructure.Compras
{
    public class HistoricoCompraConfig : IEntityTypeConfiguration<HistoricoCompra>
    {
        public void Configure(EntityTypeBuilder<HistoricoCompra> builder)
        {
            builder.ToTable("HistoricoCompras");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.DataCompra)
                   .IsRequired();

            builder.HasMany(h => h.Itens)
                   .WithOne(i => i.HistoricoCompra)
                   .HasForeignKey(i => i.HistoricoCompraId);
        }
    }
}
