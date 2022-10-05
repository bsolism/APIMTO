using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMto.Migrations
{
    public partial class RefactLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Cameras_CameraId",
                schema: "dbo",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_CameraId",
                schema: "dbo",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "CameraId",
                schema: "dbo",
                table: "Logs");

            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                schema: "dbo",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceId",
                schema: "dbo",
                table: "Logs");

            migrationBuilder.AddColumn<string>(
                name: "CameraId",
                schema: "dbo",
                table: "Logs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_CameraId",
                schema: "dbo",
                table: "Logs",
                column: "CameraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Cameras_CameraId",
                schema: "dbo",
                table: "Logs",
                column: "CameraId",
                principalSchema: "dbo",
                principalTable: "Cameras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
