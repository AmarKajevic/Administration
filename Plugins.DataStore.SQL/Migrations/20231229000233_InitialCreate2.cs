using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Address", "City", "FirstName", "LastName", "Phone", "PostalCode" },
                values: new object[] { "kovacevac bb", "Prijepolje", "Mica", "Micovic", 646432004, 31300 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Address", "City", "FirstName", "LastName", "Phone", "PostalCode" },
                values: new object[] { "kovacevac bb", "Prijepolje", "Mica", "Micovic", 646432004, 31300 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Address", "City", "FirstName", "LastName", "Phone", "PostalCode" },
                values: new object[] { "brodarevo bb", "Prijepolje", "Mica", "Micovic", 646432004, 31300 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Address", "City", "FirstName", "LastName", "Phone", "PostalCode" },
                values: new object[] { "gracanica bb", "Prijepolje", "Mica", "Micovic", 646432004, 31300 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Products");
        }
    }
}
