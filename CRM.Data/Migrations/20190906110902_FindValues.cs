using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class FindValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Access_Supplies_SuppliesId",
                table: "Access");

            migrationBuilder.DropIndex(
                name: "IX_Access_SuppliesId",
                table: "Access");

            migrationBuilder.DropColumn(
                name: "SuppliesId",
                table: "Access");

            migrationBuilder.AddColumn<int>(
                name: "AccessId",
                table: "Supplies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccessPostAssessment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewDressing = table.Column<bool>(nullable: false),
                    Reinforced = table.Column<bool>(nullable: false),
                    Intact = table.Column<bool>(nullable: false),
                    Saline = table.Column<bool>(nullable: false),
                    Heparin = table.Column<bool>(nullable: false),
                    ChlorhexidineCapApplied = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPostAssessment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RunTime = table.Column<TimeSpan>(nullable: false),
                    ACFlowRate = table.Column<int>(nullable: false),
                    ACFlowVol = table.Column<int>(nullable: false),
                    IntelFlowRate = table.Column<int>(nullable: false),
                    IntelFlowVol = table.Column<int>(nullable: false),
                    PlasmaFlowRate = table.Column<int>(nullable: false),
                    PlasmaFlowVol = table.Column<int>(nullable: false),
                    CollectFlowRate = table.Column<int>(nullable: false),
                    CollectFlowVol = table.Column<int>(nullable: false),
                    WarmerTemp = table.Column<decimal>(nullable: false),
                    ReplaceFluidId = table.Column<int>(nullable: false),
                    ReplaceFluid = table.Column<int>(nullable: false),
                    LotNo = table.Column<string>(nullable: true),
                    BP = table.Column<string>(nullable: true),
                    T = table.Column<int>(nullable: false),
                    P = table.Column<int>(nullable: false),
                    R = table.Column<int>(nullable: false),
                    TreatmentRecordMasterId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunValues_TreatmentRecordMaster_TreatmentRecordMasterId",
                        column: x => x.TreatmentRecordMasterId,
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
                    AccessPostAssessmentId = table.Column<int>(nullable: false)
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
                name: "IX_Supplies_AccessId",
                table: "Supplies",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalValues_AccessPostAssessmentId",
                table: "FinalValues",
                column: "AccessPostAssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalValues_TreatmentRecordId",
                table: "FinalValues",
                column: "TreatmentRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RunValues_TreatmentRecordMasterId",
                table: "RunValues",
                column: "TreatmentRecordMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Access_AccessId",
                table: "Supplies",
                column: "AccessId",
                principalTable: "Access",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Access_AccessId",
                table: "Supplies");

            migrationBuilder.DropTable(
                name: "FinalValues");

            migrationBuilder.DropTable(
                name: "RunValues");

            migrationBuilder.DropTable(
                name: "AccessPostAssessment");

            migrationBuilder.DropIndex(
                name: "IX_Supplies_AccessId",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "AccessId",
                table: "Supplies");

            migrationBuilder.AddColumn<int>(
                name: "SuppliesId",
                table: "Access",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Access_SuppliesId",
                table: "Access",
                column: "SuppliesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Access_Supplies_SuppliesId",
                table: "Access",
                column: "SuppliesId",
                principalTable: "Supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
