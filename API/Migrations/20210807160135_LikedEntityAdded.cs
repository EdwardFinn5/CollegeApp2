using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class LikedEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    SourceColUserId = table.Column<int>(type: "int", nullable: false),
                    LikedColUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.SourceColUserId, x.LikedColUserId });
                    table.ForeignKey(
                        name: "FK_Likes_ColUsers_LikedColUserId",
                        column: x => x.LikedColUserId,
                        principalTable: "ColUsers",
                        principalColumn: "ColUserId");
                    table.ForeignKey(
                        name: "FK_Likes_ColUsers_SourceColUserId",
                        column: x => x.SourceColUserId,
                        principalTable: "ColUsers",
                        principalColumn: "ColUserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikedColUserId",
                table: "Likes",
                column: "LikedColUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");
        }
    }
}
