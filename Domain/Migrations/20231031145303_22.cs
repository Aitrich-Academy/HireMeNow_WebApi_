using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class _22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Interviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_CompanyId",
                table: "Interviews",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_JobProviderCompany_CompanyId",
                table: "Interviews",
                column: "CompanyId",
                principalTable: "JobProviderCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_JobProviderCompany_CompanyId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_CompanyId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Interviews");
        }
    }
}
