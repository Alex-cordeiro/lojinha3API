using Lojinha3.Domain.Model.Access.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha3.Data.Maps.Access
{
    public class PermissaoMenuUsuarioMapping : IEntityTypeConfiguration<PermissaoMenuUsuario>
    {
        public void Configure(EntityTypeBuilder<PermissaoMenuUsuario> builder)
        {
            builder.ToTable("PermissaoUsuario");
            builder.Property(x => x.Id)
                   .UseMySqlIdentityColumn();

            builder.HasKey(x => x.Id)
                   .HasName("PK_PermissaoUsuario");

            builder.Property(x => x.CreatedAt)
                   .ValueGeneratedOnAddOrUpdate();
           
            builder.HasOne(x => x.Usuario)
                   .WithMany(x => x.PermissaoMenuUsuarios)
                   .HasForeignKey(x => x.UsuarioId)
                   .HasConstraintName("FK_PermissaoUsuarios_PermissaoMenuUsuarios")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Menu)
                  .WithMany(x => x.PermissaoMenuUsuarios)
                  .HasForeignKey(x => x.MenuId)
                  .HasConstraintName("FK_PermissaoUsuarios_Menu")
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
