using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class AppointmentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentStatus",
                table: "AppointmentMaster");

            migrationBuilder.DropColumn(
                name: "AppointmentStatusId",
                table: "AppointmentMaster");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentStatus",
                table: "AppointmentDates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentStatusId",
                table: "AppointmentDates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentStatus",
                table: "AppointmentDates");

            migrationBuilder.DropColumn(
                name: "AppointmentStatusId",
                table: "AppointmentDates");

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
    }
}
