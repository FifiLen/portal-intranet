using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intranet.Migrations
{
    /// <inheritdoc />
    public partial class AddPortalTextSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "PortalTexts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Section",
                table: "PortalTexts");
        }
    }
}
