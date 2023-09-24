using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.db.Migrations
{
    /// <inheritdoc />
    public partial class UserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "UserInfoId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserInfoId",
                table: "Orders",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserInfo_UserInfoId",
                table: "Orders",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserInfo_UserInfoId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserInfoId",
                table: "Orders");

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

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Orders");

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
    }
}
