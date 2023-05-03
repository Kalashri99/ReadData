using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace datafromexceltryingon3tables.Migrations
{
    /// <inheritdoc />
    public partial class addedAllRemainingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterTables_Agings_AgingId",
                table: "MasterTables");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterTables_ArPocs_ArPOCId",
                table: "MasterTables");

            migrationBuilder.AlterColumn<int>(
                name: "ArPOCId",
                table: "MasterTables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgingId",
                table: "MasterTables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BandId",
                table: "MasterTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BussinessUnitId",
                table: "MasterTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "MasterTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyCategoryId",
                table: "MasterTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "businessUnitBuId",
                table: "MasterTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    BandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.BandId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnits",
                columns: table => new
                {
                    BuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    newBuName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnits", x => x.BuId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "companyCategories",
                columns: table => new
                {
                    CompanyCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyCategories", x => x.CompanyCategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterTables_BandId",
                table: "MasterTables",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTables_businessUnitBuId",
                table: "MasterTables",
                column: "businessUnitBuId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTables_ClientId",
                table: "MasterTables",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTables_CompanyCategoryId",
                table: "MasterTables",
                column: "CompanyCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTables_Agings_AgingId",
                table: "MasterTables",
                column: "AgingId",
                principalTable: "Agings",
                principalColumn: "AgingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTables_ArPocs_ArPOCId",
                table: "MasterTables",
                column: "ArPOCId",
                principalTable: "ArPocs",
                principalColumn: "ArPOCId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTables_Bands_BandId",
                table: "MasterTables",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "BandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTables_BusinessUnits_businessUnitBuId",
                table: "MasterTables",
                column: "businessUnitBuId",
                principalTable: "BusinessUnits",
                principalColumn: "BuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTables_Clients_ClientId",
                table: "MasterTables",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTables_companyCategories_CompanyCategoryId",
                table: "MasterTables",
                column: "CompanyCategoryId",
                principalTable: "companyCategories",
                principalColumn: "CompanyCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterTables_Agings_AgingId",
                table: "MasterTables");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterTables_ArPocs_ArPOCId",
                table: "MasterTables");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterTables_Bands_BandId",
                table: "MasterTables");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterTables_BusinessUnits_businessUnitBuId",
                table: "MasterTables");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterTables_Clients_ClientId",
                table: "MasterTables");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterTables_companyCategories_CompanyCategoryId",
                table: "MasterTables");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "BusinessUnits");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "companyCategories");

            migrationBuilder.DropIndex(
                name: "IX_MasterTables_BandId",
                table: "MasterTables");

            migrationBuilder.DropIndex(
                name: "IX_MasterTables_businessUnitBuId",
                table: "MasterTables");

            migrationBuilder.DropIndex(
                name: "IX_MasterTables_ClientId",
                table: "MasterTables");

            migrationBuilder.DropIndex(
                name: "IX_MasterTables_CompanyCategoryId",
                table: "MasterTables");

            migrationBuilder.DropColumn(
                name: "BandId",
                table: "MasterTables");

            migrationBuilder.DropColumn(
                name: "BussinessUnitId",
                table: "MasterTables");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "MasterTables");

            migrationBuilder.DropColumn(
                name: "CompanyCategoryId",
                table: "MasterTables");

            migrationBuilder.DropColumn(
                name: "businessUnitBuId",
                table: "MasterTables");

            migrationBuilder.AlterColumn<int>(
                name: "ArPOCId",
                table: "MasterTables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AgingId",
                table: "MasterTables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTables_Agings_AgingId",
                table: "MasterTables",
                column: "AgingId",
                principalTable: "Agings",
                principalColumn: "AgingId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTables_ArPocs_ArPOCId",
                table: "MasterTables",
                column: "ArPOCId",
                principalTable: "ArPocs",
                principalColumn: "ArPOCId");
        }
    }
}
