using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaParadise.Entities.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCT_CATEGORIES",
                columns: table => new
                {
                    PRODUCT_CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_CATEGORIES", x => x.PRODUCT_CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRSTNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LASTNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EMAILADDRESS = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.USER_ID);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_ProductCategoryId",
                table: "PRODUCTS",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "PRODUCT_CATEGORIES");
        }
    }
}
