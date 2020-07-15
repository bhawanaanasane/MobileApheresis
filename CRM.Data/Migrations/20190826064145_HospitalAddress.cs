using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class HospitalAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalMaster_Address_BillingAddressId",
                table: "HospitalMaster");

            migrationBuilder.RenameColumn(
                name: "BillingAddressId",
                table: "HospitalMaster",
                newName: "HospitalAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_HospitalMaster_BillingAddressId",
                table: "HospitalMaster",
                newName: "IX_HospitalMaster_HospitalAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalMaster_Address_HospitalAddressId",
                table: "HospitalMaster",
                column: "HospitalAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalMaster_Address_HospitalAddressId",
                table: "HospitalMaster");

            migrationBuilder.RenameColumn(
                name: "HospitalAddressId",
                table: "HospitalMaster",
                newName: "BillingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_HospitalMaster_HospitalAddressId",
                table: "HospitalMaster",
                newName: "IX_HospitalMaster_BillingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalMaster_Address_BillingAddressId",
                table: "HospitalMaster",
                column: "BillingAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
