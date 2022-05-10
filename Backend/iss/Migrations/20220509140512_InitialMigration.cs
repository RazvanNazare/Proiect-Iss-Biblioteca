using Microsoft.EntityFrameworkCore.Migrations;

namespace iss.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    LibraryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReturnPoint = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.LibraryId);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookCode = table.Column<int>(type: "int", nullable: false),
                    IsAvaible = table.Column<bool>(type: "bit", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibraryModelLibraryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Libraries_LibraryModelLibraryId",
                        column: x => x.LibraryModelLibraryId,
                        principalTable: "Libraries",
                        principalColumn: "LibraryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookModelUserModel",
                columns: table => new
                {
                    BookBorrowedByUsersUserId = table.Column<int>(type: "int", nullable: false),
                    BorrowedBooksBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookModelUserModel", x => new { x.BookBorrowedByUsersUserId, x.BorrowedBooksBookId });
                    table.ForeignKey(
                        name: "FK_BookModelUserModel_Books_BorrowedBooksBookId",
                        column: x => x.BorrowedBooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookModelUserModel_UserModel_BookBorrowedByUsersUserId",
                        column: x => x.BookBorrowedByUsersUserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookModelUserModel_BorrowedBooksBookId",
                table: "BookModelUserModel",
                column: "BorrowedBooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LibraryModelLibraryId",
                table: "Books",
                column: "LibraryModelLibraryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookModelUserModel");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "Libraries");
        }
    }
}
