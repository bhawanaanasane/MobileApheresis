using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class removeCustomerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "NurseMaster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NurseMaster_CustomerId",
                table: "NurseMaster",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseMaster_Customer_CustomerId",
                table: "NurseMaster",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseMaster_Customer_CustomerId",
                table: "NurseMaster");

            migrationBuilder.DropIndex(
                name: "IX_NurseMaster_CustomerId",
                table: "NurseMaster");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "NurseMaster");
        }
    }
}
