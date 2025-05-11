using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriEnergyConnectPlatform.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(max)", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    Names = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Surname = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    StreetAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    City = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Province = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    FarmerId = table.Column<string>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_DbUser_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "DbUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbUser_Email",
                table: "DbUser",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_FarmerId",
                table: "Product",
                column: "FarmerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "DbUser");
        }
    }
}
