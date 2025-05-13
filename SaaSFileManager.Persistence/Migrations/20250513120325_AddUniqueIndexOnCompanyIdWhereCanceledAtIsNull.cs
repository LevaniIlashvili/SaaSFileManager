using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaaSFileManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexOnCompanyIdWhereCanceledAtIsNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompanySubscriptions_CompanyId",
                table: "CompanySubscriptions");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubscriptions_CompanyId",
                table: "CompanySubscriptions",
                column: "CompanyId",
                unique: true,
                filter: "CanceledAt IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompanySubscriptions_CompanyId",
                table: "CompanySubscriptions");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubscriptions_CompanyId",
                table: "CompanySubscriptions",
                column: "CompanyId",
                unique: true);
        }
    }
}
