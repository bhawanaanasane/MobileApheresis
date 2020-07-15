using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class AppointmentDatesIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecordMaster_AppointmentMaster_AppointmentMasterId",
                table: "TreatmentRecordMaster");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "TreatmentRecordMaster");

            migrationBuilder.RenameColumn(
                name: "AppointmentMasterId",
                table: "TreatmentRecordMaster",
                newName: "AppointmentDateId");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentRecordMaster_AppointmentMasterId",
                table: "TreatmentRecordMaster",
                newName: "IX_TreatmentRecordMaster_AppointmentDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecordMaster_AppointmentDates_AppointmentDateId",
                table: "TreatmentRecordMaster",
                column: "AppointmentDateId",
                principalTable: "AppointmentDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecordMaster_AppointmentDates_AppointmentDateId",
                table: "TreatmentRecordMaster");

            migrationBuilder.RenameColumn(
                name: "AppointmentDateId",
                table: "TreatmentRecordMaster",
                newName: "AppointmentMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentRecordMaster_AppointmentDateId",
                table: "TreatmentRecordMaster",
                newName: "IX_TreatmentRecordMaster_AppointmentMasterId");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "TreatmentRecordMaster",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecordMaster_AppointmentMaster_AppointmentMasterId",
                table: "TreatmentRecordMaster",
                column: "AppointmentMasterId",
                principalTable: "AppointmentMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
