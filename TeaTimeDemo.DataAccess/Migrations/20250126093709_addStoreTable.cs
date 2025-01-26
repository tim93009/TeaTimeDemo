using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaTimeDemo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addStoreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripion",
                table: "Stores",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Stores",
                newName: "Descripion");
        }
    }
}
