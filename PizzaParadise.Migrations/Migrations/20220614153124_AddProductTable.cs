using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaParadise.Blazor.Migrations
{
    public partial class AddProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PRICE = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.PRODUCT_ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_PRODUCT_CATEGORIES_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "PRODUCT_CATEGORIES",
                        principalColumn: "PRODUCT_CATEGORY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PRODUCT_CATEGORIES",
                columns: new[] { "PRODUCT_CATEGORY_ID", "NAME" },
                values: new object[] { 1, "Pizza" });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_ProductCategoryId",
                table: "PRODUCTS",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "PRODUCT_CATEGORY_ID",
                keyValue: 1);
        }
    }
}
