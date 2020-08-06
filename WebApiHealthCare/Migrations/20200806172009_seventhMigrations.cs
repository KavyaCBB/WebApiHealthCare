using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiHealthCare.Migrations
{
    public partial class seventhMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_TestResults_TestResultsTestId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_TestResultsTestId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "TestResultsTestId",
                table: "Staffs");

            migrationBuilder.AddColumn<int>(
                name: "Loginid",
                table: "TestResults",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loginid",
                table: "Staffs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_Loginid",
                table: "TestResults",
                column: "Loginid");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_Loginid",
                table: "Staffs",
                column: "Loginid");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Login_Loginid",
                table: "Staffs",
                column: "Loginid",
                principalTable: "Login",
                principalColumn: "Loginid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Login_Loginid",
                table: "TestResults",
                column: "Loginid",
                principalTable: "Login",
                principalColumn: "Loginid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Login_Loginid",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Login_Loginid",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_Loginid",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_Loginid",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Loginid",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "Loginid",
                table: "Staffs");

            migrationBuilder.AddColumn<int>(
                name: "TestResultsTestId",
                table: "Staffs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_TestResultsTestId",
                table: "Staffs",
                column: "TestResultsTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_TestResults_TestResultsTestId",
                table: "Staffs",
                column: "TestResultsTestId",
                principalTable: "TestResults",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
