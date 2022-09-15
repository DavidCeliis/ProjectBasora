using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBasora.Data.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAndBorrowFinal",
                columns: table => new
                {
                    UserAndBorrowFinalId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAndBorrowFinal", x => new { x.RenterId, x.BookId, x.UserId, x.UserAndBorrowFinalId });
                    table.ForeignKey(
                        name: "FK_UserAndBorrowFinal_AspNetUsers_RenterId",
                        column: x => x.RenterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAndBorrowFinal_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAndBorrowFinal_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAndBorrowFinal_BookId",
                table: "UserAndBorrowFinal",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAndBorrowFinal_UserId",
                table: "UserAndBorrowFinal",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAndBorrowFinal");
        }
    }
}
