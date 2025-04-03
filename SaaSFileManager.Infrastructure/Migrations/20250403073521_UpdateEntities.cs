using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaaSFileManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_SubscriptionPlans_SubscriptionPlanId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "IsPublic",
                table: "Files",
                newName: "IsRestricted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserLimit",
                table: "SubscriptionPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "SubscriptionPlans",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "ExtraFileCost",
                table: "SubscriptionPlans",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionPlanId",
                table: "Companies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_SubscriptionPlans_SubscriptionPlanId",
                table: "Companies",
                column: "SubscriptionPlanId",
                principalTable: "SubscriptionPlans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_SubscriptionPlans_SubscriptionPlanId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "IsRestricted",
                table: "Files",
                newName: "IsPublic");

            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "UserLimit",
                table: "SubscriptionPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "SubscriptionPlans",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ExtraFileCost",
                table: "SubscriptionPlans",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionPlanId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_SubscriptionPlans_SubscriptionPlanId",
                table: "Companies",
                column: "SubscriptionPlanId",
                principalTable: "SubscriptionPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
