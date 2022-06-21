using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMto.Migrations
{
    public partial class ListCameraAgencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Server_Agencias_AgenciaId",
                schema: "dbo",
                table: "Server");

            migrationBuilder.DropIndex(
                name: "IX_Server_AgenciaId",
                schema: "dbo",
                table: "Server");

            migrationBuilder.DropColumn(
                name: "AgenciaId",
                schema: "dbo",
                table: "Server");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgenciaId",
                schema: "dbo",
                table: "Server",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Server_AgenciaId",
                schema: "dbo",
                table: "Server",
                column: "AgenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Server_Agencias_AgenciaId",
                schema: "dbo",
                table: "Server",
                column: "AgenciaId",
                principalTable: "Agencias",
                principalColumn: "Id");
        }
    }
}
