using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lojinha3.Data.Migrations
{
    public partial class categoria_menus_acessos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaMenuAcesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaMenuAcesso", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermissaoCategoriaMenuUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CategoriaMenuAcessoId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoCategoriaMenuAcesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriaMenuAcesso_PermissaoCategoria",
                        column: x => x.CategoriaMenuAcessoId,
                        principalTable: "CategoriaMenuAcesso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_PermissaoCategoria",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoCategoriaMenuUsuario_CategoriaMenuAcessoId",
                table: "PermissaoCategoriaMenuUsuario",
                column: "CategoriaMenuAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoCategoriaMenuUsuario_UsuarioId",
                table: "PermissaoCategoriaMenuUsuario",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissaoCategoriaMenuUsuario");

            migrationBuilder.DropTable(
                name: "CategoriaMenuAcesso");
        }
    }
}
