using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddChannelSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentConfig");

            migrationBuilder.DropTable(
                name: "DepartmentDiscordConfig");

            migrationBuilder.RenameTable(
                name: "DepartmentDiscord",
                newName: "DepartmentGuild");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "DepartmentGuild",
                newName: "Permissions");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscordId",
                table: "User",
                type: "decimal(20,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "DepartmentGuild",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentDiscord_Department_DepartmentId",
                table: "DepartmentGuild");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentGuild_Department_DepartmentId",
                table: "DepartmentGuild",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.CreateTable(
                name: "DepartmentChannels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChannelId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DepartmentGuildId = table.Column<int>(type: "int", nullable: false),
                    Permissions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentChannels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentChannels_DepartmentGuild_DepartmentGuildId",
                        column: x => x.DepartmentGuildId,
                        principalTable: "DepartmentGuild",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentChannels_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentChannels_DepartmentGuildId",
                table: "DepartmentChannels",
                column: "DepartmentGuildId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentDiscord_DepartmentId",
                table: "DepartmentGuild",
                newName: "IX_DepartmentGuild_DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentChannels");

            migrationBuilder.RenameTable(
                name: "DepartmentGuild",
                newName: "DepartmentDiscord");

            migrationBuilder.RenameColumn(
                name: "Permissions",
                table: "DepartmentDiscord",
                newName: "Priority");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscordId",
                table: "User",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "DepartmentDiscord",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DepartmentConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AutomaticLogsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentConfig_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentDiscordConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentDiscordId = table.Column<int>(type: "int", nullable: false),
                    BotLogsChannelId = table.Column<decimal>(type: "decimal(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentDiscordConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentDiscordConfig_DepartmentDiscord_DepartmentDiscordId",
                        column: x => x.DepartmentDiscordId,
                        principalTable: "DepartmentDiscord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentGuild_Department_DepartmentId",
                table: "DepartmentDiscord");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentDiscord_Department_DepartmentId",
                table: "DepartmentDiscord",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentConfig_DepartmentId",
                table: "DepartmentConfig",
                column: "DepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDiscordConfig_DepartmentDiscordId",
                table: "DepartmentDiscordConfig",
                column: "DepartmentDiscordId",
                unique: true);

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentGuild_DepartmentId",
                table: "DepartmentDiscord",
                newName: "IX_DepartmentDiscord_DepartmentId");
        }
    }
}
