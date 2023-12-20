using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IbgeBlazor.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStateIdentityV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    CODIGO_ESTADO = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    NOME_ESTADO = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MUNICIPIOS",
                columns: table => new
                {
                    CODIGO_MUNICIPIO = table.Column<string>(type: "char(7)", maxLength: 7, nullable: false),
                    NOME_MUNICIPIO = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    UF_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUNICIPIOS", x => x.CODIGO_MUNICIPIO);
                    table.ForeignKey(
                        name: "FK_MUNICIPIOS_ESTADOS_UF_ID",
                        column: x => x.UF_ID,
                        principalTable: "ESTADOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ESTADOS_CODIGO_ESTADO",
                table: "ESTADOS",
                column: "CODIGO_ESTADO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MUNICIPIOS_NOME_MUNICIPIO",
                table: "MUNICIPIOS",
                column: "NOME_MUNICIPIO");

            migrationBuilder.CreateIndex(
                name: "IX_MUNICIPIOS_UF_ID",
                table: "MUNICIPIOS",
                column: "UF_ID");
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
