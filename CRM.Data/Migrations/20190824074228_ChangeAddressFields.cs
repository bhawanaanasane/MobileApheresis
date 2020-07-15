using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class ChangeAddressFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Country_CountryId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_StateProvince_StateProvinceId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Address_ShippingAddressId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ShippingAddressId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Address_CountryId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StateProvinceId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "AdminComment",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AffiliateId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Companyname",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "EmailToRevalidate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsTaxExempt",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ParentUserId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ShippingAddressId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AddressType",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "AddressTypeId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "StateProvinceId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Address",
                newName: "StateProvince");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StateProvince",
                table: "Address",
                newName: "Company");

            migrationBuilder.AddColumn<string>(
                name: "AdminComment",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AffiliateId",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Companyname",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailToRevalidate",
                table: "Customer",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaxExempt",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentUserId",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddressId",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressType",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressTypeId",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateProvinceId",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ShippingAddressId",
                table: "Customer",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateProvinceId",
                table: "Address",
                column: "StateProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Country_CountryId",
                table: "Address",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StateProvince_StateProvinceId",
                table: "Address",
                column: "StateProvinceId",
                principalTable: "StateProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Address_ShippingAddressId",
                table: "Customer",
                column: "ShippingAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
