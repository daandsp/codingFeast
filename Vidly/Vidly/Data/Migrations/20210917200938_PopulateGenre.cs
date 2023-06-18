using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Data.Migrations
{
    public partial class PopulateGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Action" },
                    { "2", "Adventure" },
                    { "3", "Drama" },
                    { "4", "Detective" },
                    { "5", "Family" },
                    { "6", "Fantasy" },
                    { "7", "Gangster" },
                    { "8", "Historical Drama" },
                    { "9", "Horror" },
                    { "10", "Comedy" },
                    { "11", "Crime" },
                    { "12", "Musical" },
                    { "13", "Mystery" },
                    { "14", "War" },
                    { "15", "Psychological Thriller" },
                    { "16", "Political Thriller" },
                    { "17", "Xmas" },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
