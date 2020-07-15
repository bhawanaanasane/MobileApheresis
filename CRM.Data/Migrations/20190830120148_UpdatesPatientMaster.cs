using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class UpdatesPatientMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMaster_TreatmentRecordMaster_TreatmentRecordMasterId",
                table: "PatientMaster");

            migrationBuilder.DropIndex(
                name: "IX_PatientMaster_TreatmentRecordMasterId",
                table: "PatientMaster");

            migrationBuilder.DropColumn(
                name: "TreatmentRecordMasterId",
                table: "PatientMaster");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "PatientInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TreatmentRecordMasterId",
                table: "PatientInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientInfo_TreatmentRecordMasterId",
                table: "PatientInfo",
                column: "TreatmentRecordMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInfo_TreatmentRecordMaster_TreatmentRecordMasterId",
                table: "PatientInfo",
                column: "TreatmentRecordMasterId",
                principalTable: "TreatmentRecordMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientInfo_TreatmentRecordMaster_TreatmentRecordMasterId",
                table: "PatientInfo");

            migrationBuilder.DropIndex(
                name: "IX_PatientInfo_TreatmentRecordMasterId",
                table: "PatientInfo");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "PatientInfo");

            migrationBuilder.DropColumn(
                name: "TreatmentRecordMasterId",
                table: "PatientInfo");

            migrationBuilder.AddColumn<int>(
                name: "TreatmentRecordMasterId",
                table: "PatientMaster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientMaster_TreatmentRecordMasterId",
                table: "PatientMaster",
                column: "TreatmentRecordMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMaster_TreatmentRecordMaster_TreatmentRecordMasterId",
                table: "PatientMaster",
                column: "TreatmentRecordMasterId",
                principalTable: "TreatmentRecordMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
