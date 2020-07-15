using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class MachineMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MachineMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipmentId = table.Column<int>(nullable: true),
                    EquipSerial = table.Column<string>(nullable: true),
                    KitTypeId = table.Column<int>(nullable: true),
                    KitType = table.Column<string>(nullable: true),
                    PMDate = table.Column<DateTime>(nullable: false),
                    ExpDate = table.Column<DateTime>(nullable: false),
                    SafetyChkDate = table.Column<DateTime>(nullable: false),
                    MachineClean = table.Column<bool>(nullable: false),
                    AlarmCheck = table.Column<bool>(nullable: false),
                    CorrectiveAction = table.Column<string>(nullable: true),
                    PrimeSuccess = table.Column<bool>(nullable: false),
                    CleanedTrack = table.Column<bool>(nullable: false),
                    CleanedSensors = table.Column<bool>(nullable: false),
                    CleanedPressure = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineMaster_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineMaster_EquipmentId",
                table: "MachineMaster",
                column: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineMaster");
        }
    }
}
