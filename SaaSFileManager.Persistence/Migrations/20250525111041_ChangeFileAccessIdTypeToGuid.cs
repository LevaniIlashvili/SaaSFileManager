using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaaSFileManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFileAccessIdTypeToGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop FK and PK
            migrationBuilder.DropForeignKey(
                name: "FK_FileAccesses_CompanyFiles_FileId",
                table: "FileAccesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileAccesses",
                table: "FileAccesses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FileAccesses");

            // Add new column
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "FileAccesses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            // Recreate PK
            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyFileAccess",
                table: "FileAccesses",
                column: "Id");

            // Re-add FK
            migrationBuilder.AddForeignKey(
                name: "FK_FileAccesses_CompanyFiles_FileId",
                table: "FileAccesses",
                column: "FileId",
                principalTable: "CompanyFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FileAccesses",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
