using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace datafromexceltryingon3tables.Migrations
{
    /// <inheritdoc />
    public partial class changedDatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterTables",
                table: "MasterTables");

            migrationBuilder.DropColumn(
                name: "MasterTableId",
                table: "MasterTables");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceId",
                table: "MasterTables",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "GrandTotal",
                table: "Agings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterTables",
                table: "MasterTables",
                column: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterTables",
                table: "MasterTables");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "MasterTables");

            migrationBuilder.AddColumn<int>(
                name: "MasterTableId",
                table: "MasterTables",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "GrandTotal",
                table: "Agings",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterTables",
                table: "MasterTables",
                column: "MasterTableId");
        }
    }
}
