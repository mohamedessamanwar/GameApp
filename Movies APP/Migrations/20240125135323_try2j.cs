using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_APP.Migrations
{
    /// <inheritdoc />
    public partial class try2j : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "m",
                table: "Devices",
                newName: "n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "n",
                table: "Devices",
                newName: "m");
        }
    }
}
