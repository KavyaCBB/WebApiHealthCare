using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiHealthCare.Migrations
{
    public partial class ninthMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestResults");

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(nullable: true),
                    MaxRange = table.Column<float>(nullable: false),
                    MinRange = table.Column<float>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "LabTestResults",
                columns: table => new
                {
                    TestResultsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientRange = table.Column<float>(nullable: false),
                    Loginid = table.Column<int>(nullable: true),
                    StaffID = table.Column<int>(nullable: true),
                    TestId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTestResults", x => x.TestResultsId);
                    table.ForeignKey(
                        name: "FK_LabTestResults_Login_Loginid",
                        column: x => x.Loginid,
                        principalTable: "Login",
                        principalColumn: "Loginid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabTestResults_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabTestResults_LabTests_TestId",
                        column: x => x.TestId,
                        principalTable: "LabTests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabTestResults_Loginid",
                table: "LabTestResults",
                column: "Loginid");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestResults_StaffID",
                table: "LabTestResults",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestResults_TestId",
                table: "LabTestResults",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabTestResults");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.CreateTable(
                name: "TestResults",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loginid = table.Column<int>(type: "int", nullable: true),
                    MaxRange = table.Column<float>(type: "real", nullable: false),
                    MinRange = table.Column<float>(type: "real", nullable: false),
                    PatientRange = table.Column<float>(type: "real", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_TestResults_Login_Loginid",
                        column: x => x.Loginid,
                        principalTable: "Login",
                        principalColumn: "Loginid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_Loginid",
                table: "TestResults",
                column: "Loginid");
        }
    }
}
