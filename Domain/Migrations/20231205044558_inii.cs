using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class inii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekerProfile_Resume_ResumeId",
                table: "JobSeekerProfile");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_SeekerId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "SeekerId",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "JobLocation",
                table: "JobPost",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "Industry",
                table: "JobPost",
                newName: "IndustryId");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "JobPost",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "JobPost",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPost_JobLocation",
                table: "JobPost",
                newName: "IX_JobPost_LocationId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResumeId",
                table: "JobSeekerProfile",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "JobApplications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCategory",
                table: "JobCategory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobPost_CategoryId",
                table: "JobPost",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPost_CompanyId",
                table: "JobPost",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPost_IndustryId",
                table: "JobPost",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_Applicant",
                table: "JobApplications",
                column: "Applicant");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPost_Industry_IndustryId",
                table: "JobPost",
                column: "IndustryId",
                principalTable: "Industry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPost_JobCategory_CategoryId",
                table: "JobPost",
                column: "CategoryId",
                principalTable: "JobCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPost_JobProviderCompany_CompanyId",
                table: "JobPost",
                column: "CompanyId",
                principalTable: "JobProviderCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekerProfile_Resume_ResumeId",
                table: "JobSeekerProfile",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPost_Industry_IndustryId",
                table: "JobPost");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPost_JobCategory_CategoryId",
                table: "JobPost");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPost_JobProviderCompany_CompanyId",
                table: "JobPost");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekerProfile_Resume_ResumeId",
                table: "JobSeekerProfile");

            migrationBuilder.DropIndex(
                name: "IX_JobPost_CategoryId",
                table: "JobPost");

            migrationBuilder.DropIndex(
                name: "IX_JobPost_CompanyId",
                table: "JobPost");

            migrationBuilder.DropIndex(
                name: "IX_JobPost_IndustryId",
                table: "JobPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCategory",
                table: "JobCategory");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_Applicant",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "JobPost",
                newName: "JobLocation");

            migrationBuilder.RenameColumn(
                name: "IndustryId",
                table: "JobPost",
                newName: "Industry");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "JobPost",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "JobPost",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_JobPost_LocationId",
                table: "JobPost",
                newName: "IX_JobPost_JobLocation");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResumeId",
                table: "JobSeekerProfile",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "SeekerId",
                table: "JobApplications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_SeekerId",
                table: "JobApplications",
                column: "SeekerId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekerProfile_Resume_ResumeId",
                table: "JobSeekerProfile",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
