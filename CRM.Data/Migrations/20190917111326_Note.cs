using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class Note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TreatmentRecordNo",
                table: "TreatmentRecordMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NoteAndReportMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TreatmentRecordMasterId = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    ReportGivenTo = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteAndReportMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteAndReportMaster_TreatmentRecordMaster_TreatmentRecordMasterId",
                        column: x => x.TreatmentRecordMasterId,
                        principalTable: "TreatmentRecordMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteAndReportMaster_TreatmentRecordMasterId",
                table: "NoteAndReportMaster",
                column: "TreatmentRecordMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteAndReportMaster");

            migrationBuilder.DropColumn(
                name: "TreatmentRecordNo",
                table: "TreatmentRecordMaster");
        }
    }
}
