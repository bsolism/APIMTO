using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMto.Migrations
{
    public partial class DelcameraLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_DataSheets_DataSheetId",
                schema: "dbo",
                table: "Cameras");

            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_Logs_LogId",
                schema: "dbo",
                table: "Cameras");

            migrationBuilder.DropIndex(
                name: "IX_Cameras_LogId",
                schema: "dbo",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "LogId",
                schema: "dbo",
                table: "Cameras");

            migrationBuilder.AlterColumn<int>(
                name: "DataSheetId",
                schema: "dbo",
                table: "Cameras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CameraLog",
                schema: "dbo",
                columns: table => new
                {
                    CamerasId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraLog", x => new { x.CamerasId, x.LogId });
                    table.ForeignKey(
                        name: "FK_CameraLog_Cameras_CamerasId",
                        column: x => x.CamerasId,
                        principalSchema: "dbo",
                        principalTable: "Cameras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CameraLog_Logs_LogId",
                        column: x => x.LogId,
                        principalSchema: "dbo",
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogServer",
                schema: "dbo",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false),
                    ServersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogServer", x => new { x.LogId, x.ServersId });
                    table.ForeignKey(
                        name: "FK_LogServer_Logs_LogId",
                        column: x => x.LogId,
                        principalSchema: "dbo",
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogServer_Servers_ServersId",
                        column: x => x.ServersId,
                        principalSchema: "dbo",
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CameraLog_LogId",
                schema: "dbo",
                table: "CameraLog",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_LogServer_ServersId",
                schema: "dbo",
                table: "LogServer",
                column: "ServersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_DataSheets_DataSheetId",
                schema: "dbo",
                table: "Cameras",
                column: "DataSheetId",
                principalTable: "DataSheets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_DataSheets_DataSheetId",
                schema: "dbo",
                table: "Cameras");

            migrationBuilder.DropTable(
                name: "CameraLog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LogServer",
                schema: "dbo");

            migrationBuilder.AlterColumn<int>(
                name: "DataSheetId",
                schema: "dbo",
                table: "Cameras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogId",
                schema: "dbo",
                table: "Cameras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_LogId",
                schema: "dbo",
                table: "Cameras",
                column: "LogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_DataSheets_DataSheetId",
                schema: "dbo",
                table: "Cameras",
                column: "DataSheetId",
                principalTable: "DataSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_Logs_LogId",
                schema: "dbo",
                table: "Cameras",
                column: "LogId",
                principalSchema: "dbo",
                principalTable: "Logs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
