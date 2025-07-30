using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.GameStore.Domain.Notificacoes;

namespace TechChallenge.GameStore.Infrastructure.Notificacoes;

public class NotificacaoEnviadaConfig : IEntityTypeConfiguration<NotificacaoEnviada>
{
    public void Configure(EntityTypeBuilder<NotificacaoEnviada> builder)
    {
        builder.ToTable("notificacao_enviada");

        builder.HasKey(ne => ne.Id);

        builder.Property(ne => ne.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.HasOne(ne => ne.Usuario)
            .WithMany()
            .HasForeignKey(ne => ne.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ne => ne.PromocaoJogo)
            .WithMany()
            .HasForeignKey(ne => ne.PromocaoJogoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ne => ne.Notificacao)
            .WithMany(n => n.Enviadas) 
            .HasForeignKey(ne => ne.NotificacaoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}