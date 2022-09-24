using Lojinha3.Domain.Model.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha3.Data.Maps.Games
{
    public class DesenvolvedoraMapping : IEntityTypeConfiguration<Desenvolvedora>
    {
        public void Configure(EntityTypeBuilder<Desenvolvedora> builder)
        {
            builder.ToTable("Desenvolvedora");
            builder.Property(x => x.Id)
                   .UseMySqlIdentityColumn();
            builder.HasKey(x => x.Id)
                   .HasName("PK_Desenvolvedora");
            builder.Property(x => x.Nome)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.Pais)
                   .HasColumnType("varchar")
                   .HasMaxLength(100);
            builder.Property(x => x.CreatedAt)
                   .ValueGeneratedOnAdd();
        }
    }
}
