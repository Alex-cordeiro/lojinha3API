using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lojinha3.Data.Migrations
{
    public partial class Sistema_Acesso_Relacao_Desenvolvedora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desenvolvedora_Jogos",
                table: "Jogo");

            migrationBuilder.DropTable(
                name: "JogoDesenvolvedoras");

            migrationBuilder.CreateTable(
                name: "JogoDesenvolvedora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JogoId = table.Column<int>(type: "int", nullable: false),
                    DesenvolvedoraId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogoDesenvolvedora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desenvolvedora",
                        column: x => x.DesenvolvedoraId,
                        principalTable: "Desenvolvedora",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jogo",
                        column: x => x.JogoId,
                        principalTable: "Jogo",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Caminho = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icone = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdMenu", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermissaoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdPermissaoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Permissao",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_Permissao",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_JogoDesenvolvedora_DesenvolvedoraId",
                table: "JogoDesenvolvedora",
                column: "DesenvolvedoraId");

            migrationBuilder.CreateIndex(
                name: "IX_JogoDesenvolvedora_JogoId",
                table: "JogoDesenvolvedora",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoUsuario_MenuId",
                table: "PermissaoUsuario",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoUsuario_UsuarioId",
                table: "PermissaoUsuario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogo_Desenvolvedora_DesenvolvedoraId",
                table: "Jogo",
                column: "DesenvolvedoraId",
                principalTable: "Desenvolvedora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogo_Desenvolvedora_DesenvolvedoraId",
                table: "Jogo");

            migrationBuilder.DropTable(
                name: "JogoDesenvolvedora");

            migrationBuilder.DropTable(
                name: "PermissaoUsuario");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.CreateTable(
                name: "JogoDesenvolvedoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DesenvolvedoraId = table.Column<int>(type: "int", nullable: false),
                    JogoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogoDesenvolvedoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JogoDesenvolvedoras_Desenvolvedora_DesenvolvedoraId",
                        column: x => x.DesenvolvedoraId,
                        principalTable: "Desenvolvedora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogoDesenvolvedoras_Jogo_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Jogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_JogoDesenvolvedoras_DesenvolvedoraId",
                table: "JogoDesenvolvedoras",
                column: "DesenvolvedoraId");

            migrationBuilder.CreateIndex(
                name: "IX_JogoDesenvolvedoras_JogoId",
                table: "JogoDesenvolvedoras",
                column: "JogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desenvolvedora_Jogos",
                table: "Jogo",
                column: "DesenvolvedoraId",
                principalTable: "Desenvolvedora",
                principalColumn: "Id");
        }
    }
}
