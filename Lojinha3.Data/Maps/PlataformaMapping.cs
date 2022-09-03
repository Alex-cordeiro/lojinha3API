using Lojinha3.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha3.Data.Maps
{
    public class PlataformaMapping : IEntityTypeConfiguration<Plataforma>
    {
        public void Configure(EntityTypeBuilder<Plataforma> builder)
        {
            builder.ToTable("Plataforma");
            builder.Property(x => x.Id)
                   .UseMySqlIdentityColumn();
            builder.HasKey(x => x.Id)
                   .HasName("PK_Plataforma");
            builder.Property(x => x.Nome)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.Fabricante)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.CreatedAt)
                   .ValueGeneratedOnAdd();
        }
    }
}
