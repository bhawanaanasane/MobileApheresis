using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class CompanyProfileUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CompanyProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Companyname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    License = table.Column<string>(nullable: true),
                    CompanyAddressId = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProfile_Address_CompanyAddressId",
                        column: x => x.CompanyAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDocument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyProfileId = table.Column<int>(nullable: false),
                    DocumentName = table.Column<string>(nullable: true),
                    DocumentPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyDocument_CompanyProfile_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyAndProcedure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyProfileId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    IsPolicy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyAndProcedure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyAndProcedure_CompanyProfile_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDocument_CompanyProfileId",
                table: "CompanyDocument",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfile_CompanyAddressId",
                table: "CompanyProfile",
                column: "CompanyAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyAndProcedure_CompanyProfileId",
                table: "PolicyAndProcedure",
                column: "CompanyProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyDocument");

            migrationBuilder.DropTable(
                name: "PolicyAndProcedure");

            migrationBuilder.DropTable(
                name: "CompanyProfile");

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
                    AddressId = table.Column<int>(nullable: true),
                    Companyname = table.Column<string>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    CustomerGuid = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    License = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
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
    }
}
