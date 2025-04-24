using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaaSFileManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    ActivationToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanySubscriptionPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileLimitPerMonth = table.Column<int>(type: "int", nullable: false),
                    UserLimit = table.Column<int>(type: "int", nullable: true),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AllowExtraFiles = table.Column<bool>(type: "bit", nullable: false),
                    AllowExtraUsers = table.Column<bool>(type: "bit", nullable: false),
                    PricePerExtraUser = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PricePerExtraFile = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRestricted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyFiles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanySubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionPlanId = table.Column<int>(type: "int", nullable: false),
                    SubscribedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CanceledAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanySubscriptions_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanySubscriptions_SubscriptionPlans_SubscriptionPlanId",
                        column: x => x.SubscriptionPlanId,
                        principalTable: "SubscriptionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileAccesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileAccesses_CompanyFiles_CompanyFileId",
                        column: x => x.CompanyFileId,
                        principalTable: "CompanyFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FileAccesses_CompanyFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "CompanyFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileAccesses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillingRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanySubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BillingPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalEmployeesThisMonth = table.Column<int>(type: "int", nullable: false),
                    TotalFilesUploadedThisMonth = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingRecords_CompanySubscriptions_CompanySubscriptionId",
                        column: x => x.CompanySubscriptionId,
                        principalTable: "CompanySubscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingRecords_CompanySubscriptionId",
                table: "BillingRecords",
                column: "CompanySubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFiles_CompanyId",
                table: "CompanyFiles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubscriptions_CompanyId",
                table: "CompanySubscriptions",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubscriptions_SubscriptionPlanId",
                table: "CompanySubscriptions",
                column: "SubscriptionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAccesses_CompanyFileId",
                table: "FileAccesses",
                column: "CompanyFileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAccesses_EmployeeId",
                table: "FileAccesses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAccesses_FileId",
                table: "FileAccesses",
                column: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingRecords");

            migrationBuilder.DropTable(
                name: "FileAccesses");

            migrationBuilder.DropTable(
                name: "CompanySubscriptions");

            migrationBuilder.DropTable(
                name: "CompanyFiles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
