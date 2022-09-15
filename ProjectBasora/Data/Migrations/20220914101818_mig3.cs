using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBasora.Data.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksAndAuthors_AspNetUsers_UserId",
                table: "BooksAndAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksAndAuthors_Authors_AuthorId",
                table: "BooksAndAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksAndAuthors_Books_BookId",
                table: "BooksAndAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksAndCategories_AspNetUsers_UserId",
                table: "BooksAndCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Thumbnail_Books_BookId",
                table: "Thumbnail");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Thumbnail",
                table: "Thumbnail");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "UserReview_bookCondition");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "UserReview_book");

            migrationBuilder.DropColumn(
                name: "FailedS",
                table: "Searchings");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Borrowing");

            migrationBuilder.RenameTable(
                name: "Thumbnail",
                newName: "Thumbnails");

            migrationBuilder.RenameColumn(
                name: "SuccesedS",
                table: "Searchings",
                newName: "Result");

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

            migrationBuilder.AddColumn<bool>(
                name: "Find",
                table: "Searchings",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BooksAndCategories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BooksAndAuthors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BookBinding",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fileName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Vertification",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Limit",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IDtype",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "IDnumber",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AmmountOfActions",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmmountOfInTime",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmmountOfdelayed",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thumbnails",
                table: "Thumbnails",
                columns: new[] { "BookId", "Type" });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAndBorrows",
                columns: table => new
                {
                    UserAndBorrowId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAndBorrows", x => new { x.RenterId, x.BookId, x.UserId, x.UserAndBorrowId });
                    table.ForeignKey(
                        name: "FK_UserAndBorrows_AspNetUsers_RenterId",
                        column: x => x.RenterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAndBorrows_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAndBorrows_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                });

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

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName", "UserId" },
                values: new object[] { 6, "George Orwell", null });

            migrationBuilder.CreateIndex(
                name: "IX_UserAndBorrows_BookId",
                table: "UserAndBorrows",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAndBorrows_UserId",
                table: "UserAndBorrows",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAndAuthors_AspNetUsers_UserId",
                table: "BooksAndAuthors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAndAuthors_Authors_AuthorId",
                table: "BooksAndAuthors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAndAuthors_Books_BookId",
                table: "BooksAndAuthors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAndCategories_AspNetUsers_UserId",
                table: "BooksAndCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Thumbnails_Books_BookId",
                table: "Thumbnails",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksAndAuthors_AspNetUsers_UserId",
                table: "BooksAndAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksAndAuthors_Authors_AuthorId",
                table: "BooksAndAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksAndAuthors_Books_BookId",
                table: "BooksAndAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksAndCategories_AspNetUsers_UserId",
                table: "BooksAndCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Thumbnails_Books_BookId",
                table: "Thumbnails");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "UserAndBorrows");

            migrationBuilder.DropTable(
                name: "UserReview_bookConditionRelation");

            migrationBuilder.DropTable(
                name: "UserReview_bookRelation");

            migrationBuilder.DropTable(
                name: "UserReview_userRelation");

            migrationBuilder.DropTable(
                name: "UserReview_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Thumbnails",
                table: "Thumbnails");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Find",
                table: "Searchings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "fileName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AmmountOfActions",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AmmountOfInTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AmmountOfdelayed",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Thumbnails",
                newName: "Thumbnail");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Searchings",
                newName: "SuccesedS");

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

            migrationBuilder.AddColumn<string>(
                name: "FailedS",
                table: "Searchings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Borrowing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BooksAndCategories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BooksAndAuthors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BookBinding",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Vertification",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Limit",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IDtype",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IDnumber",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thumbnail",
                table: "Thumbnail",
                columns: new[] { "BookId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_bookCondition_BookId",
                table: "UserReview_bookCondition",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_book_BookId",
                table: "UserReview_book",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAndAuthors_AspNetUsers_UserId",
                table: "BooksAndAuthors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAndAuthors_Authors_AuthorId",
                table: "BooksAndAuthors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAndAuthors_Books_BookId",
                table: "BooksAndAuthors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAndCategories_AspNetUsers_UserId",
                table: "BooksAndCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Thumbnail_Books_BookId",
                table: "Thumbnail",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

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
