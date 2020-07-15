using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class appointmentFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "TreatmentRecordMaster",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentMasterId",
                table: "TreatmentRecordMaster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentRecordMaster_AppointmentMasterId",
                table: "TreatmentRecordMaster",
                column: "AppointmentMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecordMaster_AppointmentMaster_AppointmentMasterId",
                table: "TreatmentRecordMaster",
                column: "AppointmentMasterId",
                principalTable: "AppointmentMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecordMaster_AppointmentMaster_AppointmentMasterId",
                table: "TreatmentRecordMaster");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentRecordMaster_AppointmentMasterId",
                table: "TreatmentRecordMaster");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "TreatmentRecordMaster");

            migrationBuilder.DropColumn(
                name: "AppointmentMasterId",
                table: "TreatmentRecordMaster");
        }
    }
}
