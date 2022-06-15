using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaParadise.Blazor.Migrations
{
    public partial class MoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "PRODUCT_CATEGORY_ID",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "PRODUCT_CATEGORIES",
                columns: new[] { "PRODUCT_CATEGORY_ID", "NAME" },
                values: new object[,]
                {
                    { 2, "Starters" },
                    { 3, "Pizza" },
                    { 4, "Sides" },
                    { 5, "Drinks" },
                    { 6, "Desserts" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "PRODUCT_CATEGORY_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "PRODUCT_CATEGORY_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "PRODUCT_CATEGORY_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "PRODUCT_CATEGORY_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "PRODUCT_CATEGORY_ID",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "PRODUCT_CATEGORIES",
                columns: new[] { "PRODUCT_CATEGORY_ID", "NAME" },
                values: new object[] { 1, "Pizza" });
        }
    }
}
