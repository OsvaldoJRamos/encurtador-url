using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encurtador.Data.Migrations
{
    /// <inheritdoc />
    public partial class numerocliques : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroCliques",
                table: "Encurtado",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroCliques",
                table: "Encurtado");
        }
    }
}
