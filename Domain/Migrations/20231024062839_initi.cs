using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class initi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedJob_JobPost_Job",
                table: "SavedJob");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJob_JobSeekers_SavedBy",
                table: "SavedJob");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedJob",
                table: "SavedJob");

            migrationBuilder.RenameTable(
                name: "SavedJob",
                newName: "SavedJobs");

            migrationBuilder.RenameIndex(
                name: "IX_SavedJob_SavedBy",
                table: "SavedJobs",
                newName: "IX_SavedJobs_SavedBy");

            migrationBuilder.RenameIndex(
                name: "IX_SavedJob_Job",
                table: "SavedJobs",
                newName: "IX_SavedJobs_Job");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedJobs",
                table: "SavedJobs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobs_JobPost_Job",
                table: "SavedJobs",
                column: "Job",
                principalTable: "JobPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobs_JobSeekers_SavedBy",
                table: "SavedJobs",
                column: "SavedBy",
                principalTable: "JobSeekers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobs_JobPost_Job",
                table: "SavedJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobs_JobSeekers_SavedBy",
                table: "SavedJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedJobs",
                table: "SavedJobs");

            migrationBuilder.RenameTable(
                name: "SavedJobs",
                newName: "SavedJob");

            migrationBuilder.RenameIndex(
                name: "IX_SavedJobs_SavedBy",
                table: "SavedJob",
                newName: "IX_SavedJob_SavedBy");

            migrationBuilder.RenameIndex(
                name: "IX_SavedJobs_Job",
                table: "SavedJob",
                newName: "IX_SavedJob_Job");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedJob",
                table: "SavedJob",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJob_JobPost_Job",
                table: "SavedJob",
                column: "Job",
                principalTable: "JobPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJob_JobSeekers_SavedBy",
                table: "SavedJob",
                column: "SavedBy",
                principalTable: "JobSeekers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
