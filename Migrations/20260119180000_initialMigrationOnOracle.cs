using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SsiApi.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrationOnOracle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "andamento",
                table: "ssi",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "andamento",
                table: "ssi",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
