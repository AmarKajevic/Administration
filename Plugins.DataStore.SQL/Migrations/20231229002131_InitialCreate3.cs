using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Address", "City", "FirstName", "LastName" },
                values: new object[] { " ", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Address", "City", "FirstName", "LastName" },
                values: new object[] { "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Address", "City", "FirstName", "LastName" },
                values: new object[] { " ", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Address", "City", "FirstName", "LastName" },
                values: new object[] { " ", "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Address", "City", "FirstName", "LastName" },
                values: new object[] { "kovacevac bb", "Prijepolje", "Mica", "Micovic" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Address", "City", "FirstName", "LastName" },
                values: new object[] { "kovacevac bb", "Prijepolje", "Mica", "Micovic" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Address", "City", "FirstName", "LastName" },
                values: new object[] { "brodarevo bb", "Prijepolje", "Mica", "Micovic" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Address", "City", "FirstName", "LastName" },
                values: new object[] { "gracanica bb", "Prijepolje", "Mica", "Micovic" });
        }
    }
}
