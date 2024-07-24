using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRGeneratorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerPartNumberToNameplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerPartNumber",
                table: "Nameplates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerPartNumber",
                table: "Nameplates");
        }
    }
}
