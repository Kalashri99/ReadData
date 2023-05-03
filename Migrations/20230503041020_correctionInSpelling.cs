using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace datafromexceltryingon3tables.Migrations
{
    /// <inheritdoc />
    public partial class correctionInSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BussinessUnitId",
                table: "MasterTables");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BussinessUnitId",
                table: "MasterTables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
