using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class Hospital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HospitalMasterId",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HospitalMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HospitalName = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    BillingAddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalMaster_Address_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_HospitalMasterId",
                table: "Address",
                column: "HospitalMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalMaster_BillingAddressId",
                table: "HospitalMaster",
                column: "BillingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_HospitalMaster_HospitalMasterId",
                table: "Address",
                column: "HospitalMasterId",
                principalTable: "HospitalMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_HospitalMaster_HospitalMasterId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "HospitalMaster");

            migrationBuilder.DropIndex(
                name: "IX_Address_HospitalMasterId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "HospitalMasterId",
                table: "Address");
        }
    }
}
