﻿// <auto-generated />
using System;
using Lojinha3API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lojinha3.Data.Migrations
{
    [DbContext(typeof(LojinhaContext))]
    [Migration("20220828105554_Primeiros_Mappings")]
    partial class Primeiros_Mappings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("Lojinha3.Domain.Model.Relations.JogoPlataforma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("JogoId")
                        .HasColumnType("int");

                    b.Property<int>("PlataformaId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_JogoPlataforma");

                    b.HasIndex("JogoId");

                    b.HasIndex("PlataformaId");

                    b.ToTable("JogoPlataforma");
                });

            modelBuilder.Entity("Lojinha3API.Models.Desenvolvedora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Pais")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_Desenvolvedora");

                    b.ToTable("Desenvolvedora");
                });

            modelBuilder.Entity("Lojinha3API.Models.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("JogoPlataformaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("QteJogoPorPlataforma")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Estoque");

                    b.HasIndex("JogoPlataformaId");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("Lojinha3API.Models.Jogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnoLancamento")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DesenvolvedoraId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id")
                        .HasName("PK_IdJogo");

                    b.HasIndex("DesenvolvedoraId")
                        .IsUnique();

                    b.ToTable("Jogo");
                });

            modelBuilder.Entity("Lojinha3API.Models.JogoDesenvolvedora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DesenvolvedoraId")
                        .HasColumnType("int");

                    b.Property<int>("JogoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DesenvolvedoraId");

                    b.HasIndex("JogoId");

                    b.ToTable("JogoDesenvolvedoras");
                });

            modelBuilder.Entity("Lojinha3API.Models.Plataforma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_Plataforma");

                    b.ToTable("Plataforma");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Relations.JogoPlataforma", b =>
                {
                    b.HasOne("Lojinha3API.Models.Jogo", "Jogo")
                        .WithMany("JogosPlataformas")
                        .HasForeignKey("JogoId")
                        .HasConstraintName("FK_Jogo_JogoPlataformas")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Lojinha3API.Models.Plataforma", "Plataforma")
                        .WithMany("JogosPlataformas")
                        .HasForeignKey("PlataformaId")
                        .HasConstraintName("FK_Jogo_Plataformas_Jogo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Jogo");

                    b.Navigation("Plataforma");
                });

            modelBuilder.Entity("Lojinha3API.Models.Estoque", b =>
                {
                    b.HasOne("Lojinha3.Domain.Model.Relations.JogoPlataforma", "JogoPlataforma")
                        .WithMany("Estoque")
                        .HasForeignKey("JogoPlataformaId")
                        .HasConstraintName("FK_Estoque_JogosPlataformas")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("JogoPlataforma");
                });

            modelBuilder.Entity("Lojinha3API.Models.Jogo", b =>
                {
                    b.HasOne("Lojinha3API.Models.Desenvolvedora", "Desenvolvedora")
                        .WithOne("Jogo")
                        .HasForeignKey("Lojinha3API.Models.Jogo", "DesenvolvedoraId")
                        .HasConstraintName("FK_Desenvolvedora_Jogos")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Desenvolvedora");
                });

            modelBuilder.Entity("Lojinha3API.Models.JogoDesenvolvedora", b =>
                {
                    b.HasOne("Lojinha3API.Models.Desenvolvedora", "Desenvolvedora")
                        .WithMany()
                        .HasForeignKey("DesenvolvedoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lojinha3API.Models.Jogo", "Jogo")
                        .WithMany()
                        .HasForeignKey("JogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desenvolvedora");

                    b.Navigation("Jogo");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Relations.JogoPlataforma", b =>
                {
                    b.Navigation("Estoque");
                });

            modelBuilder.Entity("Lojinha3API.Models.Desenvolvedora", b =>
                {
                    b.Navigation("Jogo");
                });

            modelBuilder.Entity("Lojinha3API.Models.Jogo", b =>
                {
                    b.Navigation("JogosPlataformas");
                });

            modelBuilder.Entity("Lojinha3API.Models.Plataforma", b =>
                {
                    b.Navigation("JogosPlataformas");
                });
#pragma warning restore 612, 618
        }
    }
}
