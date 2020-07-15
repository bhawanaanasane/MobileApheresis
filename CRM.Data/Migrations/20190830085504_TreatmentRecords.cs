using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class TreatmentRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "PatientInfo");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "PatientInfo",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "PatientMasterId",
                table: "PatientInfo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TreatmentRecordMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    TreatmentStatusId = table.Column<int>(nullable: false),
                    TreatmentStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentRecordMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DoctorName = table.Column<string>(nullable: true),
                    OrdersReviewed = table.Column<bool>(nullable: false),
                    Room = table.Column<string>(nullable: true),
                    OutPatient = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    EducatioPreTreatmentId = table.Column<int>(nullable: false),
                    EducatioPreTreatment = table.Column<int>(nullable: false),
                    TreatmentRecordMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorInfo_TreatmentRecordMaster_TreatmentRecordMasterId",
                        column: x => x.TreatmentRecordMasterId,
                        principalTable: "TreatmentRecordMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientName = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    TreatmentRecordMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientMaster_TreatmentRecordMaster_TreatmentRecordMasterId",
                        column: x => x.TreatmentRecordMasterId,
                        principalTable: "TreatmentRecordMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientInfo_PatientMasterId",
                table: "PatientInfo",
                column: "PatientMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorInfo_TreatmentRecordMasterId",
                table: "DoctorInfo",
                column: "TreatmentRecordMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMaster_TreatmentRecordMasterId",
                table: "PatientMaster",
                column: "TreatmentRecordMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInfo_PatientMaster_PatientMasterId",
                table: "PatientInfo",
                column: "PatientMasterId",
                principalTable: "PatientMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientInfo_PatientMaster_PatientMasterId",
                table: "PatientInfo");

            migrationBuilder.DropTable(
                name: "DoctorInfo");

            migrationBuilder.DropTable(
                name: "PatientMaster");

            migrationBuilder.DropTable(
                name: "TreatmentRecordMaster");

            migrationBuilder.DropIndex(
                name: "IX_PatientInfo_PatientMasterId",
                table: "PatientInfo");

            migrationBuilder.DropColumn(
                name: "PatientMasterId",
                table: "PatientInfo");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "PatientInfo",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "PatientInfo",
                nullable: true);
        }
    }
}
