using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiHealthCare.Migrations
{
    public partial class fifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Roles_RolesRoleId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_RolesRoleId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "RolesRoleId",
                table: "Staffs");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Staffs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_RoleId",
                table: "Staffs",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Roles_RoleId",
                table: "Staffs",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Roles_RoleId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_RoleId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Staffs");

            migrationBuilder.AddColumn<int>(
                name: "RolesRoleId",
                table: "Staffs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_RolesRoleId",
                table: "Staffs",
                column: "RolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Roles_RolesRoleId",
                table: "Staffs",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
