using Microsoft.EntityFrameworkCore.Migrations;

namespace Lojinha3.Data.Migrations
{
    public partial class categoria_menus_acessos_icone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icone",
                table: "CategoriaMenuAcesso",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icone",
                table: "CategoriaMenuAcesso");
        }
    }
}
