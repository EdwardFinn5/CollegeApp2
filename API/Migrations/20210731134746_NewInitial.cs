using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class NewInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColUsers",
                columns: table => new
                {
                    ColUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HsLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HsGradDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GradDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProposedMajor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraCurricular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DreamJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeNum = table.Column<int>(type: "int", nullable: false),
                    CollegeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeNickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeEnrollment = table.Column<int>(type: "int", nullable: false),
                    Tuition = table.Column<int>(type: "int", nullable: false),
                    RoomAndBoard = table.Column<int>(type: "int", nullable: false),
                    AverageAid = table.Column<int>(type: "int", nullable: false),
                    NetPay = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ColUserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CollegeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeZip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeVirtual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeYearFounded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegePresident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
