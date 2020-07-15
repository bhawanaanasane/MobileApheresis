using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class LabValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TreatmentRecordMasterId = table.Column<int>(nullable: true),
                    Height = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    EBV = table.Column<decimal>(nullable: false),
                    EPV = table.Column<decimal>(nullable: false),
                    ECV10 = table.Column<decimal>(nullable: false),
                    ECV15 = table.Column<decimal>(nullable: false),
                    HGB = table.Column<decimal>(nullable: false),
                    HTC = table.Column<decimal>(nullable: false),
                    WBC = table.Column<decimal>(nullable: false),
                    PLT = table.Column<decimal>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabValues_TreatmentRecordMaster_TreatmentRecordMasterId",
                        column: x => x.TreatmentRecordMasterId,
                        principalTable: "TreatmentRecordMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherLabValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LabValuesId = table.Column<int>(nullable: true),
                    ContentName = table.Column<string>(nullable: true),
                    ContentValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherLabValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherLabValues_LabValues_LabValuesId",
                        column: x => x.LabValuesId,
                        principalTable: "LabValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabValues_TreatmentRecordMasterId",
                table: "LabValues",
                column: "TreatmentRecordMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherLabValues_LabValuesId",
                table: "OtherLabValues",
                column: "LabValuesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherLabValues");

            migrationBuilder.DropTable(
                name: "LabValues");
        }
    }
}
