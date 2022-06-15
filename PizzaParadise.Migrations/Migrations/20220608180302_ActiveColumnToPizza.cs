using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaParadise.Blazor.Migrations
{
    public partial class ActiveColumnToPizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ACTIVE",
                table: "PIZZAS",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACTIVE",
                table: "PIZZAS");
        }
    }
}
