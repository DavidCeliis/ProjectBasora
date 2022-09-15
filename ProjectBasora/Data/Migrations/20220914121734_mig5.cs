using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBasora.Data.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAndBorrowFinal_AspNetUsers_RenterId",
                table: "UserAndBorrowFinal");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAndBorrowFinal_AspNetUsers_UserId",
                table: "UserAndBorrowFinal");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAndBorrowFinal_Books_BookId",
                table: "UserAndBorrowFinal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAndBorrowFinal",
                table: "UserAndBorrowFinal");

            migrationBuilder.RenameTable(
                name: "UserAndBorrowFinal",
                newName: "UserAndBorrowsFinal");

            migrationBuilder.RenameIndex(
                name: "IX_UserAndBorrowFinal_UserId",
                table: "UserAndBorrowsFinal",
                newName: "IX_UserAndBorrowsFinal_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAndBorrowFinal_BookId",
                table: "UserAndBorrowsFinal",
                newName: "IX_UserAndBorrowsFinal_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAndBorrowsFinal",
                table: "UserAndBorrowsFinal",
                columns: new[] { "RenterId", "BookId", "UserId", "UserAndBorrowFinalId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndBorrowsFinal_AspNetUsers_RenterId",
                table: "UserAndBorrowsFinal",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndBorrowsFinal_AspNetUsers_UserId",
                table: "UserAndBorrowsFinal",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndBorrowsFinal_Books_BookId",
                table: "UserAndBorrowsFinal",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAndBorrowsFinal_AspNetUsers_RenterId",
                table: "UserAndBorrowsFinal");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAndBorrowsFinal_AspNetUsers_UserId",
                table: "UserAndBorrowsFinal");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAndBorrowsFinal_Books_BookId",
                table: "UserAndBorrowsFinal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAndBorrowsFinal",
                table: "UserAndBorrowsFinal");

            migrationBuilder.RenameTable(
                name: "UserAndBorrowsFinal",
                newName: "UserAndBorrowFinal");

            migrationBuilder.RenameIndex(
                name: "IX_UserAndBorrowsFinal_UserId",
                table: "UserAndBorrowFinal",
                newName: "IX_UserAndBorrowFinal_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAndBorrowsFinal_BookId",
                table: "UserAndBorrowFinal",
                newName: "IX_UserAndBorrowFinal_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAndBorrowFinal",
                table: "UserAndBorrowFinal",
                columns: new[] { "RenterId", "BookId", "UserId", "UserAndBorrowFinalId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndBorrowFinal_AspNetUsers_RenterId",
                table: "UserAndBorrowFinal",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndBorrowFinal_AspNetUsers_UserId",
                table: "UserAndBorrowFinal",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndBorrowFinal_Books_BookId",
                table: "UserAndBorrowFinal",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId");
        }
    }
}
