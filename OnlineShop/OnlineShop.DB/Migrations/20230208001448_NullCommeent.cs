using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.db.Migrations
{
    /// <inheritdoc />
    public partial class NullCommeent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74b2e3a7-d8f7-406d-a75e-a28c98e314f9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("77aec8ce-9287-4ec8-8584-9a9596817907"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a2039e6c-755f-4a00-9027-d24d95621050"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ff3d46d1-70b2-4601-8ebb-4ecda3e3346b"));

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Cost", "Description", "Genre", "ImgPath", "Name" },
                values: new object[,]
                {
                    { new Guid("06c55184-91fe-416e-aad5-b1b31447a396"), "И.А. Гончаров", 255.14m, "Книга о лежибоке, который смог", "Роман, Художественный вымысел, Сатира", null, "Обломов" },
                    { new Guid("29b6bcb2-33b8-42c9-8f10-97d5e6cef453"), "А.С. Грибоедов", 400.00m, "Круто говоришь Чатский, только всем все равно", "Комедия", null, "Горе от ума" },
                    { new Guid("b294cf75-ebd7-48e4-b385-01e3f151b1a6"), "А.С. Пушкин", 50.18m, "В книге представлено стихотворение величайшего поэта", "Ода", null, "Памятник" },
                    { new Guid("bf57ba1d-4292-4c67-a963-c77041fe0e1a"), "А.С. Пушкин", 300.98m, "Книга о том, как все в один момент может пойти...", "Роман", null, "Евгений Онегин" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("06c55184-91fe-416e-aad5-b1b31447a396"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("29b6bcb2-33b8-42c9-8f10-97d5e6cef453"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b294cf75-ebd7-48e4-b385-01e3f151b1a6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bf57ba1d-4292-4c67-a963-c77041fe0e1a"));

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Cost", "Description", "Genre", "ImgPath", "Name" },
                values: new object[,]
                {
                    { new Guid("74b2e3a7-d8f7-406d-a75e-a28c98e314f9"), "А.С. Грибоедов", 400.00m, "Круто говоришь Чатский, только всем все равно", "Комедия", null, "Горе от ума" },
                    { new Guid("77aec8ce-9287-4ec8-8584-9a9596817907"), "А.С. Пушкин", 50.18m, "В книге представлено стихотворение величайшего поэта", "Ода", null, "Памятник" },
                    { new Guid("a2039e6c-755f-4a00-9027-d24d95621050"), "И.А. Гончаров", 255.14m, "Книга о лежибоке, который смог", "Роман, Художественный вымысел, Сатира", null, "Обломов" },
                    { new Guid("ff3d46d1-70b2-4601-8ebb-4ecda3e3346b"), "А.С. Пушкин", 300.98m, "Книга о том, как все в один момент может пойти...", "Роман", null, "Евгений Онегин" }
                });
        }
    }
}
