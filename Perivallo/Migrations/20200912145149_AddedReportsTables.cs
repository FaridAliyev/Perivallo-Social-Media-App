using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Perivallo.Migrations
{
    public partial class AddedReportsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReportFromId = table.Column<string>(nullable: true),
                    CommentId = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentReports_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentReports_AspNetUsers_ReportFromId",
                        column: x => x.ReportFromId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReportFromId = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostReports_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReports_AspNetUsers_ReportFromId",
                        column: x => x.ReportFromId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReportFromId = table.Column<string>(nullable: true),
                    ReportToId = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReports_AspNetUsers_ReportFromId",
                        column: x => x.ReportFromId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserReports_AspNetUsers_ReportToId",
                        column: x => x.ReportToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentReports_CommentId",
                table: "CommentReports",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReports_ReportFromId",
                table: "CommentReports",
                column: "ReportFromId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReports_PostId",
                table: "PostReports",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReports_ReportFromId",
                table: "PostReports",
                column: "ReportFromId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReports_ReportFromId",
                table: "UserReports",
                column: "ReportFromId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReports_ReportToId",
                table: "UserReports",
                column: "ReportToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentReports");

            migrationBuilder.DropTable(
                name: "PostReports");

            migrationBuilder.DropTable(
                name: "UserReports");
        }
    }
}
