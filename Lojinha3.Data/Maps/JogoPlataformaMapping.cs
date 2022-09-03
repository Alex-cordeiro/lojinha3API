using Lojinha3.Domain.Model.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha3.Data.Maps
{
    public class JogoPlataformaMapping : IEntityTypeConfiguration<JogoPlataforma>
    {
        public void Configure(EntityTypeBuilder<JogoPlataforma> builder)
        {
            builder.ToTable("JogoPlataforma");
            builder.Property(x => x.Id)
                   .UseMySqlIdentityColumn();
            builder.HasKey(x => x.Id)
                   .HasName("PK_JogoPlataforma");

            builder.HasOne(x => x.Jogo)
                   .WithMany(x => x.JogosPlataformas)
                   .HasForeignKey(x => x.JogoId)
                   .HasConstraintName("FK_Jogo_JogoPlataformas")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Plataforma)
                   .WithMany(x => x.JogosPlataformas)
                   .HasForeignKey(x => x.PlataformaId)
                   .HasConstraintName("FK_Jogo_Plataformas_Jogo")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Estoque)
                 .WithOne(x => x.JogoPlataforma)
                 .HasForeignKey(x => x.JogoPlataformaId)
                 .HasConstraintName("FK_Estoque_JogosPlataformas")
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
