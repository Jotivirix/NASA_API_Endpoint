using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NASAAPIEndpoint.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asteroid",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Diametro = table.Column<double>(type: "float", nullable: true),
                    Velocidad = table.Column<double>(type: "float", nullable: true),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Planeta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asteroid", x => x.Nombre);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asteroid");
        }
    }
}
