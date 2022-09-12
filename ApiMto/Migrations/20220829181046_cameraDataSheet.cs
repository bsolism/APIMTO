using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMto.Migrations
{
    public partial class cameraDataSheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CameraDataSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSheetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CameraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraDataSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CameraDataSheets_Camera_CameraId",
                        column: x => x.CameraId,
                        principalSchema: "dbo",
                        principalTable: "Camera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CameraDataSheets_CameraId",
                table: "CameraDataSheets",
                column: "CameraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CameraDataSheets");
        }
    }
}
