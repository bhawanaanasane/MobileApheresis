using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class MarkComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MarkComplete",
                table: "SuppliesAndAccess",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MarkComplete",
                table: "RunValues",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MarkComplete",
                table: "PreTreatmentCheck",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MarkComplete",
                table: "PreTreatmentAssessment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MarkComplete",
                table: "PostTreatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MarkComplete",
                table: "PatientInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MarkComplete",
                table: "NoteAndReportMaster",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MarkComplete",
                table: "MachineMaster",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MarkComplete",
                table: "LabValues",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MarkComplete",
                table: "FinalValuesAndAccessPostAssessment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MarkComplete",
                table: "DoctorInfo",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarkComplete",
                table: "SuppliesAndAccess");

            migrationBuilder.DropColumn(
                name: "MarkComplete",
                table: "RunValues");

            migrationBuilder.DropColumn(
                name: "MarkComplete",
                table: "PreTreatmentCheck");

            migrationBuilder.DropColumn(
                name: "MarkComplete",
                table: "PreTreatmentAssessment");

            migrationBuilder.DropColumn(
                name: "MarkComplete",
                table: "PostTreatment");

            migrationBuilder.DropColumn(
                name: "MarkComplete",
                table: "PatientInfo");

            migrationBuilder.DropColumn(
                name: "MarkComplete",
                table: "NoteAndReportMaster");

            migrationBuilder.DropColumn(
                name: "MarkComplete",
                table: "MachineMaster");

            migrationBuilder.DropColumn(
                name: "MarkComplete",
                table: "LabValues");

            migrationBuilder.DropColumn(
                name: "MarkComplete",
                table: "FinalValuesAndAccessPostAssessment");

            migrationBuilder.DropColumn(
                name: "MarkComplete",
                table: "DoctorInfo");
        }
    }
}
