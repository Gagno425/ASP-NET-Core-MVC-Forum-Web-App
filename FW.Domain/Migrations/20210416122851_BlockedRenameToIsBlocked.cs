using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumWebAPPDomain.Migrations
{
    public partial class BlockedRenameToIsBlocked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Blocked",
                table: "AspNetUsers",
                newName: "IsBlocked");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBlocked",
                table: "AspNetUsers",
                newName: "Blocked");
        }
    }
}
