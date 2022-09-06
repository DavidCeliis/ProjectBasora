using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBasora.Data.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Author",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Book",
                table: "Authors",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Books_Author",
                table: "Books",
                column: "Author");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_Book",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_Author",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Author",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_Book",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Book",
                table: "Authors");

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
        }
    }
}
