using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IbgeBlazor.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MapCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO_ESTADO = table.Column<string>(type: "Char(2)", maxLength: 2, nullable: false),
                    NOME_ESTADO = table.Column<string>(type: "VarChar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MUNICIPIOS",
                columns: table => new
                {
                    CODIGO_MUNICIPIO = table.Column<string>(type: "Char(7)", maxLength: 7, nullable: false),
                    NOME_MUNICIPIO = table.Column<string>(type: "VarChar(80)", maxLength: 80, nullable: false),
                    CODIGO_UF = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUNICIPIOS", x => x.CODIGO_MUNICIPIO);
                    table.ForeignKey(
                        name: "FK_MUNICIPIOS_ESTADOS_CODIGO_UF",
                        column: x => x.CODIGO_UF,
                        principalTable: "ESTADOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ESTADOS_CODIGO_ESTADO",
                table: "ESTADOS",
                column: "CODIGO_ESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_MUNICIPIOS_CODIGO_UF",
                table: "MUNICIPIOS",
                column: "CODIGO_UF");

            migrationBuilder.CreateIndex(
                name: "IX_MUNICIPIOS_NOME_MUNICIPIO",
                table: "MUNICIPIOS",
                column: "NOME_MUNICIPIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MUNICIPIOS");

            migrationBuilder.DropTable(
                name: "ESTADOS");
        }
    }
}
