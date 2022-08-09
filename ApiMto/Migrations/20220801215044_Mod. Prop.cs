using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMto.Migrations
{
    public partial class ModProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isGoodCondition",
                schema: "dbo",
                table: "Server",
                newName: "Retired");

            migrationBuilder.RenameColumn(
                name: "IsGoodCondition",
                schema: "dbo",
                table: "Camera",
                newName: "Retired");

            migrationBuilder.AddColumn<bool>(
                name: "Online",
                schema: "dbo",
                table: "Server",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Online",
                schema: "dbo",
                table: "Camera",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Online",
                schema: "dbo",
                table: "Server");

            migrationBuilder.DropColumn(
                name: "Online",
                schema: "dbo",
                table: "Camera");

            migrationBuilder.RenameColumn(
                name: "Retired",
                schema: "dbo",
                table: "Server",
                newName: "isGoodCondition");

            migrationBuilder.RenameColumn(
                name: "Retired",
                schema: "dbo",
                table: "Camera",
                newName: "IsGoodCondition");
        }
    }
}
