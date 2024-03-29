﻿using Lojinha3.Domain.Model.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Lojinha3.Data.Maps.Games
{
    public class JogoMapping : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.ToTable("Jogo");
            builder.Property(x => x.Id)
                   .UseMySqlIdentityColumn();
            builder.HasKey(x => x.Id)
                   .HasName("PK_IdJogo");
            builder.Property(x => x.Titulo)
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired();
            builder.Property(x => x.AnoLancamento)
                   .HasMaxLength(4)
                   .IsRequired();
            builder.Property(x => x.CreatedAt)
                    .ValueGeneratedOnAdd();

        }
    }
}
