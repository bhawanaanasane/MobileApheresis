using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class Appointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientInfo_PatientMaster_PatientMasterId",
                table: "PatientInfo");

            migrationBuilder.DropIndex(
                name: "IX_PatientInfo_PatientMasterId",
                table: "PatientInfo");

            migrationBuilder.DropColumn(
                name: "PatientMasterId",
                table: "PatientInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentDate",
                table: "TreatmentRecordMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PatientMasterId",
                table: "TreatmentRecordMaster",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "PatientMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "PatientMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "PatientMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientAddressId",
                table: "PatientMaster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentRecordMaster_PatientMasterId",
                table: "TreatmentRecordMaster",
                column: "PatientMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMaster_PatientAddressId",
                table: "PatientMaster",
                column: "PatientAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMaster_Address_PatientAddressId",
                table: "PatientMaster",
                column: "PatientAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecordMaster_PatientMaster_PatientMasterId",
                table: "TreatmentRecordMaster",
                column: "PatientMasterId",
                principalTable: "PatientMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMaster_Address_PatientAddressId",
                table: "PatientMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecordMaster_PatientMaster_PatientMasterId",
                table: "TreatmentRecordMaster");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentRecordMaster_PatientMasterId",
                table: "TreatmentRecordMaster");

            migrationBuilder.DropIndex(
                name: "IX_PatientMaster_PatientAddressId",
                table: "PatientMaster");

            migrationBuilder.DropColumn(
                name: "AppointmentDate",
                table: "TreatmentRecordMaster");

            migrationBuilder.DropColumn(
                name: "PatientMasterId",
                table: "TreatmentRecordMaster");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "PatientMaster");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "PatientMaster");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "PatientMaster");

            migrationBuilder.DropColumn(
                name: "PatientAddressId",
                table: "PatientMaster");

            migrationBuilder.AddColumn<int>(
                name: "PatientMasterId",
                table: "PatientInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientInfo_PatientMasterId",
                table: "PatientInfo",
                column: "PatientMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInfo_PatientMaster_PatientMasterId",
                table: "PatientInfo",
                column: "PatientMasterId",
                principalTable: "PatientMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
