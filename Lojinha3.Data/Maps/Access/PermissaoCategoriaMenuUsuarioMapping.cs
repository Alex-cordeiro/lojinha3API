using Lojinha3.Domain.Model.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha3.Data.Maps.Access
{
    public class PermissaoCategoriaMenuUsuarioMapping : IEntityTypeConfiguration<PermissaoCategoriaMenuUsuario>
    {
        public void Configure(EntityTypeBuilder<PermissaoCategoriaMenuUsuario> builder)
        {
            builder.ToTable("PermissaoCategoriaMenuUsuario");
            builder.Property(x => x.Id)
                   .UseMySqlIdentityColumn();

            builder.HasKey(x => x.Id)
                   .HasName("PK_PermissaoCategoriaMenuAcesso");

            builder.HasOne(x => x.Usuario)
                    .WithMany(x => x.PermissaoCategoriaMenuUsuario)
                    .HasForeignKey(x => x.UsuarioId)
                    .HasConstraintName("FK_Usuario_PermissaoCategoria")
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.CategoriaMenuAcesso)
                    .WithMany(x => x.PermissaoCategoriaMenuUsuarios)
                    .HasForeignKey(x => x.CategoriaMenuAcessoId)
                    .HasConstraintName("FK_CategoriaMenuAcesso_PermissaoCategoria")
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.CreatedAt)
                    .ValueGeneratedOnAdd();
        }
    }
}
