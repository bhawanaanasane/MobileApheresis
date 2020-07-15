using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class AppointmentChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "MR",
                table: "PatientMaster");

            migrationBuilder.DropColumn(
                name: "PatientAddressId",
                table: "PatientMaster");

            migrationBuilder.AddColumn<int>(
                name: "PatientMasterId",
                table: "PatientInfo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppointmentMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientName = table.Column<string>(nullable: true),
                    MR = table.Column<string>(nullable: true),
                    HospitalId = table.Column<int>(nullable: true),
                    HospitalMasterId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentMaster_HospitalMaster_HospitalMasterId",
                        column: x => x.HospitalMasterId,
                        principalTable: "HospitalMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppointmentMasterId = table.Column<int>(nullable: false),
                    AppointmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentDates_AppointmentMaster_AppointmentMasterId",
                        column: x => x.AppointmentMasterId,
                        principalTable: "AppointmentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientInfo_PatientMasterId",
                table: "PatientInfo",
                column: "PatientMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDates_AppointmentMasterId",
                table: "AppointmentDates",
                column: "AppointmentMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentMaster_HospitalMasterId",
                table: "AppointmentMaster",
                column: "HospitalMasterId");

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
                name: "AppointmentDates");

            migrationBuilder.DropTable(
                name: "AppointmentMaster");

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

            migrationBuilder.AddColumn<string>(
                name: "MR",
                table: "PatientMaster",
                nullable: true);

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
    }
}
