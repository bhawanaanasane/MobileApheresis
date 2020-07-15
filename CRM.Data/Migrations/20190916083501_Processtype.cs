using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class Processtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocType",
                table: "DownloadHistory",
                newName: "DocumentType");

            migrationBuilder.RenameColumn(
                name: "DocName",
                table: "DownloadHistory",
                newName: "DocumentPath");

            migrationBuilder.RenameColumn(
                name: "DocFormat",
                table: "DownloadHistory",
                newName: "DocumentName");

            migrationBuilder.AddColumn<string>(
                name: "DocumentFormat",
                table: "DownloadHistory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessType",
                table: "DownloadHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessTypeId",
                table: "DownloadHistory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentFormat",
                table: "DownloadHistory");

            migrationBuilder.DropColumn(
                name: "ProcessType",
                table: "DownloadHistory");

            migrationBuilder.DropColumn(
                name: "ProcessTypeId",
                table: "DownloadHistory");

            migrationBuilder.RenameColumn(
                name: "DocumentType",
                table: "DownloadHistory",
                newName: "DocType");

            migrationBuilder.RenameColumn(
                name: "DocumentPath",
                table: "DownloadHistory",
                newName: "DocName");

            migrationBuilder.RenameColumn(
                name: "DocumentName",
                table: "DownloadHistory",
                newName: "DocFormat");
        }
    }
}
