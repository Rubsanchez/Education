using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Education.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EducationInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreationDate", "Description", "Price", "PublishDate", "Title" },
                values: new object[,]
                {
                    { new Guid("4e85f75d-b3aa-43a2-a223-c1b3191996a9"), new DateTime(2023, 4, 18, 9, 29, 43, 396, DateTimeKind.Local).AddTicks(1948), "Java course", 25m, new DateTime(2025, 4, 18, 9, 29, 43, 396, DateTimeKind.Local).AddTicks(1951), "Java Spring Master" },
                    { new Guid("6131a1ba-7f23-430d-88e3-f89a82df7357"), new DateTime(2023, 4, 18, 9, 29, 43, 396, DateTimeKind.Local).AddTicks(1970), ".NET Core Unit test course", 1000m, new DateTime(2025, 4, 18, 9, 29, 43, 396, DateTimeKind.Local).AddTicks(1973), ".NET Core Master Unit Test" },
                    { new Guid("baf3797d-f077-4fb8-a61c-9944d445d21a"), new DateTime(2023, 4, 18, 9, 29, 43, 396, DateTimeKind.Local).AddTicks(1890), "C# basic course", 56m, new DateTime(2025, 4, 18, 9, 29, 43, 396, DateTimeKind.Local).AddTicks(1938), "From noob to pro C#" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
