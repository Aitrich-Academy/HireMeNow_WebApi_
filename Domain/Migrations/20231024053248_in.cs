using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class @in : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUser_JobProviderCompany",
                table: "CompanyUser");

            migrationBuilder.AlterColumn<Guid>(
                name: "Company",
                table: "CompanyUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SavedJob",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Job = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SavedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateSaved = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedJob_JobPost_Job",
                        column: x => x.Job,
                        principalTable: "JobPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedJob_JobSeekers_SavedBy",
                        column: x => x.SavedBy,
                        principalTable: "JobSeekers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedJob_Job",
                table: "SavedJob",
                column: "Job");

            migrationBuilder.CreateIndex(
                name: "IX_SavedJob_SavedBy",
                table: "SavedJob",
                column: "SavedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUser_JobProviderCompany",
                table: "CompanyUser",
                column: "Company",
                principalTable: "JobProviderCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUser_JobProviderCompany",
                table: "CompanyUser");

            migrationBuilder.DropTable(
                name: "SavedJob");

            migrationBuilder.AlterColumn<Guid>(
                name: "Company",
                table: "CompanyUser",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUser_JobProviderCompany",
                table: "CompanyUser",
                column: "Company",
                principalTable: "JobProviderCompany",
                principalColumn: "Id");
        }
    }
}
