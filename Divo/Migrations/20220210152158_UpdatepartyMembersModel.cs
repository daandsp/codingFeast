using Microsoft.EntityFrameworkCore.Migrations;

namespace Divo.Migrations
{
    public partial class UpdatepartyMembersModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PartyMembers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PartyMembers");
        }
    }
}
