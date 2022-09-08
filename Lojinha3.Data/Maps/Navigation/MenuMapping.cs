using Lojinha3.Domain.Model.Navigation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha3.Data.Maps.Navigation
{
    public class MenuMapping : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.Property(x => x.Id)
                   .UseMySqlIdentityColumn();
            builder.HasKey(x => x.Id)
                   .HasName("PK_IdMenu");
            builder.Property(x => x.Nome)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.Caminho)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.Icone)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.CreatedAt)
                    .ValueGeneratedOnAdd();

        }
    }
}
