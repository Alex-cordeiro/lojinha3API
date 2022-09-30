using Lojinha3.Domain.Model.Access.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha3.Data.Maps.Access
{
    public class PermissaoUsuarioMapping : IEntityTypeConfiguration<PermissaoUsuario>
    {
        public void Configure(EntityTypeBuilder<PermissaoUsuario> builder)
        {
            builder.ToTable("PermissaoUsuario");
            builder.Property(x => x.Id)
                   .UseMySqlIdentityColumn();

            builder.HasKey(x => x.Id)
                   .HasName("PK_PermissaoUsuario");

            builder.Property(x => x.MenuId)
                   .HasColumnName("MenuId")
                   .HasColumnType("int")
                   .HasMaxLength(4);

            builder.Property(x => x.CategoriaAcessoId)
                   .HasColumnName("CategoriaAcessoId")
                   .HasColumnType("int")
                   .HasMaxLength(4);

            builder.Property(x => x.UsuarioId)
                   .HasColumnName("UsuarioId")
                   .HasColumnType("int")
                   .HasMaxLength(4);

            builder.Property(x => x.CreatedAt)
                   .ValueGeneratedOnAdd();

           
            builder.HasOne(x => x.CategoriaAcesso)
                   .WithMany(x => x.PermissaoUsuario)
                   .HasForeignKey(x => x.CategoriaAcessoId)
                   .HasConstraintName("FK_PermissaoUsuarios_CategoriaAcesso")
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
