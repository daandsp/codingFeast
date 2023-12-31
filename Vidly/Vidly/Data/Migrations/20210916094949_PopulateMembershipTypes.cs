﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Vidly.Data.Migrations
{
    public partial class PopulateMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MembershipTypes",
                columns: new[] { "Id", "SignUpFee", "DurationInMonths", "DiscountRate" },
                values: new object[,]
                {
                    { "1", "0", "0", "0" },
                    { "2", "30", "1", "10" },
                    { "3", "90", "3", "15" },
                    { "4", "300", "12", "20" },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
