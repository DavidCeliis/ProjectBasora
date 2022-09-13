using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBasora.Data.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedS",
                table: "Searchings");

            migrationBuilder.RenameColumn(
                name: "SuccesedS",
                table: "Searchings",
                newName: "Result");

            migrationBuilder.AddColumn<bool>(
                name: "Find",
                table: "Searchings",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bb81e854-732d-4aa6-9479-cd5e6921143a", "5d7ee4d6-aefa-4a0a-8fd9-5fa50bdc22c4" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2022, 9, 13, 11, 10, 2, 662, DateTimeKind.Local).AddTicks(793));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Find",
                table: "Searchings");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Searchings",
                newName: "SuccesedS");

            migrationBuilder.AddColumn<string>(
                name: "FailedS",
                table: "Searchings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7fa0b02b-91ba-49b4-9f61-3897724a47e9", "fbe33da1-7a96-4494-a844-b25d45319470" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2022, 9, 12, 11, 51, 43, 753, DateTimeKind.Local).AddTicks(9425));
        }
    }
}
