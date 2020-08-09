using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiHealthCare.Migrations
{
    public partial class ninthMigrationss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabTestResults_Login_Loginid",
                table: "LabTestResults");

            migrationBuilder.DropIndex(
                name: "IX_LabTestResults_Loginid",
                table: "LabTestResults");

            migrationBuilder.DropColumn(
                name: "Loginid",
                table: "LabTestResults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Loginid",
                table: "LabTestResults",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabTestResults_Loginid",
                table: "LabTestResults",
                column: "Loginid");

            migrationBuilder.AddForeignKey(
                name: "FK_LabTestResults_Login_Loginid",
                table: "LabTestResults",
                column: "Loginid",
                principalTable: "Login",
                principalColumn: "Loginid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
