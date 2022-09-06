using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBasora.Data.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f5acba12-af72-4ced-b761-800e3df0d116", "9ede5a45-47b6-4013-b60d-16678abb0039" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2022, 9, 6, 10, 57, 46, 207, DateTimeKind.Local).AddTicks(8922));

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Book",
                table: "Languages",
                column: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Book",
                table: "Categories",
                column: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Categories",
                table: "Books",
                column: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Languages",
                table: "Books",
                column: "Languages");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_Categories",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Languages_Languages",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Books_Book",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Books_Book",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_Book",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Book",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_Categories",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Languages",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Book",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Book",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "511c81fc-7005-4a12-96a4-f557ad189268", "4611fb4d-01bd-4ebf-85a8-a980c0d39c3a" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2022, 9, 6, 10, 13, 28, 456, DateTimeKind.Local).AddTicks(3071));
        }
    }
}
