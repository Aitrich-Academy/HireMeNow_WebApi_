using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrations : Migration
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
                name: "FK_JobSeeker_SystemUser_Id",
                table: "JobSeeker");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropIndex(
                name: "IX_AuthUser_SystemUserId",
                table: "AuthUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSeeker",
                table: "JobSeeker");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "AuthUser");

            migrationBuilder.RenameTable(
                name: "JobSeeker",
                newName: "JobSeekers");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "AuthUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AuthUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AuthUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AuthUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AuthUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AuthUser",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AuthUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "JobSeekers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSeekers",
                table: "JobSeekers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SignUpRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUpRequests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignUpRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSeekers",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AuthUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AuthUser");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AuthUser");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AuthUser");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AuthUser");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AuthUser");

            migrationBuilder.RenameTable(
                name: "JobSeekers",
                newName: "JobSeeker");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "AuthUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SystemUserId",
                table: "AuthUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "JobSeeker",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSeeker",
                table: "JobSeeker",
                column: "Id");

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
                name: "IX_AuthUser_SystemUserId",
                table: "AuthUser",
                column: "SystemUserId");

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
                name: "FK_JobSeeker_SystemUser_Id",
                table: "JobSeeker",
                column: "Id",
                principalTable: "SystemUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
