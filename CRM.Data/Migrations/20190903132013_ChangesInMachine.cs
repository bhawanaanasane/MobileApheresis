using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class ChangesInMachine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CleanedTrack",
                table: "MachineMaster",
                newName: "CleanedTrackDoors");

            migrationBuilder.RenameColumn(
                name: "CleanedPressure",
                table: "MachineMaster",
                newName: "CleanedPressurePODSSeals");

            migrationBuilder.AddColumn<bool>(
                name: "CleanedFrontDoorSensors",
                table: "MachineMaster",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CleanedFrontDoorSensors",
                table: "MachineMaster");

            migrationBuilder.RenameColumn(
                name: "CleanedTrackDoors",
                table: "MachineMaster",
                newName: "CleanedTrack");

            migrationBuilder.RenameColumn(
                name: "CleanedPressurePODSSeals",
                table: "MachineMaster",
                newName: "CleanedPressure");
        }
    }
}
