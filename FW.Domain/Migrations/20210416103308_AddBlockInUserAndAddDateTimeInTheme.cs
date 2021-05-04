using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumWebAPPDomain.Migrations
{
    public partial class AddBlockInUserAndAddDateTimeInTheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Themes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Blocked",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Themes");

            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "AspNetUsers");
        }
    }
}
