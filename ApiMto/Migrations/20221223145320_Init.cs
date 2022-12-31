using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMto.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSheetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmwareVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlotSata = table.Column<int>(type: "int", nullable: false),
                    CapacityBySlot = table.Column<int>(type: "int", nullable: false),
                    SataAvailable = table.Column<int>(type: "int", nullable: false),
                    CapacityTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EngravedDays = table.Column<int>(type: "int", nullable: false),
                    Online = table.Column<bool>(type: "bit", nullable: false),
                    Retired = table.Column<bool>(type: "bit", nullable: false),
                    PortAnalogo = table.Column<int>(type: "int", nullable: false),
                    PortIpPoe = table.Column<int>(type: "int", nullable: false),
                    ChannelIP = table.Column<int>(type: "int", nullable: false),
                    AgencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateIncident = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateInstallation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateBuy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    DataSheetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servers_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Servers_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Servers_DataSheets_DataSheetId",
                        column: x => x.DataSheetId,
                        principalTable: "DataSheets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SrvAgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvAgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvAgs_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SrvAgs_Servers_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "dbo",
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cameras",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Connection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatchPanel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Switch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortPatchPanel = table.Column<int>(type: "int", nullable: true),
                    PortSwitch = table.Column<int>(type: "int", nullable: true),
                    PortChannel = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmwareVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Online = table.Column<bool>(type: "bit", nullable: false),
                    Retired = table.Column<bool>(type: "bit", nullable: false),
                    DateInstallation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateBuy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateIncident = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    DataSheetId = table.Column<int>(type: "int", nullable: false),
                    LogId = table.Column<int>(type: "int", nullable: false),
                    ServerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AgencyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cameras_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cameras_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cameras_DataSheets_DataSheetId",
                        column: x => x.DataSheetId,
                        principalTable: "DataSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cameras_Logs_LogId",
                        column: x => x.LogId,
                        principalSchema: "dbo",
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cameras_Servers_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "dbo",
                        principalTable: "Servers",
                        principalColumn: "Id");
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_AgencyId",
                schema: "dbo",
                table: "Cameras",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_BrandId",
                schema: "dbo",
                table: "Cameras",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_DataSheetId",
                schema: "dbo",
                table: "Cameras",
                column: "DataSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_LogId",
                schema: "dbo",
                table: "Cameras",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_ServerId",
                schema: "dbo",
                table: "Cameras",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                schema: "dbo",
                table: "Logs",
                column: "UserId");

           

            migrationBuilder.CreateIndex(
                name: "IX_Servers_AgencyId",
                schema: "dbo",
                table: "Servers",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_BrandId",
                schema: "dbo",
                table: "Servers",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_DataSheetId",
                schema: "dbo",
                table: "Servers",
                column: "DataSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvAgs_AgencyId",
                table: "SrvAgs",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvAgs_ServerId",
                table: "SrvAgs",
                column: "ServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cameras",
                schema: "dbo");

           

            migrationBuilder.DropTable(
                name: "SrvAgs");

            migrationBuilder.DropTable(
                name: "Logs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Servers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "DataSheets");
        }
    }
}
