using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class NullValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsTreatmentCompletedWOIncident",
                table: "NoteAndReportMaster",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsTreatmentCompletedWOIncident",
                table: "NoteAndReportMaster",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
