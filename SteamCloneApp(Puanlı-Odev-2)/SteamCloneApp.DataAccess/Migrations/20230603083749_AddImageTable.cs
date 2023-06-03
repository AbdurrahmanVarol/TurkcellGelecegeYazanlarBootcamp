using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteamCloneApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ee5154f-a0fb-4d83-ac6f-e0d866fa4350"));

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "NickName", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("1f1d88b7-5090-4348-b98f-86af845b0650"), "abdurrahman@gmail.com", "Abdurrahman", "Varol", "abdurrahman", "WMA4dhrMhW2ZW3+8wIlpzcew0pVATmgSq4WZ+tjmiOW1R09J5lKdcxR16RIT1ds44FjeYM0o+ksAeTzSX6aXZQ==", "8qjYoxBQ2SgvH7vcbDsPbus2YFpicja5cDbz9IL6hJIgS4gTgr5uq1ADDLy7GHsIEY+0otBju+h74HRuNuFnU25/HWCXOjdKqPlksusj7mNjAR6rk9K9Oy4s1wIySzCoy3xi205Kqhgb4NJ0UcryFCvT6G/9QDQ63A9NyNVQ8s0=" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_GameId",
                table: "Images",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1f1d88b7-5090-4348-b98f-86af845b0650"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "NickName", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("6ee5154f-a0fb-4d83-ac6f-e0d866fa4350"), "abdurrahman@gmail.com", "Abdurrahman", "Varol", "abdurrahman", "WMA4dhrMhW2ZW3+8wIlpzcew0pVATmgSq4WZ+tjmiOW1R09J5lKdcxR16RIT1ds44FjeYM0o+ksAeTzSX6aXZQ==", "8qjYoxBQ2SgvH7vcbDsPbus2YFpicja5cDbz9IL6hJIgS4gTgr5uq1ADDLy7GHsIEY+0otBju+h74HRuNuFnU25/HWCXOjdKqPlksusj7mNjAR6rk9K9Oy4s1wIySzCoy3xi205Kqhgb4NJ0UcryFCvT6G/9QDQ63A9NyNVQ8s0=" });
        }
    }
}
