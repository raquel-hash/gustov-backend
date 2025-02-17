using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSaleFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Sale");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sale",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sale");

            migrationBuilder.AddColumn<decimal>(
                name: "Nombre",
                table: "Sale",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
