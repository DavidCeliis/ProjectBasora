using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBasora.Data.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "IDnumber", "IDtype", "Limit", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserLastname", "UserName", "UserNick", "UserSurname", "UserType", "Vertification" },
                values: new object[] { "owner1", 0, "Madrid", "815a5785-546a-4d80-ac52-b2207fddfaf2", "davceli019@pslib.cz", false, 1, "", 10000, false, null, null, null, "", null, false, 23344, "07abb045-4722-4043-8e19-63e123ed90ad", "Spain", "Gen. Svob", false, "Celis", "davceli019@pslib.cz", "OWNERcelis", "David", "OWNER", true });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName", "UserId" },
                values: new object[] { 6, "George Orwell", null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookBinding", "Borrowed", "ContentType", "ISBN", "NumberPages", "Public", "Title", "UploadedAt", "UserId", "Weight" },
                values: new object[] { 1, "soft", false, null, "9780140862539", 224, true, "1984", new DateTime(2022, 9, 5, 12, 27, 13, 577, DateTimeKind.Local).AddTicks(532), "owner1", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1");

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
        }
    }
}
