using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMto.Migrations
{
    public partial class Nota_Camera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nota",
                schema: "dbo",
                table: "Camera",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nota",
                schema: "dbo",
                table: "Camera");
        }
    }
}
