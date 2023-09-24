using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.db.Migrations
{
    /// <inheritdoc />
    public partial class Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "StatusOrder",
                table: "Orders",
                newName: "Status");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Cost", "Description", "Genre", "ImgPath", "Name" },
                values: new object[,]
                {
                    { new Guid("020f16af-73b7-423a-a5ad-b200833ed976"), "А.С. Пушкин", 50.18m, "В книге представлено стихотворение величайшего поэта", "Ода", null, "Памятник" },
                    { new Guid("0f22be25-6c3c-4c31-bf9c-2870a626edfe"), "А.С. Пушкин", 300.98m, "Книга о том, как все в один момент может пойти...", "Роман", null, "Евгений Онегин" },
                    { new Guid("ca3b5398-319a-448e-bee3-59f9581f5778"), "А.С. Грибоедов", 400.00m, "Круто говоришь Чатский, только всем все равно", "Комедия", null, "Горе от ума" },
                    { new Guid("eb6a2902-c19c-4916-b04f-2fb3aa433e12"), "И.А. Гончаров", 255.14m, "Книга о лежибоке, который смог", "Роман, Художественный вымысел, Сатира", null, "Обломов" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("020f16af-73b7-423a-a5ad-b200833ed976"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0f22be25-6c3c-4c31-bf9c-2870a626edfe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ca3b5398-319a-448e-bee3-59f9581f5778"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb6a2902-c19c-4916-b04f-2fb3aa433e12"));

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "StatusOrder");

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
    }
}
