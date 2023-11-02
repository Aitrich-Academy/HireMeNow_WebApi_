using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthUser_SystemUser_Id",
                table: "AuthUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthUser_SystemUser_SystemUserId",
                table: "AuthUser");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_SystemUser_Id",
                table: "JobSeekers");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_JobPost_JobPostId",
                table: "Skill");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropIndex(
                name: "IX_Skill_JobPostId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "JobPostId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "JobSeekerProfileId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "AuthUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "JobPostId",
                table: "Skill",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobSeekerProfileId",
                table: "Skill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SystemUserId",
                table: "AuthUser",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_JobPostId",
                table: "Skill",
                column: "JobPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthUser_SystemUser_Id",
                table: "AuthUser",
                column: "Id",
                principalTable: "SystemUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthUser_SystemUser_SystemUserId",
                table: "AuthUser",
                column: "SystemUserId",
                principalTable: "SystemUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_SystemUser_Id",
                table: "JobSeekers",
                column: "Id",
                principalTable: "SystemUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_JobPost_JobPostId",
                table: "Skill",
                column: "JobPostId",
                principalTable: "JobPost",
                principalColumn: "Id");
        }
    }
}
