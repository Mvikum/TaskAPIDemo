using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CreatedDate", "Description", "Due", "Status", "Title" },
                values: new object[] { 1, new DateTime(2025, 5, 1, 9, 45, 45, 962, DateTimeKind.Local).AddTicks(6125), "Get some text books", new DateTime(2025, 5, 6, 9, 45, 45, 962, DateTimeKind.Local).AddTicks(6139), 0, "Get books - DB" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
