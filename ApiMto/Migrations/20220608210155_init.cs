using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMto.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Server",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    FirmwareVersion = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Sata = table.Column<int>(type: "int", nullable: false),
                    CapacidadSata = table.Column<int>(type: "int", nullable: false),
                    SataInstalado = table.Column<int>(type: "int", nullable: false),
                    CapacidadSataInstalado = table.Column<int>(type: "int", nullable: false),
                    EngravedDays = table.Column<int>(type: "int", nullable: false),
                    isGoodCondition = table.Column<bool>(type: "bit", nullable: false),
                    PortAnalogo = table.Column<int>(type: "int", nullable: false),
                    PortIpPoe = table.Column<int>(type: "int", nullable: false),
                    CanalesIP = table.Column<int>(type: "int", nullable: false),
                    nota = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    FechaInstalacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    AgenciaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Server", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Server_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Server_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Camera",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    UbicaciónFisica = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    UbicacionConexion = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    PatchPanel = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Switch = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    PortPatchPanel = table.Column<int>(type: "int", nullable: true),
                    PortSwitch = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DeviceDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    FirmwareVersion = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IsGoodCondition = table.Column<bool>(type: "bit", nullable: false),
                    FechaInstalacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ServerId = table.Column<int>(type: "int", nullable: false),
                    AgenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Camera_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Camera_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Camera_Server_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "dbo",
                        principalTable: "Server",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SrvAgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgenciaId = table.Column<int>(type: "int", nullable: false),
                    ServerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvAgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvAgs_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SrvAgs_Server_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "dbo",
                        principalTable: "Server",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camera_AgenciaId",
                schema: "dbo",
                table: "Camera",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Camera_BrandId",
                schema: "dbo",
                table: "Camera",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Camera_ServerId",
                schema: "dbo",
                table: "Camera",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Server_AgenciaId",
                schema: "dbo",
                table: "Server",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Server_BrandId",
                schema: "dbo",
                table: "Server",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvAgs_AgenciaId",
                table: "SrvAgs",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvAgs_ServerId",
                table: "SrvAgs",
                column: "ServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Camera",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SrvAgs");

            migrationBuilder.DropTable(
                name: "Server",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
