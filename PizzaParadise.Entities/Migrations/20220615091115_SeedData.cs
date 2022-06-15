using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaParadise.Entities.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PRODUCT_CATEGORIES",
                columns: new[] { "PRODUCT_CATEGORY_ID", "NAME" },
                values: new object[,]
                {
                    { 1, "Starters" },
                    { 2, "Pizza" },
                    { 3, "Sides" },
                    { 4, "Drinks" },
                    { 5, "Desserts" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "PRODUCT_CATEGORY_ID",
                keyValue: 1);

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
        }
    }
}
