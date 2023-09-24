using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.db.Migrations
{
    /// <inheritdoc />
    public partial class AddStandardValuesProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("188ded08-43cb-4059-aef4-1162ac3e7562"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1c229489-0f44-4364-8881-9f080bb32fa0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("346103db-98e5-4a91-8972-f32839a10f42"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("34abf524-242e-4002-9440-19511adfa1b3"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Cost", "Description", "Genre", "Name" },
                values: new object[,]
                {
                    { new Guid("26ce4564-1273-44e4-b738-8a671287c9d6"), "А.С. Грибоедов", 400.00m, "Круто говоришь Чатский, только всем все равно", "Комедия", "Горе от ума" },
                    { new Guid("28acd018-d725-45e9-8cb2-1ecf3b4f5bbe"), "А.С. Пушкин", 50.18m, "В книге представлено стихотворение величайшего поэта", "Ода", "Памятник" },
                    { new Guid("2c5e21a7-5aec-467a-a3cc-fe0a9c9bf747"), "И.А. Гончаров", 255.14m, "Книга о лежибоке, который смог", "Роман, Художественный вымысел, Сатира", "Обломов" },
                    { new Guid("96984a1f-feb7-483f-8d34-3ddb962faca8"), "А.С. Пушкин", 300.98m, "Книга о том, как все в один момент может пойти...", "Роман", "Евгений Онегин" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("26ce4564-1273-44e4-b738-8a671287c9d6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("28acd018-d725-45e9-8cb2-1ecf3b4f5bbe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2c5e21a7-5aec-467a-a3cc-fe0a9c9bf747"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("96984a1f-feb7-483f-8d34-3ddb962faca8"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Cost", "Description", "Genre", "Name" },
                values: new object[,]
                {
                    { new Guid("188ded08-43cb-4059-aef4-1162ac3e7562"), "А.С. Грибоедов", 0m, "Круто говоришь Чатский, только всем все равно", "Комедия", "Горе от ума" },
                    { new Guid("1c229489-0f44-4364-8881-9f080bb32fa0"), "А.С. Пушкин", 0m, "В книге представлено стихотворение величайшего поэта", "Ода", "Памятник" },
                    { new Guid("346103db-98e5-4a91-8972-f32839a10f42"), "И.А. Гончаров", 0m, "Книга о лежибоке, который смог", "Роман, Художественный вымысел, Сатира", "Обломов" },
                    { new Guid("34abf524-242e-4002-9440-19511adfa1b3"), "А.С. Пушкин", 0m, "Книга о том, как все в один момент может пойти...", "Роман", "Евгений Онегин" }
                });
        }
    }
}
