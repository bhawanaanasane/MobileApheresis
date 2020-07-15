using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class PatientInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    PatientName = table.Column<string>(nullable: true),
                    MR = table.Column<string>(nullable: true),
                    HospitalId = table.Column<int>(nullable: false),
                    NurseId = table.Column<int>(nullable: false),
                    ProcedureId = table.Column<int>(nullable: false),
                    DiagnosisId = table.Column<int>(nullable: false),
                    NurseMasterId = table.Column<int>(nullable: true),
                    PolicyAndProcedureId = table.Column<int>(nullable: true),
                    HospitalMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientInfo_Diagnosis_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnosis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientInfo_HospitalMaster_HospitalMasterId",
                        column: x => x.HospitalMasterId,
                        principalTable: "HospitalMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientInfo_NurseMaster_NurseMasterId",
                        column: x => x.NurseMasterId,
                        principalTable: "NurseMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientInfo_PolicyAndProcedure_PolicyAndProcedureId",
                        column: x => x.PolicyAndProcedureId,
                        principalTable: "PolicyAndProcedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientInfo_DiagnosisId",
                table: "PatientInfo",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInfo_HospitalMasterId",
                table: "PatientInfo",
                column: "HospitalMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInfo_NurseMasterId",
                table: "PatientInfo",
                column: "NurseMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInfo_PolicyAndProcedureId",
                table: "PatientInfo",
                column: "PolicyAndProcedureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientInfo");
        }
    }
}
