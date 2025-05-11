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
            migrationBuilder.AddColumn<int>(
                name: "FarmerId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Farmer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Names = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_FarmerId",
                table: "Product",
                column: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Farmer_FarmerId",
                table: "Product",
                column: "FarmerId",
                principalTable: "Farmer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Farmer_FarmerId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Farmer");

            migrationBuilder.DropIndex(
                name: "IX_Product_FarmerId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "Product");
        }
    }
}
