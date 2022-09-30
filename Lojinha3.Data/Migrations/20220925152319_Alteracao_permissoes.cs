using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lojinha3.Data.Migrations
{
    public partial class Alteracao_permissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaMenuAcesso_PermissaoCategoria",
                table: "PermissaoCategoriaMenuUsuario");

            migrationBuilder.DropTable(
                name: "CategoriaMenuAcesso");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaAcessoId",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PermissaoMenuUsuarioId",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categoriaacesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaMenuAcesso", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_CategoriaAcessoId",
                table: "Menu",
                column: "CategoriaAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_PermissaoMenuUsuarioId",
                table: "Menu",
                column: "PermissaoMenuUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_categoriaacesso_CategoriaAcessoId",
                table: "Menu",
                column: "CategoriaAcessoId",
                principalTable: "categoriaacesso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_PermissaoUsuario_PermissaoMenuUsuarioId",
                table: "Menu",
                column: "PermissaoMenuUsuarioId",
                principalTable: "PermissaoUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaMenuAcesso_PermissaoCategoria",
                table: "PermissaoCategoriaMenuUsuario",
                column: "CategoriaMenuAcessoId",
                principalTable: "categoriaacesso",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_categoriaacesso_CategoriaAcessoId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_PermissaoUsuario_PermissaoMenuUsuarioId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaMenuAcesso_PermissaoCategoria",
                table: "PermissaoCategoriaMenuUsuario");

            migrationBuilder.DropTable(
                name: "categoriaacesso");

            migrationBuilder.DropIndex(
                name: "IX_Menu_CategoriaAcessoId",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_PermissaoMenuUsuarioId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "CategoriaAcessoId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "PermissaoMenuUsuarioId",
                table: "Menu");

            migrationBuilder.CreateTable(
                name: "CategoriaMenuAcesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaMenuAcesso", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaMenuAcesso_PermissaoCategoria",
                table: "PermissaoCategoriaMenuUsuario",
                column: "CategoriaMenuAcessoId",
                principalTable: "CategoriaMenuAcesso",
                principalColumn: "Id");
        }
    }
}
