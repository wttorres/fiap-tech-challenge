using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.GameStore.Domain.Notificacoes;

namespace TechChallenge.GameStore.Infrastructure.Notificacoes;

public class NotificacaoConfig: IEntityTypeConfiguration<Notificacao>
{
    public void Configure(EntityTypeBuilder<Notificacao> builder)
    {
        builder.ToTable("notificacao");

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(n => n.Titulo)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(n => n.Mensagem)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(n => n.DataEnvio)
            .IsRequired();
        
        builder
            .HasMany(p => p.Enviadas)
            .WithOne(pj => pj.Notificacao)
            .HasForeignKey(pj => pj.NotificacaoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}