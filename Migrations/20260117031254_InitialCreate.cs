using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SsiApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "servico",
                columns: table => new
                {
                    servico_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mostrar = table.Column<string>(type: "char(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nome_servico = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    area_servico = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servico", x => x.servico_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    chapa = table.Column<string>(type: "char(6)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ramal = table.Column<string>(type: "char(4)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipo_usuario = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mostrar = table.Column<string>(type: "char(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    area_tecnico = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.chapa);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ssi",
                columns: table => new
                {
                    ssi_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    chapa_solicitante = table.Column<string>(type: "char(6)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nome_solicitante = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_registro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    servico_id = table.Column<int>(type: "int", nullable: false),
                    andamento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ssi", x => x.ssi_id);
                    table.ForeignKey(
                        name: "FK_ssi_servico_servico_id",
                        column: x => x.servico_id,
                        principalTable: "servico",
                        principalColumn: "servico_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ssi_usuario_chapa_solicitante",
                        column: x => x.chapa_solicitante,
                        principalTable: "usuario",
                        principalColumn: "chapa",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ssi_chapa_solicitante",
                table: "ssi",
                column: "chapa_solicitante");

            migrationBuilder.CreateIndex(
                name: "IX_ssi_servico_id",
                table: "ssi",
                column: "servico_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ssi");

            migrationBuilder.DropTable(
                name: "servico");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
