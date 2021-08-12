using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class MessageEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    SenderColUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderCollegeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderHsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderColUserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    RecipientColUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientCollegeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientHsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientColUserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRead = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MessageSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecipientDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_ColUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "ColUsers",
                        principalColumn: "ColUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_ColUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "ColUsers",
                        principalColumn: "ColUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
