using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class addAppointmentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MR",
                table: "PatientInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentStatus",
                table: "AppointmentMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentStatusId",
                table: "AppointmentMaster",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MR",
                table: "PatientInfo");

            migrationBuilder.DropColumn(
                name: "AppointmentStatus",
                table: "AppointmentMaster");

            migrationBuilder.DropColumn(
                name: "AppointmentStatusId",
                table: "AppointmentMaster");
        }
    }
}
