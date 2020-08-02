using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiHealthCare.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Login",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Login",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialLoginType",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Login",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "SocialLoginType",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Login");
        }
    }
}
