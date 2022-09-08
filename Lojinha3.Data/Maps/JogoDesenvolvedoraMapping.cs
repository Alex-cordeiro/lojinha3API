using Lojinha3.Domain.Model;
using Lojinha3.Domain.Model.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha3.Data.Maps
{
    public class JogoDesenvolvedoraMapping : IEntityTypeConfiguration<JogoDesenvolvedora>
    {
        public void Configure(EntityTypeBuilder<JogoDesenvolvedora> builder)
        {
            builder.ToTable("JogoDesenvolvedora");

            builder.Property(x => x.Id)
                   .UseMySqlIdentityColumn();
            builder.HasKey(x => x.Id)
                   .HasName("PK_JogoDesenvolvedora");

            builder.HasOne(x => x.Desenvolvedora)
                   .WithMany(x => x.JogoDesenvolvedoras)
                   .HasForeignKey(x => x.DesenvolvedoraId)
                   .HasConstraintName("FK_Desenvolvedora")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Jogo)
                   .WithMany(x => x.JogoDesenvolvedoras)
                   .HasForeignKey(x => x.JogoId)
                   .HasConstraintName("FK_Jogo")
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
