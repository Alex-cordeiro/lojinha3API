using Lojinha3.Domain.Model.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha3.Data.Maps.Access
{
    public class CategoriaAcessoMapping : IEntityTypeConfiguration<CategoriaAcesso>
    {
        public void Configure(EntityTypeBuilder<CategoriaAcesso> builder)
        {
            builder.ToTable("categoriaacesso");
            builder.Property(x => x.Id)
                   .UseMySqlIdentityColumn();

            builder.HasKey(x => x.Id)
                   .HasName("PK_CategoriaMenuAcesso");

            builder.Property(x => x.Nome)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Descricao)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Icone)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.Property(x => x.CreatedAt)
                    .ValueGeneratedOnAdd();
        }
    }
}
