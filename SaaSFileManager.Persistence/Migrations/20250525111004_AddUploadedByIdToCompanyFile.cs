using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaaSFileManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUploadedByIdToCompanyFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UploadedById",
                table: "CompanyFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadedById",
                table: "CompanyFiles");
        }
    }
}
