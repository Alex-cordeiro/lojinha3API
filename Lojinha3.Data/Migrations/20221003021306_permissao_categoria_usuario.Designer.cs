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
    [Migration("20221003021306_permissao_categoria_usuario")]
    partial class permissao_categoria_usuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("Lojinha3.Domain.Model.Access.CategoriaAcesso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Icone")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_CategoriaMenuAcesso");

                    b.ToTable("categoriaacesso");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Access.Relations.CategoriaMenuUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaAcessoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaAcessoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CategoriaMenuUsuarios");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Access.Relations.PermissaoMenuUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_PermissaoUsuario");

                    b.HasIndex("MenuId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("PermissaoUsuario");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Access.Usuario", b =>
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
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_Usuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Games.Desenvolvedora", b =>
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

            modelBuilder.Entity("Lojinha3.Domain.Model.Games.Jogo", b =>
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

            modelBuilder.Entity("Lojinha3.Domain.Model.Games.Plataforma", b =>
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

            modelBuilder.Entity("Lojinha3.Domain.Model.Inventory.Estoque", b =>
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

            modelBuilder.Entity("Lojinha3.Domain.Model.Navigation.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caminho")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("CategoriaAcessoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Icone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_IdMenu");

                    b.HasIndex("CategoriaAcessoId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Relations.JogoDesenvolvedora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DesenvolvedoraId")
                        .HasColumnType("int");

                    b.Property<int>("JogoId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_JogoDesenvolvedora");

                    b.HasIndex("DesenvolvedoraId");

                    b.HasIndex("JogoId");

                    b.ToTable("JogoDesenvolvedora");
                });

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

            modelBuilder.Entity("Lojinha3.Domain.Model.Access.Relations.CategoriaMenuUsuario", b =>
                {
                    b.HasOne("Lojinha3.Domain.Model.Access.CategoriaAcesso", "CategoriaAcesso")
                        .WithMany("CategoriaMenuUsuario")
                        .HasForeignKey("CategoriaAcessoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lojinha3.Domain.Model.Access.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaAcesso");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Access.Relations.PermissaoMenuUsuario", b =>
                {
                    b.HasOne("Lojinha3.Domain.Model.Navigation.Menu", "Menu")
                        .WithMany("PermissaoMenuUsuarios")
                        .HasForeignKey("MenuId")
                        .HasConstraintName("FK_PermissaoUsuarios_Menu")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Lojinha3.Domain.Model.Access.Usuario", "Usuario")
                        .WithMany("PermissaoMenuUsuarios")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_PermissaoUsuarios_PermissaoMenuUsuarios")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Games.Jogo", b =>
                {
                    b.HasOne("Lojinha3.Domain.Model.Games.Desenvolvedora", "Desenvolvedora")
                        .WithOne("Jogo")
                        .HasForeignKey("Lojinha3.Domain.Model.Games.Jogo", "DesenvolvedoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desenvolvedora");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Inventory.Estoque", b =>
                {
                    b.HasOne("Lojinha3.Domain.Model.Relations.JogoPlataforma", "JogoPlataforma")
                        .WithMany("Estoque")
                        .HasForeignKey("JogoPlataformaId")
                        .HasConstraintName("FK_Estoque_JogosPlataformas")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("JogoPlataforma");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Navigation.Menu", b =>
                {
                    b.HasOne("Lojinha3.Domain.Model.Access.CategoriaAcesso", "CategoriaAcesso")
                        .WithMany("Menu")
                        .HasForeignKey("CategoriaAcessoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lojinha3.Domain.Model.Access.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId");

                    b.Navigation("CategoriaAcesso");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Relations.JogoDesenvolvedora", b =>
                {
                    b.HasOne("Lojinha3.Domain.Model.Games.Desenvolvedora", "Desenvolvedora")
                        .WithMany("JogoDesenvolvedoras")
                        .HasForeignKey("DesenvolvedoraId")
                        .HasConstraintName("FK_Desenvolvedora")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Lojinha3.Domain.Model.Games.Jogo", "Jogo")
                        .WithMany("JogoDesenvolvedoras")
                        .HasForeignKey("JogoId")
                        .HasConstraintName("FK_Jogo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Desenvolvedora");

                    b.Navigation("Jogo");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Relations.JogoPlataforma", b =>
                {
                    b.HasOne("Lojinha3.Domain.Model.Games.Jogo", "Jogo")
                        .WithMany("JogosPlataformas")
                        .HasForeignKey("JogoId")
                        .HasConstraintName("FK_Jogo_JogoPlataformas")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Lojinha3.Domain.Model.Games.Plataforma", "Plataforma")
                        .WithMany("JogosPlataformas")
                        .HasForeignKey("PlataformaId")
                        .HasConstraintName("FK_Jogo_Plataformas_Jogo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Jogo");

                    b.Navigation("Plataforma");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Access.CategoriaAcesso", b =>
                {
                    b.Navigation("CategoriaMenuUsuario");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Access.Usuario", b =>
                {
                    b.Navigation("PermissaoMenuUsuarios");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Games.Desenvolvedora", b =>
                {
                    b.Navigation("Jogo");

                    b.Navigation("JogoDesenvolvedoras");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Games.Jogo", b =>
                {
                    b.Navigation("JogoDesenvolvedoras");

                    b.Navigation("JogosPlataformas");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Games.Plataforma", b =>
                {
                    b.Navigation("JogosPlataformas");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Navigation.Menu", b =>
                {
                    b.Navigation("PermissaoMenuUsuarios");
                });

            modelBuilder.Entity("Lojinha3.Domain.Model.Relations.JogoPlataforma", b =>
                {
                    b.Navigation("Estoque");
                });
#pragma warning restore 612, 618
        }
    }
}
