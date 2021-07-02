using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColUsers",
                columns: table => new
                {
                    ColUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColUsers", x => x.ColUserId);
                });

            migrationBuilder.CreateTable(
                name: "MajorCats",
                columns: table => new
                {
                    MajorCatId = table.Column<int>(type: "int", nullable: false),
                    MajorCatName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MajorCats", x => x.MajorCatId);
                });

            migrationBuilder.CreateTable(
                name: "ColPhotos",
                columns: table => new
                {
                    ColPhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HsStudentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMainCol = table.Column<bool>(type: "bit", nullable: false),
                    IsMainHs = table.Column<bool>(type: "bit", nullable: false),
                    IsMainAdmin = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColPhotos", x => x.ColPhotoId);
                    table.ForeignKey(
                        name: "FK_ColPhotos_ColUsers_ColUserId",
                        column: x => x.ColUserId,
                        principalTable: "ColUsers",
                        principalColumn: "ColUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactFeatures",
                columns: table => new
                {
                    FactId = table.Column<int>(type: "int", nullable: false),
                    FactBullet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactFeatures", x => x.FactId);
                    table.ForeignKey(
                        name: "FK_FactFeatures_ColUsers_CollegeNum",
                        column: x => x.CollegeNum,
                        principalTable: "ColUsers",
                        principalColumn: "ColUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    MajorId = table.Column<int>(type: "int", nullable: false),
                    MajorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MajorCatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.MajorId);
                    table.ForeignKey(
                        name: "FK_Majors_MajorCats_MajorCatId",
                        column: x => x.MajorCatId,
                        principalTable: "MajorCats",
                        principalColumn: "MajorCatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollegeMajors",
                columns: table => new
                {
                    CollegeNum = table.Column<int>(type: "int", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeMajors", x => new { x.CollegeNum, x.MajorId });
                    table.ForeignKey(
                        name: "FK_CollegeMajors_ColUsers_CollegeNum",
                        column: x => x.CollegeNum,
                        principalTable: "ColUsers",
                        principalColumn: "ColUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollegeMajors_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "MajorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollegeMajors_MajorId",
                table: "CollegeMajors",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_ColPhotos_ColUserId",
                table: "ColPhotos",
                column: "ColUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FactFeatures_CollegeNum",
                table: "FactFeatures",
                column: "CollegeNum");

            migrationBuilder.CreateIndex(
                name: "IX_Majors_MajorCatId",
                table: "Majors",
                column: "MajorCatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollegeMajors");

            migrationBuilder.DropTable(
                name: "ColPhotos");

            migrationBuilder.DropTable(
                name: "FactFeatures");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "ColUsers");

            migrationBuilder.DropTable(
                name: "MajorCats");
        }
    }
}
