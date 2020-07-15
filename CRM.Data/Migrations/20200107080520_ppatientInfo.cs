using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class ppatientInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientInfo_NurseMaster_NurseMasterId",
                table: "PatientInfo");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "PatientInfo");

            migrationBuilder.DropColumn(
                name: "NurseId",
                table: "PatientInfo");

            migrationBuilder.AlterColumn<int>(
                name: "NurseMasterId",
                table: "PatientInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInfo_NurseMaster_NurseMasterId",
                table: "PatientInfo",
                column: "NurseMasterId",
                principalTable: "NurseMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientInfo_NurseMaster_NurseMasterId",
                table: "PatientInfo");

            migrationBuilder.AlterColumn<int>(
                name: "NurseMasterId",
                table: "PatientInfo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "PatientInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NurseId",
                table: "PatientInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInfo_NurseMaster_NurseMasterId",
                table: "PatientInfo",
                column: "NurseMasterId",
                principalTable: "NurseMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
