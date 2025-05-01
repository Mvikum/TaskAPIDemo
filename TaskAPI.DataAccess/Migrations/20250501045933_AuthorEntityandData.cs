using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AuthorEntityandData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Sucharitha Gamlath" },
                    { 2, "Wasana Bandara" },
                    { 3, "Mahagama Sekara" },
                    { 4, "Martin Wickramasinghe" }
                });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "CreatedDate", "Due" },
                values: new object[] { 1, new DateTime(2025, 5, 1, 10, 29, 32, 759, DateTimeKind.Local).AddTicks(64), new DateTime(2025, 5, 6, 10, 29, 32, 759, DateTimeKind.Local).AddTicks(92) });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Description", "Due", "Status", "Title" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2025, 5, 1, 10, 29, 32, 759, DateTimeKind.Local).AddTicks(102), "Buy vegetables for the week ", new DateTime(2025, 5, 6, 10, 29, 32, 759, DateTimeKind.Local).AddTicks(104), 0, "Buy vegetables - DB" },
                    { 3, 2, new DateTime(2025, 5, 1, 10, 29, 32, 759, DateTimeKind.Local).AddTicks(106), "Water to plants in the evening", new DateTime(2025, 5, 6, 10, 29, 32, 759, DateTimeKind.Local).AddTicks(107), 0, "Watering to plants - DB" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_AuthorId",
                table: "Todos",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Authors_AuthorId",
                table: "Todos",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Authors_AuthorId",
                table: "Todos");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Todos_AuthorId",
                table: "Todos");

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Todos");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Due" },
                values: new object[] { new DateTime(2025, 5, 1, 9, 45, 45, 962, DateTimeKind.Local).AddTicks(6125), new DateTime(2025, 5, 6, 9, 45, 45, 962, DateTimeKind.Local).AddTicks(6139) });
        }
    }
}
