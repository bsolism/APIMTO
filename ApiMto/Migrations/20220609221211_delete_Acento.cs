using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMto.Migrations
{
    public partial class delete_Acento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UbicaciónFisica",
                schema: "dbo",
                table: "Camera",
                newName: "UbicacionFisica");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UbicacionFisica",
                schema: "dbo",
                table: "Camera",
                newName: "UbicaciónFisica");
        }
    }
}
