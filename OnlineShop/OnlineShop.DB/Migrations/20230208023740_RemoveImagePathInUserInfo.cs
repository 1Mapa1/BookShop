using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.db.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImagePathInUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "UserInfo");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Cost", "Description", "Genre", "ImgPath", "Name" },
                values: new object[,]
                {
                    { new Guid("14b422b9-e428-46af-a91b-5e2da030d277"), "А.С. Пушкин", 50.18m, "В книге представлено стихотворение величайшего поэта", "Ода", null, "Памятник" },
                    { new Guid("46cdd65f-06a6-4116-b602-4193a6e6ca3a"), "А.С. Грибоедов", 400.00m, "Круто говоришь Чатский, только всем все равно", "Комедия", null, "Горе от ума" },
                    { new Guid("adf4b5a0-ac19-400a-aa17-39df7a8e9645"), "И.А. Гончаров", 255.14m, "Книга о лежибоке, который смог", "Роман, Художественный вымысел, Сатира", null, "Обломов" },
                    { new Guid("da886d16-437f-4c91-a81d-b23f52f4ae79"), "А.С. Пушкин", 300.98m, "Книга о том, как все в один момент может пойти...", "Роман", null, "Евгений Онегин" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("14b422b9-e428-46af-a91b-5e2da030d277"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46cdd65f-06a6-4116-b602-4193a6e6ca3a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("adf4b5a0-ac19-400a-aa17-39df7a8e9645"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da886d16-437f-4c91-a81d-b23f52f4ae79"));

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
