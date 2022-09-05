using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBasora.Data.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "BooksAndAuthors",
                columns: new[] { "AuthorId", "BookId", "UserId" },
                values: new object[] { 6, 1, "owner1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BooksAndAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "815a5785-546a-4d80-ac52-b2207fddfaf2", "07abb045-4722-4043-8e19-63e123ed90ad" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2022, 9, 5, 12, 27, 13, 577, DateTimeKind.Local).AddTicks(532));
        }
    }
}
