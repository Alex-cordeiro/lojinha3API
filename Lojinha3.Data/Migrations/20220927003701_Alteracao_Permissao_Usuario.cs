using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lojinha3.Data.Migrations
{
    public partial class Alteracao_Permissao_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_PermissaoUsuario_PermissaoMenuUsuarioId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Permissao",
                table: "PermissaoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Permissao",
                table: "PermissaoUsuario");

            migrationBuilder.DropTable(
                name: "PermissaoCategoriaMenuUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdPermissaoUsuario",
                table: "PermissaoUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Menu_PermissaoMenuUsuarioId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "PermissaoMenuUsuarioId",
                table: "Menu");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaAcessoId",
                table: "PermissaoUsuario",
                type: "int",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissaoUsuario",
                table: "PermissaoUsuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoUsuario_CategoriaAcessoId",
                table: "PermissaoUsuario",
                column: "CategoriaAcessoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoUsuarios_CategoriaAcesso",
                table: "PermissaoUsuario",
                column: "CategoriaAcessoId",
                principalTable: "categoriaacesso",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoUsuarios_Menu",
                table: "PermissaoUsuario",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoUsuarios_Usuario",
                table: "PermissaoUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoUsuarios_CategoriaAcesso",
                table: "PermissaoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoUsuarios_Menu",
                table: "PermissaoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoUsuarios_Usuario",
                table: "PermissaoUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissaoUsuario",
                table: "PermissaoUsuario");

            migrationBuilder.DropIndex(
                name: "IX_PermissaoUsuario_CategoriaAcessoId",
                table: "PermissaoUsuario");

            migrationBuilder.DropColumn(
                name: "CategoriaAcessoId",
                table: "PermissaoUsuario");

            migrationBuilder.AddColumn<int>(
                name: "PermissaoMenuUsuarioId",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdPermissaoUsuario",
                table: "PermissaoUsuario",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PermissaoCategoriaMenuUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoriaMenuAcessoId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoCategoriaMenuAcesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriaMenuAcesso_PermissaoCategoria",
                        column: x => x.CategoriaMenuAcessoId,
                        principalTable: "categoriaacesso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_PermissaoCategoria",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_PermissaoMenuUsuarioId",
                table: "Menu",
                column: "PermissaoMenuUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoCategoriaMenuUsuario_CategoriaMenuAcessoId",
                table: "PermissaoCategoriaMenuUsuario",
                column: "CategoriaMenuAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoCategoriaMenuUsuario_UsuarioId",
                table: "PermissaoCategoriaMenuUsuario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_PermissaoUsuario_PermissaoMenuUsuarioId",
                table: "Menu",
                column: "PermissaoMenuUsuarioId",
                principalTable: "PermissaoUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Permissao",
                table: "PermissaoUsuario",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Permissao",
                table: "PermissaoUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
