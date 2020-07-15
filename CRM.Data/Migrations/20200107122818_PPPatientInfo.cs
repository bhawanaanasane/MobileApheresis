using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class PPPatientInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientInfo_NurseMaster_NurseMasterId",
                table: "PatientInfo");

            migrationBuilder.AlterColumn<int>(
                name: "NurseMasterId",
                table: "PatientInfo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInfo_NurseMaster_NurseMasterId",
                table: "PatientInfo",
                column: "NurseMasterId",
                principalTable: "NurseMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientInfo_NurseMaster_NurseMasterId",
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
    }
}
