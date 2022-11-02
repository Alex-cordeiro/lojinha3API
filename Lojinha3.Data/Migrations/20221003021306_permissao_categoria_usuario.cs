using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lojinha3.Data.Migrations
{
    public partial class permissao_categoria_usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_categoriaacesso_CategoriaAcessoId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoUsuarios_CategoriaAcesso",
                table: "PermissaoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoUsuarios_Usuario",
                table: "PermissaoUsuario");

            migrationBuilder.DropIndex(
                name: "IX_PermissaoUsuario_CategoriaAcessoId",
                table: "PermissaoUsuario");

            migrationBuilder.DropColumn(
                name: "CategoriaAcessoId",
                table: "PermissaoUsuario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PermissaoUsuario",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaAcessoId",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriaMenuUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoriaAcessoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaMenuUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriaMenuUsuarios_categoriaacesso_CategoriaAcessoId",
                        column: x => x.CategoriaAcessoId,
                        principalTable: "categoriaacesso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaMenuUsuarios_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_usuarioId",
                table: "Menu",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaMenuUsuarios_CategoriaAcessoId",
                table: "CategoriaMenuUsuarios",
                column: "CategoriaAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaMenuUsuarios_UsuarioId",
                table: "CategoriaMenuUsuarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_categoriaacesso_CategoriaAcessoId",
                table: "Menu",
                column: "CategoriaAcessoId",
                principalTable: "categoriaacesso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Usuario_usuarioId",
                table: "Menu",
                column: "usuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoUsuarios_PermissaoMenuUsuarios",
                table: "PermissaoUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_categoriaacesso_CategoriaAcessoId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Usuario_usuarioId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoUsuarios_PermissaoMenuUsuarios",
                table: "PermissaoUsuario");

            migrationBuilder.DropTable(
                name: "CategoriaMenuUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Menu_usuarioId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Menu");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PermissaoUsuario",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaAcessoId",
                table: "PermissaoUsuario",
                type: "int",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaAcessoId",
                table: "Menu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoUsuario_CategoriaAcessoId",
                table: "PermissaoUsuario",
                column: "CategoriaAcessoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_categoriaacesso_CategoriaAcessoId",
                table: "Menu",
                column: "CategoriaAcessoId",
                principalTable: "categoriaacesso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoUsuarios_CategoriaAcesso",
                table: "PermissaoUsuario",
                column: "CategoriaAcessoId",
                principalTable: "categoriaacesso",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoUsuarios_Usuario",
                table: "PermissaoUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
