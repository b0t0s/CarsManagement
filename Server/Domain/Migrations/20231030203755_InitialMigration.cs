using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarsManagement.Server.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingLots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    LotName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LotLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingLots_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotId = table.Column<int>(type: "int", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    ParkedCar_Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParkedCar_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParkedCar_LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ticket_EntryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ticket_ExitTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ticket_AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSpots_ParkingLots_LotId",
                        column: x => x.LotId,
                        principalTable: "ParkingLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "AccountName", "PasswordHash" },
                values: new object[,]
                {
                    { 1, "Mick Jagger", "$2a$11$gZt2uSBLfWIDlfp.lGu8Y.9j5EpzTa9ZuG.IwMFRBakHQt0Jxym7." },
                    { 2, "Jimi Hendrix", "$2a$11$gZt2uSBLfWIDlfp.lGu8Y.9j5EpzTa9ZuG.IwMFRBakHQt0Jxym7." }
                });

            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "Id", "LotLocation", "LotName", "ManagerId" },
                values: new object[,]
                {
                    { 1, "Rock", "Garage California", 1 },
                    { 2, "Rock", "Garage of the Rising Sun", 2 }
                });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "IsOccupied", "LotId" },
                values: new object[,]
                {
                    { 1, false, 1 },
                    { 2, false, 1 },
                    { 3, false, 1 },
                    { 4, false, 1 },
                    { 5, false, 1 },
                    { 6, false, 1 },
                    { 7, false, 1 },
                    { 8, false, 1 },
                    { 9, false, 1 },
                    { 10, false, 1 },
                    { 11, false, 1 },
                    { 12, false, 1 },
                    { 13, false, 2 },
                    { 14, false, 2 },
                    { 15, false, 2 },
                    { 16, false, 2 },
                    { 17, false, 2 },
                    { 18, false, 2 },
                    { 19, false, 2 },
                    { 20, false, 2 },
                    { 21, false, 2 },
                    { 22, false, 2 },
                    { 23, false, 2 },
                    { 24, false, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_ManagerId",
                table: "ParkingLots",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_LotId",
                table: "ParkingSpots",
                column: "LotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "ParkingLots");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
