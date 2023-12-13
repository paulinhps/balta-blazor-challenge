using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IbgeBlazor.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CODIGO_ESTADO = table.Column<string>(type: "Char(2)", maxLength: 2, nullable: false),
                    NOME_ESTADO = table.Column<string>(type: "VarChar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS", x => new { x.ID, x.CODIGO_ESTADO });
                });

            migrationBuilder.CreateIndex(
                name: "IX_ESTATDOS_CODIGO_ESTADO",
                table: "ESTADOS",
                column: "CODIGO_ESTADO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESTADOS");
        }
    }
}
