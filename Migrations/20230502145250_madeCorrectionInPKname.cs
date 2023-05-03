using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace datafromexceltryingon3tables.Migrations
{
    /// <inheritdoc />
    public partial class madeCorrectionInPKname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterTables_BusinessUnits_businessUnitBuId",
                table: "MasterTables");

            migrationBuilder.RenameColumn(
                name: "businessUnitBuId",
                table: "MasterTables",
                newName: "BusinessUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_MasterTables_businessUnitBuId",
                table: "MasterTables",
                newName: "IX_MasterTables_BusinessUnitId");

            migrationBuilder.RenameColumn(
                name: "BuId",
                table: "BusinessUnits",
                newName: "BusinessUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTables_BusinessUnits_BusinessUnitId",
                table: "MasterTables",
                column: "BusinessUnitId",
                principalTable: "BusinessUnits",
                principalColumn: "BusinessUnitId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterTables_BusinessUnits_BusinessUnitId",
                table: "MasterTables");

            migrationBuilder.RenameColumn(
                name: "BusinessUnitId",
                table: "MasterTables",
                newName: "businessUnitBuId");

            migrationBuilder.RenameIndex(
                name: "IX_MasterTables_BusinessUnitId",
                table: "MasterTables",
                newName: "IX_MasterTables_businessUnitBuId");

            migrationBuilder.RenameColumn(
                name: "BusinessUnitId",
                table: "BusinessUnits",
                newName: "BuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTables_BusinessUnits_businessUnitBuId",
                table: "MasterTables",
                column: "businessUnitBuId",
                principalTable: "BusinessUnits",
                principalColumn: "BuId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
