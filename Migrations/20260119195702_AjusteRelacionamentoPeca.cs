using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SsiApi.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentoPeca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "historico",
                columns: table => new
                {
                    historico_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_atualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    descricao_atualizacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ssi_id = table.Column<int>(type: "int", nullable: false),
                    usuario_chapa = table.Column<string>(type: "char(6)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historico", x => x.historico_id);
                    table.ForeignKey(
                        name: "FK_historico_ssi_ssi_id",
                        column: x => x.ssi_id,
                        principalTable: "ssi",
                        principalColumn: "ssi_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_historico_usuario_usuario_chapa",
                        column: x => x.usuario_chapa,
                        principalTable: "usuario",
                        principalColumn: "chapa",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "peca",
                columns: table => new
                {
                    peca_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_peca = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ssi_id = table.Column<int>(type: "int", nullable: false),
                    fk_usuario_chapa = table.Column<string>(type: "char(6)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peca", x => x.peca_id);
                    table.ForeignKey(
                        name: "FK_peca_ssi_ssi_id",
                        column: x => x.ssi_id,
                        principalTable: "ssi",
                        principalColumn: "ssi_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_peca_usuario_fk_usuario_chapa",
                        column: x => x.fk_usuario_chapa,
                        principalTable: "usuario",
                        principalColumn: "chapa",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_historico_ssi_id",
                table: "historico",
                column: "ssi_id");

            migrationBuilder.CreateIndex(
                name: "IX_historico_usuario_chapa",
                table: "historico",
                column: "usuario_chapa");

            migrationBuilder.CreateIndex(
                name: "IX_peca_fk_usuario_chapa",
                table: "peca",
                column: "fk_usuario_chapa");

            migrationBuilder.CreateIndex(
                name: "IX_peca_ssi_id",
                table: "peca",
                column: "ssi_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historico");

            migrationBuilder.DropTable(
                name: "peca");
        }
    }
}
