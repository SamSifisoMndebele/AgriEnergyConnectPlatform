using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriEnergyConnectPlatform.Migrations
{
    /// <inheritdoc />
    public partial class data_types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FarmerId",
                table: "Products",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AppUsers",
                type: "varchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "AppUsers",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "AppUsers",
                type: "varchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AppUsers",
                type: "varchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "Names",
                table: "AppUsers",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppUsers",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AppUsers",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FarmerId",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AppUsers",
                type: "TEXT",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "AppUsers",
                type: "TEXT",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "AppUsers",
                type: "TEXT",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AppUsers",
                type: "TEXT",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "Names",
                table: "AppUsers",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppUsers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AppUsers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)");
        }
    }
}
