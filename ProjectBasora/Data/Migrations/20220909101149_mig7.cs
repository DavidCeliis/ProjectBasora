using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBasora.Data.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksAndAuthors_AspNetUsers_UserId",
                table: "BooksAndAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_Thumbnail_Books_BookId",
                table: "Thumbnail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Thumbnail",
                table: "Thumbnail");

            migrationBuilder.RenameTable(
                name: "Thumbnail",
                newName: "Thumbnails");

            migrationBuilder.AddColumn<int>(
                name: "Book",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Book",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BooksAndAuthors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Author",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Categories",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Languages",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fileName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Book",
                table: "Authors",
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c7f009a7-2433-4ec9-9a9c-1ff5b37bd241", "81d8f642-bf3c-4491-8daa-37b59f1842b0" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2022, 9, 9, 12, 11, 48, 425, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Spain" });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Book",
                table: "Languages",
                column: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Book",
                table: "Categories",
                column: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Author",
                table: "Books",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Categories",
                table: "Books",
                column: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Languages",
                table: "Books",
                column: "Languages");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Book",
                table: "Authors",
                column: "Book");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_Book",
                table: "Authors",
                column: "Book",
                principalTable: "Books",
                principalColumn: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_Author",
                table: "Books",
                column: "Author",
                principalTable: "Authors",
                principalColumn: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_Categories",
                table: "Books",
                column: "Categories",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Languages_Languages",
                table: "Books",
                column: "Languages",
                principalTable: "Languages",
                principalColumn: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAndAuthors_AspNetUsers_UserId",
                table: "BooksAndAuthors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Books_Book",
                table: "Categories",
                column: "Book",
                principalTable: "Books",
                principalColumn: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Books_Book",
                table: "Languages",
                column: "Book",
                principalTable: "Books",
                principalColumn: "BookId");

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
                name: "FK_Authors_Books_Book",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_Author",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_Categories",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Languages_Languages",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksAndAuthors_AspNetUsers_UserId",
                table: "BooksAndAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Books_Book",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Books_Book",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Thumbnails_Books_BookId",
                table: "Thumbnails");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Languages_Book",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Book",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_Author",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Categories",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Languages",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_Book",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Thumbnails",
                table: "Thumbnails");

            migrationBuilder.DropColumn(
                name: "Book",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Book",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "fileName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Book",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Thumbnails",
                newName: "Thumbnail");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BooksAndAuthors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thumbnail",
                table: "Thumbnail",
                columns: new[] { "BookId", "Type" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAndAuthors_AspNetUsers_UserId",
                table: "BooksAndAuthors",
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
        }
    }
}
