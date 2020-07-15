using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class userrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeShipping",
                table: "CustomerRole");

            migrationBuilder.DropColumn(
                name: "IsSystemRole",
                table: "CustomerRole");

            migrationBuilder.DropColumn(
                name: "TaxExempt",
                table: "CustomerRole");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomerRole",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomerRole");

            migrationBuilder.AddColumn<bool>(
                name: "FreeShipping",
                table: "CustomerRole",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystemRole",
                table: "CustomerRole",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TaxExempt",
                table: "CustomerRole",
                nullable: false,
                defaultValue: false);
        }
    }
}
