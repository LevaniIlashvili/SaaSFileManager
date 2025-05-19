using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaaSFileManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddActivationTokenToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActivationToken",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivationToken",
                table: "Employees");
        }
    }
}
