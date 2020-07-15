using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class General : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneralId",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "General",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerGuid = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Companyname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_General", x => x.Id);
                    table.ForeignKey(
                        name: "FK_General_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_GeneralId",
                table: "Address",
                column: "GeneralId");

            migrationBuilder.CreateIndex(
                name: "IX_General_AddressId",
                table: "General",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_General_GeneralId",
                table: "Address",
                column: "GeneralId",
                principalTable: "General",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_General_GeneralId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "General");

            migrationBuilder.DropIndex(
                name: "IX_Address_GeneralId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "GeneralId",
                table: "Address");
        }
    }
}
