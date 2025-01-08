using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parser123.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVodoparadLinkName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VodopadLink",
                table: "products",
                newName: "VodoparadLink");

            migrationBuilder.RenameColumn(
                name: "VodopadPrice",
                table: "parseLogs",
                newName: "VodoparadPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VodoparadLink",
                table: "products",
                newName: "VodopadLink");

            migrationBuilder.RenameColumn(
                name: "VodoparadPrice",
                table: "parseLogs",
                newName: "VodopadPrice");
        }
    }
}
