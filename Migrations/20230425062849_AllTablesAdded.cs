using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace datafromexceltryingon3tables.Migrations
{
    /// <inheritdoc />
    public partial class AllTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agings",
                columns: table => new
                {
                    AgingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _180Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _120180Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _90120Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _6090Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _3060Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _030Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotDue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnappliedReceiptsReconcialiationPending = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrandTotal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agings", x => x.AgingId);
                });

            migrationBuilder.CreateTable(
                name: "ArPocs",
                columns: table => new
                {
                    ArPOCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PocName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArPocs", x => x.ArPOCId);
                });

            migrationBuilder.CreateTable(
                name: "MasterTables",
                columns: table => new
                {
                    MasterTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgingId = table.Column<int>(type: "int", nullable: true),
                    ArPOCId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTables", x => x.MasterTableId);
                    table.ForeignKey(
                        name: "FK_MasterTables_Agings_AgingId",
                        column: x => x.AgingId,
                        principalTable: "Agings",
                        principalColumn: "AgingId");
                    table.ForeignKey(
                        name: "FK_MasterTables_ArPocs_ArPOCId",
                        column: x => x.ArPOCId,
                        principalTable: "ArPocs",
                        principalColumn: "ArPOCId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterTables_AgingId",
                table: "MasterTables",
                column: "AgingId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTables_ArPOCId",
                table: "MasterTables",
                column: "ArPOCId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterTables");

            migrationBuilder.DropTable(
                name: "Agings");

            migrationBuilder.DropTable(
                name: "ArPocs");
        }
    }
}
