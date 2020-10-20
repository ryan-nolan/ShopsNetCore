using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopsNetCore.Data.Migrations
{
    public partial class AddedAddressLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Shops");

            migrationBuilder.AddColumn<string>(
                name: "AddressLineOne",
                table: "Shops",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLineTwo",
                table: "Shops",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "Shops",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLineOne",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "AddressLineTwo",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Shops");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Shops",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }
    }
}
