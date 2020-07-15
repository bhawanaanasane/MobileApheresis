using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class Access : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TreatmentRecordId = table.Column<int>(nullable: true),
                    ACDLot = table.Column<string>(nullable: true),
                    ACDLotExpDate = table.Column<DateTime>(nullable: false),
                    NSPrimeLot = table.Column<string>(nullable: true),
                    NSPrimeLotExpDate = table.Column<DateTime>(nullable: false),
                    Rate = table.Column<string>(nullable: true),
                    BloodWarmer = table.Column<bool>(nullable: false),
                    ACEInhibitors = table.Column<bool>(nullable: false),
                    MedsReviewed = table.Column<bool>(nullable: false),
                    TEMP = table.Column<string>(nullable: true),
                    Serial = table.Column<string>(nullable: true),
                    LastDose = table.Column<string>(nullable: true),
                    LastDoseDate = table.Column<DateTime>(nullable: false),
                    DateDC = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplies_TreatmentRecordMaster_TreatmentRecordId",
                        column: x => x.TreatmentRecordId,
                        principalTable: "TreatmentRecordMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SuppliesId = table.Column<int>(nullable: true),
                    CVC = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Peripheral = table.Column<bool>(nullable: false),
                    Vortex = table.Column<bool>(nullable: false),
                    Locations = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Access_Supplies_SuppliesId",
                        column: x => x.SuppliesId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Access_SuppliesId",
                table: "Access",
                column: "SuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_TreatmentRecordId",
                table: "Supplies",
                column: "TreatmentRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.DropTable(
                name: "Supplies");
        }
    }
}
