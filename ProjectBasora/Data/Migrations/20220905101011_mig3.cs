using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBasora.Data.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAndBorrow",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BorrowingId = table.Column<int>(type: "int", nullable: false),
                    UBId = table.Column<int>(type: "int", nullable: false),
                    UserAndBorrowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAndBorrow", x => new { x.RenterId, x.BookId, x.UserId, x.BorrowingId });
                    table.ForeignKey(
                        name: "FK_UserAndBorrow_AspNetUsers_RenterId",
                        column: x => x.RenterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAndBorrow_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAndBorrow_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_UserAndBorrow_Borrowing_BorrowingId",
                        column: x => x.BorrowingId,
                        principalTable: "Borrowing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_BookId",
                table: "Borrowing",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAndBorrow_BookId",
                table: "UserAndBorrow",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAndBorrow_BorrowingId",
                table: "UserAndBorrow",
                column: "BorrowingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAndBorrow_UserId",
                table: "UserAndBorrow",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowing_Books_BookId",
                table: "Borrowing",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrowing_Books_BookId",
                table: "Borrowing");

            migrationBuilder.DropTable(
                name: "UserAndBorrow");

            migrationBuilder.DropIndex(
                name: "IX_Borrowing_BookId",
                table: "Borrowing");
        }
    }
}
