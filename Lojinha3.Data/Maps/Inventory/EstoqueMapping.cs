using Lojinha3.Domain.Model.Inventory;
using Lojinha3.Domain.Model.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha3.Data.Maps.Inventory
{
    public class EstoqueMapping : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoque");
            builder.Property(x => x.Id)
                   .UseMySqlIdentityColumn();
            builder.HasKey(x => x.Id)
                   .HasName("PK_Estoque");
            builder.Property(x => x.QteJogoPorPlataforma)
                   .HasColumnType("int")
                   .IsRequired();

        }
    }
}
