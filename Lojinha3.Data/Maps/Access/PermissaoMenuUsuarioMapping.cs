using Lojinha3.Domain.Model.Access;
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
                   .HasName("PK_IdPermissaoUsuario");
           
            builder.Property(x => x.CreatedAt)
                    .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Usuario)
                   .WithMany(x => x.PermissaoUsuarios)
                   .HasForeignKey(x => x.UsuarioId)
                   .HasConstraintName("FK_Usuario_Permissao")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Menu)
                  .WithMany(x => x.PermissaoUsuarios)
                  .HasForeignKey(x => x.MenuId)
                  .HasConstraintName("FK_Menu_Permissao")
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
