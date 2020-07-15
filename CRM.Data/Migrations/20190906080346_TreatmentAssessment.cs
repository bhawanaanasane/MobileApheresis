using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class TreatmentAssessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastDose",
                table: "Supplies");

            migrationBuilder.AlterColumn<decimal>(
                name: "TEMP",
                table: "Supplies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastDoseDate",
                table: "Supplies",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "PreTreatmentAssessment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsAlert = table.Column<bool>(nullable: false),
                    IsLethargic = table.Column<bool>(nullable: false),
                    IsComatose = table.Column<bool>(nullable: false),
                    OrientedX = table.Column<string>(nullable: true),
                    IsWeakness = table.Column<bool>(nullable: false),
                    WeaknessAutoTextId = table.Column<int>(nullable: true),
                    IsNumbness = table.Column<bool>(nullable: false),
                    NumbnessAutoTextId = table.Column<int>(nullable: true),
                    PainAutoTextId = table.Column<int>(nullable: true),
                    LocationAutoTextId = table.Column<int>(nullable: true),
                    IsEasy = table.Column<bool>(nullable: false),
                    IsLabored = table.Column<bool>(nullable: false),
                    OSat = table.Column<string>(nullable: true),
                    IsNC = table.Column<bool>(nullable: false),
                    IsRoomAir = table.Column<bool>(nullable: false),
                    IsMask = table.Column<bool>(nullable: false),
                    IsVent = table.Column<bool>(nullable: false),
                    IsFiO2 = table.Column<bool>(nullable: false),
                    LungSoundsAutoTextId = table.Column<int>(nullable: true),
                    RythmAutoTextId = table.Column<int>(nullable: true),
                    IsEdema = table.Column<bool>(nullable: false),
                    EdemaAutoTextId = table.Column<int>(nullable: true),
                    IsBleeding = table.Column<bool>(nullable: false),
                    BleendAutoTextId = table.Column<int>(nullable: true),
                    SkinAutoTextId = table.Column<int>(nullable: true),
                    TreatmentRecordMasterId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreTreatmentAssessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreTreatmentAssessment_TreatmentRecordMaster_TreatmentRecordMasterId",
                        column: x => x.TreatmentRecordMasterId,
                        principalTable: "TreatmentRecordMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreTreatmentAssessment_TreatmentRecordMasterId",
                table: "PreTreatmentAssessment",
                column: "TreatmentRecordMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreTreatmentAssessment");

            migrationBuilder.AlterColumn<string>(
                name: "TEMP",
                table: "Supplies",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastDoseDate",
                table: "Supplies",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastDose",
                table: "Supplies",
                nullable: true);
        }
    }
}
