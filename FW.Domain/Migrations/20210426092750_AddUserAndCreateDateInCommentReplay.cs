using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumWebAPPDomain.Migrations
{
    public partial class AddUserAndCreateDateInCommentReplay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "CommentReplays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CommentReplays",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentReplays_UserId",
                table: "CommentReplays",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReplays_AspNetUsers_UserId",
                table: "CommentReplays",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentReplays_AspNetUsers_UserId",
                table: "CommentReplays");

            migrationBuilder.DropIndex(
                name: "IX_CommentReplays_UserId",
                table: "CommentReplays");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "CommentReplays");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CommentReplays");
        }
    }
}
