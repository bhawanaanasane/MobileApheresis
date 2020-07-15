using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class SuppliesAndAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalValues");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "AccessPostAssessment");

            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.CreateTable(
                name: "FinalValuesAndAccessPostAssessment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<int>(nullable: false),
                    AC = table.Column<int>(nullable: false),
                    Inlet = table.Column<int>(nullable: false),
                    Plasma = table.Column<int>(nullable: false),
                    Collet = table.Column<int>(nullable: false),
                    FluidBalance = table.Column<string>(nullable: true),
                    BP = table.Column<string>(nullable: true),
                    T = table.Column<int>(nullable: false),
                    P = table.Column<int>(nullable: false),
                    R = table.Column<int>(nullable: false),
                    TreatmentRecordId = table.Column<int>(nullable: true),
                    NewDressing = table.Column<bool>(nullable: false),
                    Reinforced = table.Column<bool>(nullable: false),
                    Intact = table.Column<bool>(nullable: false),
                    Saline = table.Column<bool>(nullable: false),
                    Heparin = table.Column<bool>(nullable: false),
                    ChlorhexidineCapApplied = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalValuesAndAccessPostAssessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalValuesAndAccessPostAssessment_TreatmentRecordMaster_TreatmentRecordId",
                        column: x => x.TreatmentRecordId,
                        principalTable: "TreatmentRecordMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuppliesAndAccess",
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
                    TEMP = table.Column<decimal>(nullable: false),
                    Serial = table.Column<string>(nullable: true),
                    LastDoseDate = table.Column<DateTime>(nullable: true),
                    DateDC = table.Column<DateTime>(nullable: false),
                    CVC = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Peripheral = table.Column<bool>(nullable: false),
                    Vortex = table.Column<bool>(nullable: false),
                    Locations = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuppliesAndAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuppliesAndAccess_TreatmentRecordMaster_TreatmentRecordId",
                        column: x => x.TreatmentRecordId,
                        principalTable: "TreatmentRecordMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinalValuesAndAccessPostAssessment_TreatmentRecordId",
                table: "FinalValuesAndAccessPostAssessment",
                column: "TreatmentRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_SuppliesAndAccess_TreatmentRecordId",
                table: "SuppliesAndAccess",
                column: "TreatmentRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalValuesAndAccessPostAssessment");

            migrationBuilder.DropTable(
                name: "SuppliesAndAccess");

            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CVC = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Locations = table.Column<string>(nullable: true),
                    Peripheral = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Vortex = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessPostAssessment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChlorhexidineCapApplied = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Heparin = table.Column<bool>(nullable: false),
                    Intact = table.Column<bool>(nullable: false),
                    NewDressing = table.Column<bool>(nullable: false),
                    Reinforced = table.Column<bool>(nullable: false),
                    Saline = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPostAssessment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ACDLot = table.Column<string>(nullable: true),
                    ACDLotExpDate = table.Column<DateTime>(nullable: false),
                    ACEInhibitors = table.Column<bool>(nullable: false),
                    AccessId = table.Column<int>(nullable: true),
                    BloodWarmer = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DateDC = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    LastDoseDate = table.Column<DateTime>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    MedsReviewed = table.Column<bool>(nullable: false),
                    NSPrimeLot = table.Column<string>(nullable: true),
                    NSPrimeLotExpDate = table.Column<DateTime>(nullable: false),
                    Rate = table.Column<string>(nullable: true),
                    Serial = table.Column<string>(nullable: true),
                    TEMP = table.Column<decimal>(nullable: false),
                    TreatmentRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplies_Access_AccessId",
                        column: x => x.AccessId,
                        principalTable: "Access",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplies_TreatmentRecordMaster_TreatmentRecordId",
                        column: x => x.TreatmentRecordId,
                        principalTable: "TreatmentRecordMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinalValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AC = table.Column<int>(nullable: false),
                    AccessPostAssessmentId = table.Column<int>(nullable: false),
                    BP = table.Column<string>(nullable: true),
                    Collet = table.Column<int>(nullable: false),
                    FluidBalance = table.Column<string>(nullable: true),
                    Inlet = table.Column<int>(nullable: false),
                    P = table.Column<int>(nullable: false),
                    Plasma = table.Column<int>(nullable: false),
                    R = table.Column<int>(nullable: false),
                    T = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    TreatmentRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalValues_AccessPostAssessment_AccessPostAssessmentId",
                        column: x => x.AccessPostAssessmentId,
                        principalTable: "AccessPostAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalValues_TreatmentRecordMaster_TreatmentRecordId",
                        column: x => x.TreatmentRecordId,
                        principalTable: "TreatmentRecordMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinalValues_AccessPostAssessmentId",
                table: "FinalValues",
                column: "AccessPostAssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalValues_TreatmentRecordId",
                table: "FinalValues",
                column: "TreatmentRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_AccessId",
                table: "Supplies",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_TreatmentRecordId",
                table: "Supplies",
                column: "TreatmentRecordId");
        }
    }
}
