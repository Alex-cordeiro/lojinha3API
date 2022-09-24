using Lojinha3.Domain.Model.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha3.Data.Maps.Access
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.Property(x => x.Id)
                   .UseMySqlIdentityColumn();

            builder.HasKey(x => x.Id)
                   .HasName("PK_Usuario");
            builder.Property(x => x.Nome)
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired();
            builder.Property(x => x.UserName)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.Senha)
                   .HasColumnType("varchar")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.RefreshToken)
                   .HasColumnType("varchar")
                   .HasMaxLength(255);

            builder.Property(x => x.RefreshTokenExpiryTime)
                   .HasColumnType("datetime");
              

            builder.Property(x => x.CreatedAt)
                   .ValueGeneratedOnAdd();
        }
    }
}
