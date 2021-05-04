using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumWebAPPDomain.Migrations
{
    public partial class AddUserInPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_userId",
                table: "Posts",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_userId",
                table: "Posts",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_userId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_userId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Posts");
        }
    }
}
