using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiHealthCare.Migrations
{
    public partial class sixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestResultsTestId",
                table: "Staffs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TestResults",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(nullable: true),
                    MaxRange = table.Column<decimal>(nullable: false),
                    MinRange = table.Column<decimal>(nullable: false),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.TestId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_TestResults_TestResultsTestId",
                table: "Staffs");

            migrationBuilder.DropTable(
                name: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_TestResultsTestId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "TestResultsTestId",
                table: "Staffs");
        }
    }
}
