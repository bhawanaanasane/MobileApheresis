using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class MedicationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreatmentRecordId",
                table: "PostTreatment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostTreatment_TreatmentRecordId",
                table: "PostTreatment",
                column: "TreatmentRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTreatment_TreatmentRecordMaster_TreatmentRecordId",
                table: "PostTreatment",
                column: "TreatmentRecordId",
                principalTable: "TreatmentRecordMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTreatment_TreatmentRecordMaster_TreatmentRecordId",
                table: "PostTreatment");

            migrationBuilder.DropIndex(
                name: "IX_PostTreatment_TreatmentRecordId",
                table: "PostTreatment");

            migrationBuilder.DropColumn(
                name: "TreatmentRecordId",
                table: "PostTreatment");
        }
    }
}
