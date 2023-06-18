using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ConvertstoredrobloxIdtoulong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LoggingEntry",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Keys",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DepartmentDiscordConfig",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DepartmentDiscord",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DepartmentConfig",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Department",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUserClaims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoleClaims",
                newName: "Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "RobloxId",
                table: "User",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoggingEntry",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Keys",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DepartmentDiscordConfig",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DepartmentDiscord",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DepartmentConfig",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Department",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUsers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUserClaims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetRoles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetRoleClaims",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "RobloxId",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)");
        }
    }
}
