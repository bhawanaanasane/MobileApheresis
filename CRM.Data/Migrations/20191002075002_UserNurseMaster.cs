using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class UserNurseMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "NurseMaster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NurseMaster_UserId",
                table: "NurseMaster",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseMaster_Customer_UserId",
                table: "NurseMaster",
                column: "UserId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NurseMaster_Customer_UserId",
                table: "NurseMaster");

            migrationBuilder.DropIndex(
                name: "IX_NurseMaster_UserId",
                table: "NurseMaster");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NurseMaster");

            
        }
    }
}
