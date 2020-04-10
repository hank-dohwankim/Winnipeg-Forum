using Microsoft.EntityFrameworkCore.Migrations;

namespace WinnipegForum.Data.Migrations
{
    public partial class updateapplicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId1",
                table: "PostReplies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostReplies_PostId1",
                table: "PostReplies",
                column: "PostId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReplies_Posts_PostId1",
                table: "PostReplies",
                column: "PostId1",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReplies_Posts_PostId1",
                table: "PostReplies");

            migrationBuilder.DropIndex(
                name: "IX_PostReplies_PostId1",
                table: "PostReplies");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "PostReplies");
        }
    }
}
