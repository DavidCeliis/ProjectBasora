using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBasora.Data.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReview_book_Books_BookId",
                table: "UserReview_book");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReview_bookCondition_Books_BookId",
                table: "UserReview_bookCondition");

            migrationBuilder.DropIndex(
                name: "IX_UserReview_bookCondition_BookId",
                table: "UserReview_bookCondition");

            migrationBuilder.DropIndex(
                name: "IX_UserReview_book_BookId",
                table: "UserReview_book");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "UserReview_bookCondition");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "UserReview_book");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "UserReview_bookCondition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "UserReview_book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AmmountOfActions",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmmountOfInTime",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmmountOfdelayed",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserReview_bookConditionRelation",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    RatedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserReview_bookConditionId = table.Column<int>(type: "int", nullable: false),
                    URBCRId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReview_bookConditionRelation", x => new { x.RatedId, x.BookId, x.UserId, x.UserReview_bookConditionId });
                    table.ForeignKey(
                        name: "FK_UserReview_bookConditionRelation_AspNetUsers_RatedId",
                        column: x => x.RatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserReview_bookConditionRelation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserReview_bookConditionRelation_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_UserReview_bookConditionRelation_UserReview_bookCondition_UserReview_bookConditionId",
                        column: x => x.UserReview_bookConditionId,
                        principalTable: "UserReview_bookCondition",
                        principalColumn: "RConditionId");
                });

            migrationBuilder.CreateTable(
                name: "UserReview_bookRelation",
                columns: table => new
                {
                    BookISBN = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserReview_bookId = table.Column<int>(type: "int", nullable: false),
                    URBRId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReview_bookRelation", x => new { x.BookISBN, x.UserId, x.UserReview_bookId });
                    table.ForeignKey(
                        name: "FK_UserReview_bookRelation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserReview_bookRelation_Books_BookISBN",
                        column: x => x.BookISBN,
                        principalTable: "Books",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_UserReview_bookRelation_UserReview_book_UserReview_bookId",
                        column: x => x.UserReview_bookId,
                        principalTable: "UserReview_book",
                        principalColumn: "RBookId");
                });

            migrationBuilder.CreateTable(
                name: "UserReview_user",
                columns: table => new
                {
                    RUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReview_user", x => x.RUserId);
                });

            migrationBuilder.CreateTable(
                name: "UserReview_userRelation",
                columns: table => new
                {
                    RatedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserReview_userId = table.Column<int>(type: "int", nullable: false),
                    URURid = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReview_userRelation", x => new { x.RatedId, x.UserId, x.UserReview_userId });
                    table.ForeignKey(
                        name: "FK_UserReview_userRelation_AspNetUsers_RatedId",
                        column: x => x.RatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserReview_userRelation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserReview_userRelation_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_UserReview_userRelation_UserReview_user_UserReview_userId",
                        column: x => x.UserReview_userId,
                        principalTable: "UserReview_user",
                        principalColumn: "RUserId");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f8f8890b-bc31-479f-ba1e-8ab650f15569", "339009db-fac1-440c-9b62-e60f576a12ab" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2022, 9, 5, 14, 15, 1, 275, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_bookConditionRelation_BookId",
                table: "UserReview_bookConditionRelation",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_bookConditionRelation_UserId",
                table: "UserReview_bookConditionRelation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_bookConditionRelation_UserReview_bookConditionId",
                table: "UserReview_bookConditionRelation",
                column: "UserReview_bookConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_bookRelation_UserId",
                table: "UserReview_bookRelation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_bookRelation_UserReview_bookId",
                table: "UserReview_bookRelation",
                column: "UserReview_bookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_userRelation_BookId",
                table: "UserReview_userRelation",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_userRelation_UserId",
                table: "UserReview_userRelation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_userRelation_UserReview_userId",
                table: "UserReview_userRelation",
                column: "UserReview_userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserReview_bookConditionRelation");

            migrationBuilder.DropTable(
                name: "UserReview_bookRelation");

            migrationBuilder.DropTable(
                name: "UserReview_userRelation");

            migrationBuilder.DropTable(
                name: "UserReview_user");

            migrationBuilder.DropColumn(
                name: "AmmountOfActions",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AmmountOfInTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AmmountOfdelayed",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "UserReview_bookCondition",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "UserReview_bookCondition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "UserReview_book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "UserReview_book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c44bd4fe-a54a-41ed-b010-ca287c4ab01e", "13e00b9b-dfc2-4e8c-9632-4bfe09f8b5d6" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2022, 9, 5, 12, 31, 52, 539, DateTimeKind.Local).AddTicks(2917));

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_bookCondition_BookId",
                table: "UserReview_bookCondition",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_book_BookId",
                table: "UserReview_book",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReview_book_Books_BookId",
                table: "UserReview_book",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReview_bookCondition_Books_BookId",
                table: "UserReview_bookCondition",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
