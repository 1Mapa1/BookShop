using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.db.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOrderInUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8d754690-0d1c-46ee-88a5-f34401ca9408"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c33acde7-0075-4c2d-8eb2-da258d3077bb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ec0fd740-2e26-4ef1-9fbd-f72961a3eca6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef9b9128-58ca-43bb-8168-3c5fc895f0b8"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Cost", "Description", "Genre", "ImgPath", "Name" },
                values: new object[,]
                {
                    { new Guid("278b7379-d959-442a-b9ce-e6725b6b47b1"), "А.С. Грибоедов", 400.00m, "Круто говоришь Чатский, только всем все равно", "Комедия", null, "Горе от ума" },
                    { new Guid("5564d186-8ebb-451c-b434-63fbfc2d90e4"), "И.А. Гончаров", 255.14m, "Книга о лежибоке, который смог", "Роман, Художественный вымысел, Сатира", null, "Обломов" },
                    { new Guid("68c8fad9-f5f3-480a-b6cd-5f434ffdd531"), "А.С. Пушкин", 300.98m, "Книга о том, как все в один момент может пойти...", "Роман", null, "Евгений Онегин" },
                    { new Guid("dd0f7015-0a5b-475a-95eb-516f42aca458"), "А.С. Пушкин", 50.18m, "В книге представлено стихотворение величайшего поэта", "Ода", null, "Памятник" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("278b7379-d959-442a-b9ce-e6725b6b47b1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5564d186-8ebb-451c-b434-63fbfc2d90e4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("68c8fad9-f5f3-480a-b6cd-5f434ffdd531"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd0f7015-0a5b-475a-95eb-516f42aca458"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Cost", "Description", "Genre", "ImgPath", "Name" },
                values: new object[,]
                {
                    { new Guid("8d754690-0d1c-46ee-88a5-f34401ca9408"), "А.С. Пушкин", 50.18m, "В книге представлено стихотворение величайшего поэта", "Ода", null, "Памятник" },
                    { new Guid("c33acde7-0075-4c2d-8eb2-da258d3077bb"), "А.С. Грибоедов", 400.00m, "Круто говоришь Чатский, только всем все равно", "Комедия", null, "Горе от ума" },
                    { new Guid("ec0fd740-2e26-4ef1-9fbd-f72961a3eca6"), "А.С. Пушкин", 300.98m, "Книга о том, как все в один момент может пойти...", "Роман", null, "Евгений Онегин" },
                    { new Guid("ef9b9128-58ca-43bb-8168-3c5fc895f0b8"), "И.А. Гончаров", 255.14m, "Книга о лежибоке, который смог", "Роман, Художественный вымысел, Сатира", null, "Обломов" }
                });
        }
    }
}
