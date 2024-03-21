using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tribute_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TributeCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TributeCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(30)", nullable: false),
                    Password = table.Column<string>(type: "varchar(15)", nullable: false),
                    Email = table.Column<string>(type: "varchar(40)", nullable: false),
                    Mobile = table.Column<long>(type: "BIGINT", nullable: false),
                    Role = table.Column<string>(type: "varchar(10)", nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Tributes",
                columns: table => new
                {
                    TributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(150)", nullable: false),
                    Abstract = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "varchar(800)", nullable: false),
                    RefferenceLink = table.Column<string>(type: "varchar(100)", nullable: true),
                    Approval = table.Column<string>(type: "varchar(10)", nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tributes", x => x.TributeId);
                    table.ForeignKey(
                        name: "FK_Tributes_TributeCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TributeCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tributes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Approvals",
                columns: table => new
                {
                    ApprovalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfApproval = table.Column<DateTime>(type: "datetime", nullable: false),
                    TributeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvals", x => x.ApprovalId);
                    table.ForeignKey(
                        name: "FK_Approvals_Tributes_TributeId",
                        column: x => x.TributeId,
                        principalTable: "Tributes",
                        principalColumn: "TributeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Approvals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "varchar(500)", nullable: true),
                    TributeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_Tributes_TributeId",
                        column: x => x.TributeId,
                        principalTable: "Tributes",
                        principalColumn: "TributeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TributeLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfModification = table.Column<DateTime>(type: "datetime", nullable: false),
                    TributeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TributeLogs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_TributeLogs_Tributes_TributeId",
                        column: x => x.TributeId,
                        principalTable: "Tributes",
                        principalColumn: "TributeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TributeLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_TributeId",
                table: "Approvals",
                column: "TributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_UserId",
                table: "Approvals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_TributeId",
                table: "Ratings",
                column: "TributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TributeLogs_TributeId",
                table: "TributeLogs",
                column: "TributeId");

            migrationBuilder.CreateIndex(
                name: "IX_TributeLogs_UserId",
                table: "TributeLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tributes_CategoryId",
                table: "Tributes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tributes_UserId",
                table: "Tributes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approvals");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "TributeLogs");

            migrationBuilder.DropTable(
                name: "Tributes");

            migrationBuilder.DropTable(
                name: "TributeCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
