using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Administration.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistrationTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationTime",
                table: "AspNetUsers");
        }
    }
}
