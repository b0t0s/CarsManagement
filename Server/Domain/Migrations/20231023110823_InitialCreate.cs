using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarsManagement.Server.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    IsInclusive = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_ParkingSpots_Id",
                        column: x => x.Id,
                        principalTable: "ParkingSpots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingTickets_Cars_Id",
                        column: x => x.Id,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "AccountName", "PasswordHash" },
                values: new object[,]
                {
                    { 1, "Mick Jagger", "hashed_password_here" },
                    { 2, "Jimi Hendrix", "hashed_password_here" },
                    { 3, "Miles Davis", "hashed_password_here" },
                    { 4, "John Coltrane", "hashed_password_here" },
                    { 5, "B.B. King", "hashed_password_here" },
                    { 6, "Muddy Waters", "hashed_password_here" },
                    { 7, "James Hetfield", "hashed_password_here" },
                    { 8, "Ozzy Osbourne", "hashed_password_here" }
                });

            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "Id", "LotLocation", "LotName", "ManagerId" },
                values: new object[,]
                {
                    { 1, "Rock", "Garage California", 1 },
                    { 2, "Rock", "Garage of the Rising Sun", 1 },
                    { 3, "Rock", "Voodoo Car", 2 },
                    { 4, "Rock", "Crosstown Traffic", 2 },
                    { 5, "Metal", "Enter Garage", 7 },
                    { 6, "Metal", "Wherever I May Roam", 7 },
                    { 7, "Metal", "Crazy Car", 8 },
                    { 8, "Metal", "No More Spots", 8 }
                });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "IsInclusive", "IsOccupied", "LotId" },
                values: new object[,]
                {
                    { 1, false, true, 1 },
                    { 2, false, false, 1 },
                    { 3, false, true, 1 },
                    { 4, false, false, 1 },
                    { 5, true, false, 1 },
                    { 6, false, false, 2 },
                    { 7, false, true, 2 },
                    { 8, false, false, 2 },
                    { 9, false, false, 2 },
                    { 10, true, true, 2 },
                    { 11, false, true, 3 },
                    { 12, false, false, 3 },
                    { 13, false, true, 3 },
                    { 14, false, false, 3 },
                    { 15, true, false, 3 },
                    { 16, false, true, 4 },
                    { 17, false, false, 4 },
                    { 18, false, true, 4 },
                    { 19, false, false, 4 },
                    { 20, true, false, 4 },
                    { 21, false, true, 5 },
                    { 22, false, false, 5 },
                    { 23, false, true, 5 },
                    { 24, false, false, 5 },
                    { 25, true, false, 5 },
                    { 26, false, true, 6 },
                    { 27, false, false, 6 },
                    { 28, false, true, 6 },
                    { 29, false, false, 6 },
                    { 30, true, false, 6 },
                    { 31, false, true, 7 },
                    { 32, false, false, 7 },
                    { 33, false, true, 7 },
                    { 34, false, false, 7 },
                    { 35, true, false, 7 },
                    { 36, false, true, 8 },
                    { 37, false, false, 8 },
                    { 38, false, true, 8 },
                    { 39, false, false, 8 },
                    { 40, true, false, 8 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "LicensePlate", "Model" },
                values: new object[,]
                {
                    { 1, "BMW", "#A16541", "Z3" },
                    { 2, "Mazda", "#321E7C", "RX8" },
                    { 3, "Audi", "#A4B268", "A6" },
                    { 4, "Hyundai", "#003EF5", "Elantra" },
                    { 5, "Lincoln", "#1688FB", "MKX" },
                    { 6, "Bugatti", "#8900CA", "Veyron" },
                    { 7, "Tesla", "#4A2441", "Model S" },
                    { 8, "Chevrolet", "#06ADAC", "Camaro" },
                    { 9, "Ford", "#363003", "Mustang" },
                    { 10, "Dodge", "#953172", "Charger" },
                    { 11, "Nissan", "#B2BBCC", "GTR" },
                    { 12, "Honda", "#000460", "Civic" },
                    { 13, "Toyota", "#E8AC62", "Supra" },
                    { 14, "Subaru", "#EC0A9B", "Impreza" },
                    { 15, "Ferrari", "#90CBE5", "488" }
                });

            migrationBuilder.InsertData(
                table: "ParkingTickets",
                columns: new[] { "Id", "AmountPaid", "EntryTime", "ExitTime" },
                values: new object[,]
                {
                    { 1, 15m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6404), new DateTime(2023, 10, 23, 19, 8, 23, 790, DateTimeKind.Local).AddTicks(6460) },
                    { 2, 13m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6473), new DateTime(2023, 10, 23, 17, 8, 23, 790, DateTimeKind.Local).AddTicks(6475) },
                    { 3, 18m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6477), new DateTime(2023, 10, 23, 22, 8, 23, 790, DateTimeKind.Local).AddTicks(6478) },
                    { 4, 1m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6480), new DateTime(2023, 10, 23, 19, 8, 23, 790, DateTimeKind.Local).AddTicks(6482) },
                    { 5, 15m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6484), new DateTime(2023, 10, 23, 19, 8, 23, 790, DateTimeKind.Local).AddTicks(6486) },
                    { 6, 25m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6489), new DateTime(2023, 10, 23, 20, 8, 23, 790, DateTimeKind.Local).AddTicks(6491) },
                    { 7, 30m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6493), new DateTime(2023, 10, 23, 21, 8, 23, 790, DateTimeKind.Local).AddTicks(6509) },
                    { 8, 20m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6511), new DateTime(2023, 10, 23, 18, 8, 23, 790, DateTimeKind.Local).AddTicks(6513) },
                    { 9, 22m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6515), new DateTime(2023, 10, 23, 19, 8, 23, 790, DateTimeKind.Local).AddTicks(6517) },
                    { 10, 28m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6519), new DateTime(2023, 10, 23, 20, 8, 23, 790, DateTimeKind.Local).AddTicks(6521) },
                    { 11, 32m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6523), new DateTime(2023, 10, 23, 21, 8, 23, 790, DateTimeKind.Local).AddTicks(6524) },
                    { 12, 35m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6526), new DateTime(2023, 10, 23, 22, 8, 23, 790, DateTimeKind.Local).AddTicks(6528) },
                    { 13, 40m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6711), new DateTime(2023, 10, 23, 23, 8, 23, 790, DateTimeKind.Local).AddTicks(6712) },
                    { 14, 45m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6714), new DateTime(2023, 10, 24, 0, 8, 23, 790, DateTimeKind.Local).AddTicks(6716) },
                    { 15, 50m, new DateTime(2023, 10, 23, 14, 8, 23, 790, DateTimeKind.Local).AddTicks(6717), new DateTime(2023, 10, 24, 1, 8, 23, 790, DateTimeKind.Local).AddTicks(6719) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_ManagerId",
                table: "ParkingLots",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_Id",
                table: "ParkingSpots",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_LotId",
                table: "ParkingSpots",
                column: "LotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingTickets");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "ParkingLots");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
