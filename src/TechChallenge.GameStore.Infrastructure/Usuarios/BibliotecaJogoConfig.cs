using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Infrastructure.Usuarios
{
    public class BibliotecaJogoConfig : IEntityTypeConfiguration<BibliotecaJogo>
    {
        public void Configure(EntityTypeBuilder<BibliotecaJogo> builder)
        {
            builder.ToTable("BibliotecaJogos");

            builder.HasKey(b => new { b.UsuarioId, b.JogoId });

            builder.HasOne(b => b.Usuario)
                   .WithMany(u => u.Biblioteca)
                   .HasForeignKey(b => b.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Jogo)
                   .WithMany()
                   .HasForeignKey(b => b.JogoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
