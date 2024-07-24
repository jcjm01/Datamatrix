using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRGeneratorAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eliminar la tabla si ya existe
            migrationBuilder.Sql("IF OBJECT_ID('Nameplates', 'U') IS NOT NULL DROP TABLE Nameplates");

            migrationBuilder.CreateTable(
                name: "Nameplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Refrigerant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectricalData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingPressures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagrams = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nameplates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nameplates");
        }
    }
}
