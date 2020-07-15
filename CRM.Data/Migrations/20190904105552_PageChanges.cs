using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class PageChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreatmentRecordMasterId",
                table: "PreTreatmentCheck",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreTreatmentCheck_TreatmentRecordMasterId",
                table: "PreTreatmentCheck",
                column: "TreatmentRecordMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreTreatmentCheck_TreatmentRecordMaster_TreatmentRecordMasterId",
                table: "PreTreatmentCheck",
                column: "TreatmentRecordMasterId",
                principalTable: "TreatmentRecordMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreTreatmentCheck_TreatmentRecordMaster_TreatmentRecordMasterId",
                table: "PreTreatmentCheck");

            migrationBuilder.DropIndex(
                name: "IX_PreTreatmentCheck_TreatmentRecordMasterId",
                table: "PreTreatmentCheck");

            migrationBuilder.DropColumn(
                name: "TreatmentRecordMasterId",
                table: "PreTreatmentCheck");
        }
    }
}
