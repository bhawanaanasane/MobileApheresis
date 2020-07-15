using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class KitTypeEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "KitTypeId",
                table: "MachineMaster",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KitType",
                table: "MachineMaster",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentRecordMasterId",
                table: "MachineMaster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MachineMaster_TreatmentRecordMasterId",
                table: "MachineMaster",
                column: "TreatmentRecordMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineMaster_TreatmentRecordMaster_TreatmentRecordMasterId",
                table: "MachineMaster",
                column: "TreatmentRecordMasterId",
                principalTable: "TreatmentRecordMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineMaster_TreatmentRecordMaster_TreatmentRecordMasterId",
                table: "MachineMaster");

            migrationBuilder.DropIndex(
                name: "IX_MachineMaster_TreatmentRecordMasterId",
                table: "MachineMaster");

            migrationBuilder.DropColumn(
                name: "TreatmentRecordMasterId",
                table: "MachineMaster");

            migrationBuilder.AlterColumn<int>(
                name: "KitTypeId",
                table: "MachineMaster",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "KitType",
                table: "MachineMaster",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
