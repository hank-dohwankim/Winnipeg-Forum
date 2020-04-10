using Microsoft.EntityFrameworkCore.Migrations;

namespace WinnipegForum.Data.Migrations
{
    public partial class forummodelchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Forums_FroumId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_FroumId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FroumId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "ForumId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ForumId",
                table: "Posts",
                column: "ForumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Forums_ForumId",
                table: "Posts",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Forums_ForumId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ForumId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ForumId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "FroumId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_FroumId",
                table: "Posts",
                column: "FroumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Forums_FroumId",
                table: "Posts",
                column: "FroumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
