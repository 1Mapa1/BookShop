using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.db.Migrations
{
    /// <inheritdoc />
    public partial class AddImgPathInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Products");

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
    }
}
